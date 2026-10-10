using System;
using System.Collections.Generic;
using System.Data;

namespace LAB5.Services
{
    /// <summary>Một mục trong ComboBox "Chuyến / Đoàn" (Loai: "C" = chuyến khách lẻ, "D" = đoàn).</summary>
    public class ChuyenDoanItem
    {
        public string Loai { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime NgayVe { get; set; }
        public override string ToString() { return Ten; }
    }

    public static class ChuyenDoanLookup
    {
        /// <param name="chiDaKetThuc">true: chỉ lấy chuyến/đoàn đã kết thúc (dùng cho khảo sát).</param>
        /// <param name="loai">"C", "D" hoặc null (lấy cả hai).</param>
        public static List<ChuyenDoanItem> GetAll(bool chiDaKetThuc, string loai)
        {
            var list = new List<ChuyenDoanItem>();
            if (loai == null || loai == "C")
                foreach (var c in new ChuyenService().GetAll())
                {
                    if (c.TinhTrang == "Đã hủy") continue;
                    if (chiDaKetThuc && c.TinhTrang != "Đã kết thúc") continue;
                    list.Add(new ChuyenDoanItem
                    {
                        Loai = "C",
                        Ma = c.MaChuyen,
                        NgayDi = c.NgayDi,
                        NgayVe = c.NgayVe,
                        Ten = "Chuyến lẻ " + c.MaChuyen + " (" + c.NgayDi.ToString("dd/MM/yyyy") + ")"
                    });
                }
            if (loai == null || loai == "D")
                foreach (DataRow r in new DoanKhachService().GetDanhSach().Rows)
                {
                    string tt = r.Str("TrangThai") ?? "";
                    if (tt.StartsWith("Đã hủy")) continue;
                    DateTime di = r.Date("NgayDi"), ve = r.Date("NgayVe");
                    if (chiDaKetThuc && ve.Date >= DateTime.Today) continue;
                    list.Add(new ChuyenDoanItem
                    {
                        Loai = "D",
                        Ma = r.Int("MaDoan").ToString(),
                        NgayDi = di,
                        NgayVe = ve,
                        Ten = "Đoàn " + r.Str("TenCoQuan") + " (" + di.ToString("dd/MM/yyyy") + ")"
                    });
                }
            return list;
        }
    }
}
