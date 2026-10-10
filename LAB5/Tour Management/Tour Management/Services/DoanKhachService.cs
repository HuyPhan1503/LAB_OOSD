using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient; 
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class DoanKhachService
    {
        // MySQL gọi Stored Procedure bằng từ khóa CALL
        public DataTable GetDanhSach()
        {
            return Db.Query("CALL sp_Doan_DanhSach();");
        }

        /// <summary>Phân loại khách theo số người (BR01).</summary>
        public static string PhanLoai(int soNguoi)
        {
            if (soNguoi > 12) return "Khách đoàn";
            if (soNguoi < 12) return "Khách lẻ";
            throw new NghiepVuException("Trường hợp đúng 12 người chưa có quy định, cần thống nhất với đơn vị sử dụng.");
        }

        /// <summary>
        /// Đăng ký đoàn (BR02, BR03). Lưu đoàn + danh sách người đi trong 1 transaction.
        /// Trả về MaDoan.
        /// </summary>
        public int DangKy(DoanKhach d, List<NguoiDiDoan> nguoiDis)
        {
            if (string.IsNullOrWhiteSpace(d.TenCoQuan) || string.IsNullOrWhiteSpace(d.NguoiDaiDien))
                throw new NghiepVuException("Nhập đủ tên cơ quan (hoặc đại diện gia đình) và người đại diện.");
            if (string.IsNullOrWhiteSpace(d.DiaChi) || string.IsNullOrWhiteSpace(d.DienThoai))
                throw new NghiepVuException("Nhập địa chỉ và điện thoại.");
            if (string.IsNullOrWhiteSpace(d.MaTour)) throw new NghiepVuException("Chọn tour.");
            if (PhanLoai(d.SoNguoi) != "Khách đoàn") throw new NghiepVuException("Khách đoàn phải trên 12 người; dưới 12 người hãy đăng ký khách lẻ.");
            if (d.NgayDi.Date < DateTime.Today) throw new NghiepVuException("Ngày đi không được ở quá khứ.");
            if (d.TienDatCoc <= 0) throw new NghiepVuException("Khách đoàn phải đặt cọc trước.");

            if (d.CoBaoHiem)
            {
                if (d.SoNguoiBaoHiem <= 0 || d.SoNguoiBaoHiem > d.SoNguoi)
                    throw new NghiepVuException("Số người mua bảo hiểm không hợp lệ.");
                int coBH = nguoiDis == null ? 0 : nguoiDis.FindAll(x => x.MuaBaoHiem).Count;
                if (coBH < d.SoNguoiBaoHiem)
                    throw new NghiepVuException("Mua bảo hiểm phải kèm danh sách những người cùng đi (còn thiếu " + (d.SoNguoiBaoHiem - coBH) + " người).");
            }

            using (var cn = Db.OpenConnection()) // Mở MySqlConnection
            using (var tx = cn.BeginTransaction()) // Tạo MySqlTransaction
            {
                try
                {
                    int maDoan;
                    using (var cmd = new MySqlCommand("sp_Doan_Them", cn, tx) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("p_TenCoQuan", d.TenCoQuan.Trim());
                        cmd.Parameters.AddWithValue("p_DiaChi", d.DiaChi.Trim());
                        cmd.Parameters.AddWithValue("p_DienThoai", d.DienThoai.Trim());
                        cmd.Parameters.AddWithValue("p_NguoiDaiDien", d.NguoiDaiDien.Trim());
                        cmd.Parameters.AddWithValue("p_MaTour", d.MaTour);
                        cmd.Parameters.AddWithValue("p_NgayDi", d.NgayDi.Date);
                        cmd.Parameters.AddWithValue("p_SoNguoi", d.SoNguoi);
                        cmd.Parameters.AddWithValue("p_DiaDiemDon", d.DiaDiemDon);
                        cmd.Parameters.AddWithValue("p_CoBaoHiem", d.CoBaoHiem);
                        cmd.Parameters.AddWithValue("p_SoNguoiBaoHiem", d.SoNguoiBaoHiem);
                        cmd.Parameters.AddWithValue("p_TienDatCoc", d.TienDatCoc);

                        maDoan = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (nguoiDis != null)
                    {
                        foreach (var n in nguoiDis)
                        {
                            using (var cmd = new MySqlCommand("sp_Doan_ThemNguoiDi", cn, tx) { CommandType = CommandType.StoredProcedure })
                            {
                                cmd.Parameters.AddWithValue("p_MaDoan", maDoan);
                                cmd.Parameters.AddWithValue("p_HoTen", n.HoTen);
                                cmd.Parameters.AddWithValue("p_CCCD", n.CCCD);
                                cmd.Parameters.AddWithValue("p_MuaBaoHiem", n.MuaBaoHiem);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tx.Commit();
                    return maDoan;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>Hủy đoàn: theo quy định, đoàn hủy/không đi sẽ mất tiền cọc (BR03).</summary>
        public void Huy(int maDoan)
        {
            Db.Execute("CALL sp_Doan_Huy(@p_MaDoan)", new MySqlParameter("p_MaDoan", maDoan));
        }
    }
}