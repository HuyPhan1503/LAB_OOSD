using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNGK.Models;

namespace QuanLyNGK.Data
{
    /// <summary>
    /// Lập hóa đơn trong MỘT transaction:
    /// Hóa đơn + Chi tiết + Trừ tồn kho + Phiếu hẹn giao (nếu thiếu hàng) + Phiếu ghi nợ (nếu trả chậm).
    /// </summary>
    public class BanHangRepository
    {
        private class DongDaXuLy
        {
            public ChiTietBan Dong;
            public decimal DonGia;
            public int GiaoNgay;
            public int Thieu;
        }

        public LapHoaDonKetQua LapHoaDon(LapHoaDonRequest rq, bool khachQuen)
        {
            using (var conn = Db.CreateConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        string maHD = NextId(conn, tran, "HoaDon", "maHD", "HD", 4);

                        // 1. Khóa dòng NGK, đọc tồn kho + đơn giá hiện hành (BR04)
                        var cacDong = new List<DongDaXuLy>();
                        decimal tong = 0;
                        foreach (var ct in rq.ChiTiet)
                        {
                            int ton;
                            decimal gia;
                            using (var cmd = new SqlCommand(
                                "SELECT soLuongTon, donGiaBan FROM NuocGiaiKhat WITH (UPDLOCK, ROWLOCK) WHERE maNGK = @ma",
                                conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@ma", ct.MaNGK);
                                using (var rd = cmd.ExecuteReader())
                                {
                                    if (!rd.Read())
                                        throw new BusinessException("Mặt hàng " + ct.MaNGK + " không tồn tại.");
                                    ton = rd.GetInt32(0);
                                    gia = rd.GetDecimal(1);
                                }
                            }

                            int giaoNgay = Math.Min(ct.SoLuong, ton);
                            int thieu = ct.SoLuong - giaoNgay;

                            // BR06: khách vãng lai chỉ mua trong phạm vi tồn kho
                            if (thieu > 0 && !khachQuen)
                                throw new BusinessException(
                                    "Khách vãng lai: mặt hàng " + ct.MaNGK + " chỉ còn " + ton +
                                    ", không đủ " + ct.SoLuong + ". Vui lòng giảm số lượng.");

                            tong += ct.SoLuong * gia;
                            cacDong.Add(new DongDaXuLy { Dong = ct, DonGia = gia, GiaoNgay = giaoNgay, Thieu = thieu });
                        }

                        // 2. Thanh toán / công nợ (BR08, BR09)
                        decimal khachTra = khachQuen ? rq.SoTienKhachTra : tong;
                        if (khachTra < 0 || khachTra > tong)
                            throw new BusinessException("Số tiền khách trả phải từ 0 đến tổng tiền hóa đơn.");

                        decimal no = tong - khachTra;
                        if (no > 0)
                        {
                            if (string.IsNullOrWhiteSpace(rq.LyDoNo))
                                throw new BusinessException("Vui lòng nhập lý do ghi nợ.");
                            if (rq.NgayDuKienTra.Date < rq.NgayLap.Date)
                                throw new BusinessException("Ngày dự kiến trả phải lớn hơn hoặc bằng ngày lập phiếu.");
                        }

                        bool coThieu = cacDong.Exists(d => d.Thieu > 0);
                        if (coThieu && rq.NgayHenGiao.Date < rq.NgayLap.Date)
                            throw new BusinessException("Ngày hẹn giao phải lớn hơn hoặc bằng ngày lập hóa đơn.");

                        string trangThai = no == 0 ? "Đã thanh toán" : (khachTra == 0 ? "Ghi nợ" : "Trả một phần");

                        // 3. Hóa đơn
                        Exec(conn, tran,
                            @"INSERT INTO HoaDon(maHD, soHoaDon, ngayLap, maKH, maNV, tongTien, trangThaiThanhToan)
                              VALUES (@hd, @hd, @ngay, @kh, @nv, @tong, @tt)",
                            P("@hd", maHD), P("@ngay", rq.NgayLap.Date), P("@kh", rq.MaKH),
                            P("@nv", rq.MaNV), P("@tong", tong), P("@tt", trangThai));

                        // 4. Chi tiết hóa đơn + trừ tồn (chỉ phần giao ngay - BR05, BR10)
                        int stt = 0;
                        foreach (var d in cacDong)
                        {
                            stt++;
                            Exec(conn, tran,
                                @"INSERT INTO ChiTietHoaDon(maCTHD, maHD, maNGK, soLuong, donGia)
                                  VALUES (@ct, @hd, @ngk, @sl, @gia)",
                                P("@ct", maHD + "-" + stt), P("@hd", maHD), P("@ngk", d.Dong.MaNGK),
                                P("@sl", d.Dong.SoLuong), P("@gia", d.DonGia));

                            if (d.GiaoNgay > 0)
                                Exec(conn, tran,
                                    "UPDATE NuocGiaiKhat SET soLuongTon = soLuongTon - @sl WHERE maNGK = @ngk",
                                    P("@sl", d.GiaoNgay), P("@ngk", d.Dong.MaNGK));
                        }

                        // 5. Phiếu hẹn giao (BR07) cho phần còn thiếu
                        if (coThieu)
                        {
                            string maPH = "PH" + maHD.Substring(2);
                            Exec(conn, tran,
                                @"INSERT INTO PhieuHenGiao(maPhieuHen, soPhieuHen, maHD, ngayHenGiao, dotGiao, trangThai, maNV)
                                  VALUES (@ph, @ph, @hd, @ngay, 1, N'Chưa giao', @nv)",
                                P("@ph", maPH), P("@hd", maHD), P("@ngay", rq.NgayHenGiao.Date), P("@nv", rq.MaNV));

                            int n = 0;
                            foreach (var d in cacDong)
                            {
                                if (d.Thieu <= 0) continue;
                                n++;
                                Exec(conn, tran,
                                    @"INSERT INTO ChiTietPhieuHen(maCTPH, maPhieuHen, maNGK, soLuongHen)
                                      VALUES (@ct, @ph, @ngk, @sl)",
                                    P("@ct", maPH + "-" + n), P("@ph", maPH), P("@ngk", d.Dong.MaNGK), P("@sl", d.Thieu));
                            }
                        }

                        // 6. Phiếu ghi nợ (BR09)
                        if (no > 0)
                        {
                            string maPN = "PN" + maHD.Substring(2);
                            Exec(conn, tran,
                                @"INSERT INTO PhieuGhiNo(maPhieuNo, soPhieuNo, ngayLap, maKH, maHD, soTienNo, ngayDuKienTra, lyDoNo, trangThai, maNV)
                                  VALUES (@pn, @pn, @ngay, @kh, @hd, @no, @han, @lydo, N'Đang nợ', @nv)",
                                P("@pn", maPN), P("@ngay", rq.NgayLap.Date), P("@kh", rq.MaKH), P("@hd", maHD),
                                P("@no", no), P("@han", rq.NgayDuKienTra.Date), P("@lydo", rq.LyDoNo.Trim()), P("@nv", rq.MaNV));
                        }

                        tran.Commit();
                        return new LapHoaDonKetQua { MaHD = maHD, TongTien = tong, SoTienNo = no, CoPhieuHen = coThieu };
                    }
                    catch
                    {
                        try { tran.Rollback(); } catch { /* kết nối đã đóng */ }
                        throw;
                    }
                }
            }
        }

        // ---------- helpers ----------
        private static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        private static void Exec(SqlConnection conn, SqlTransaction tran, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddRange(ps);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Sinh mã tiếp theo dạng PREFIX0001, khóa bảng trong transaction để tránh trùng.</summary>
        private static string NextId(SqlConnection conn, SqlTransaction tran, string table, string col, string prefix, int digits)
        {
            string sql = "SELECT ISNULL(MAX(TRY_CAST(SUBSTRING(" + col + ", " + (prefix.Length + 1) +
                         ", 20) AS INT)), 0) + 1 FROM " + table + " WITH (UPDLOCK, HOLDLOCK) WHERE " + col + " LIKE @p + '[0-9]%'";
            using (var cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@p", prefix);
                int next = Convert.ToInt32(cmd.ExecuteScalar());
                return prefix + next.ToString("D" + digits);
            }
        }
    }
}
