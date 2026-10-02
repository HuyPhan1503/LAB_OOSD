using System;
using System.Collections.Generic;
using System.Data;
using eShopping.Services;
using MySql.Data.MySqlClient;
using Shopping.Data;
using Shopping.Models;

namespace Shopping.Services
{
    public static class DonHangService
    {
        // ---------- Du lieu danh muc ----------
        public static List<KhuVuc> LayKhuVuc()
        {
            List<KhuVuc> ds = new List<KhuVuc>();
            foreach (DataRow r in Db.Query("SELECT MaKhuVuc, TenKhuVuc FROM KhuVuc ORDER BY TenKhuVuc").Rows)
                ds.Add(new KhuVuc { MaKhuVuc = Convert.ToInt32(r["MaKhuVuc"]), TenKhuVuc = r["TenKhuVuc"] as string });
            return ds;
        }

        public static List<LoaiPhieu> LayLoaiPhieu()
        {
            List<LoaiPhieu> ds = new List<LoaiPhieu>();
            foreach (DataRow r in Db.Query("SELECT MaLoaiPhieu, TenLoaiPhieu, ThoiGianXuLy FROM LoaiPhieu ORDER BY MaLoaiPhieu").Rows)
                ds.Add(new LoaiPhieu
                {
                    MaLoaiPhieu = Convert.ToInt32(r["MaLoaiPhieu"]),
                    TenLoaiPhieu = r["TenLoaiPhieu"] as string,
                    ThoiGianXuLy = r["ThoiGianXuLy"] as string
                });
            return ds;
        }

        public static List<LoaiThe> LayLoaiThe()
        {
            List<LoaiThe> ds = new List<LoaiThe>();
            foreach (DataRow r in Db.Query("SELECT * FROM LoaiThe ORDER BY MaLoaiThe").Rows)
                ds.Add(new LoaiThe
                {
                    MaLoaiThe = Convert.ToInt32(r["MaLoaiThe"]),
                    TenLoaiThe = r["TenLoaiThe"] as string,
                    DoDaiSoThe = Convert.ToInt32(r["DoDaiSoThe"]),
                    DoDaiCSV = Convert.ToInt32(r["DoDaiCSV"]),
                    LePhi = Convert.ToDecimal(r["LePhi"])
                });
            return ds;
        }

        // ---------- Tinh tien ----------
        // Quy tac de bai: >= 1.000.000 mien phi chuyen phat nhanh; >= 5.000.000 mien phi chuyen phat trong ngay
        public static decimal TinhPhiGiaoHang(int maKhuVuc, int maLoaiPhieu, decimal tienHang)
        {
            if (maLoaiPhieu == HangSo.PHIEU_NHANH && tienHang >= HangSo.NGUONG_MIEN_PHI_NHANH) return 0;
            if (maLoaiPhieu == HangSo.PHIEU_TRONG_NGAY && tienHang >= HangSo.NGUONG_MIEN_PHI_TRONG_NGAY) return 0;

            object o = Db.Scalar("SELECT Phi FROM PhiGiaoHang WHERE MaKhuVuc=@kv AND MaLoaiPhieu=@lp",
                Db.P("@kv", maKhuVuc), Db.P("@lp", maLoaiPhieu));
            return (o == null || o == DBNull.Value) ? 0 : Convert.ToDecimal(o);
        }

        // ---------- Dat hang ----------
        // Loi nghiep vu (gio rong, het hang, the sai...) -> InvalidOperationException
        public static DonHang DatHang(KhachHang kh, NguoiNhan nn, LoaiPhieu loaiPhieu, LoaiThe loaiThe,
                                      ThongTinThe the, List<ChiTietGioHang> gio)
        {
            if (gio == null || gio.Count == 0) throw new InvalidOperationException("Giỏ hàng đang trống.");
            if (string.IsNullOrWhiteSpace(nn.HoTen) || string.IsNullOrWhiteSpace(nn.DiaChi) || string.IsNullOrWhiteSpace(nn.DienThoai))
                throw new InvalidOperationException("Vui lòng nhập đầy đủ họ tên, địa chỉ, điện thoại người nhận.");

            // 1. Kiem tra con hang + dung gia hien hanh
            foreach (ChiTietGioHang c in gio)
            {
                SanPham sp = SanPhamService.LayTheoMa(c.MaSP);
                if (sp == null || !sp.CoHang) throw new InvalidOperationException("Sản phẩm \"" + c.TenSP + "\" đã hết hàng. Vui lòng xóa khỏi giỏ.");
                c.GiaBan = sp.GiaBan;
            }

            // 2. Tinh tien (khong tin so lieu tu giao dien)
            decimal tienHang = GioHangService.TinhTienHang(gio);
            decimal phi = TinhPhiGiaoHang(nn.MaKhuVuc, loaiPhieu.MaLoaiPhieu, tienHang);
            decimal lePhi = loaiThe.LePhi;
            decimal tong = tienHang + phi + lePhi;

            // 3. Kiem tra the qua he thong thanh toan
            the.MaLoaiThe = loaiThe.MaLoaiThe;
            string loi = ThanhToanService.KiemTraThe(loaiThe, the, tong);
            if (loi != null) throw new InvalidOperationException(loi);

            // 4. Ghi don hang trong 1 transaction
            DonHang don = new DonHang
            {
                MaKhachHang = kh.MaKhachHang,
                MaLoaiPhieu = loaiPhieu.MaLoaiPhieu,
                MaLoaiThe = loaiThe.MaLoaiThe,
                SoTheChe = the.SoTheChe,            // chi luu 4 so cuoi
                TenChuThe = the.TenChuThe.Trim(),
                NgayHetHan = the.NgayHetHan,
                TienHang = tienHang,
                PhiGiaoHang = phi,
                LePhiThe = lePhi,
                TongTriGia = tong,
                ThoiDiemDat = DateTime.Now,
                TrangThai = "Mới"
            };

            using (MySqlConnection cn = Db.OpenConnection())
            using (MySqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    nn.MaNguoiNhan = Convert.ToInt32(Cmd(cn, tx,
                        "INSERT INTO NguoiNhan(HoTen,DiaChi,DienThoai,MaKhuVuc) VALUES(@ht,@dc,@dt,@kv); SELECT LAST_INSERT_ID();",
                        Db.P("@ht", nn.HoTen.Trim()), Db.P("@dc", nn.DiaChi.Trim()),
                        Db.P("@dt", nn.DienThoai.Trim()), Db.P("@kv", nn.MaKhuVuc)).ExecuteScalar());
                    don.MaNguoiNhan = nn.MaNguoiNhan;

                    don.MaDonHang = Convert.ToInt32(Cmd(cn, tx,
                        "INSERT INTO DonHang(MaKhachHang,MaNguoiNhan,MaLoaiPhieu,MaLoaiThe,SoTheChe,TenChuThe,NgayHetHan," +
                        "TienHang,PhiGiaoHang,LePhiThe,TongTriGia,ThoiDiemDat,TrangThai) " +
                        "VALUES(@kh,@nn,@lp,@lt,@stc,@tct,@nhh,@th,@pgh,@lpt,@tong,@tg,@tt); SELECT LAST_INSERT_ID();",
                        Db.P("@kh", don.MaKhachHang), Db.P("@nn", don.MaNguoiNhan), Db.P("@lp", don.MaLoaiPhieu),
                        Db.P("@lt", don.MaLoaiThe), Db.P("@stc", don.SoTheChe), Db.P("@tct", don.TenChuThe),
                        Db.P("@nhh", don.NgayHetHan), Db.P("@th", don.TienHang), Db.P("@pgh", don.PhiGiaoHang),
                        Db.P("@lpt", don.LePhiThe), Db.P("@tong", don.TongTriGia), Db.P("@tg", don.ThoiDiemDat),
                        Db.P("@tt", don.TrangThai)).ExecuteScalar());

                    foreach (ChiTietGioHang c in gio)
                        Cmd(cn, tx, "INSERT INTO ChiTietDonHang(MaDonHang,MaSP,SoLuong,DonGia) VALUES(@dh,@sp,@sl,@dg)",
                            Db.P("@dh", don.MaDonHang), Db.P("@sp", c.MaSP), Db.P("@sl", c.SoLuong), Db.P("@dg", c.GiaBan)).ExecuteNonQuery();

                    // Luu y: bang trong CSDL MySQL ten la ChiTietGioHang (khong phai GioHang)
                    Cmd(cn, tx, "DELETE FROM ChiTietGioHang WHERE MaKhachHang=@kh", Db.P("@kh", kh.MaKhachHang)).ExecuteNonQuery();
                    tx.Commit();
                }
                catch { tx.Rollback(); throw; }
            }

            // 5. Gui email xac nhan (neu khach co email)
            List<ChiTietDonHang> ct = new List<ChiTietDonHang>();
            foreach (ChiTietGioHang c in gio)
                ct.Add(new ChiTietDonHang { MaDonHang = don.MaDonHang, MaSP = c.MaSP, TenSP = c.TenSP, SoLuong = c.SoLuong, DonGia = c.GiaBan });
            EmailService.GuiXacNhan(kh, don, nn, ct);

            return don;
        }

        private static MySqlCommand Cmd(MySqlConnection cn, MySqlTransaction tx, string sql, params MySqlParameter[] ps)
        {
            MySqlCommand cmd = new MySqlCommand(sql, cn, tx);
            cmd.Parameters.AddRange(ps);
            return cmd;
        }
    }
}