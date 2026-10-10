using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeService _svc = new ThongKeService();

        public FrmThongKe() { InitializeComponent(); }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Today;
            cboLoaiThongKe.SelectedIndex = 0;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                if (cboLoaiThongKe.SelectedIndex < 0) throw new NghiepVuException("Chọn loại thống kê.");
                var dt = _svc.ThongKe((LoaiThongKe)cboLoaiThongKe.SelectedIndex, dtpTuNgay.Value, dtpDenNgay.Value);
                FormHelper.BindGrid(dgvDanhSach, dt);
                if (dt.Rows.Count == 0) FormHelper.Info("Không có dữ liệu trong khoảng thời gian này.");
            });
        }

        /// <summary>Xuất kết quả đang hiển thị ra file CSV (mở được bằng Excel).</summary>
        private void btnXuat_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var dt = dgvDanhSach.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0) throw new NghiepVuException("Chưa có dữ liệu để xuất.");
                using (var dlg = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "ThongKe_" + DateTime.Today.ToString("yyyyMMdd") + ".csv" })
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;
                    var sb = new StringBuilder();
                    for (int i = 0; i < dt.Columns.Count; i++) sb.Append(i > 0 ? "," : "").Append(Csv(dt.Columns[i].ColumnName));
                    sb.AppendLine();
                    foreach (DataRow r in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++) sb.Append(i > 0 ? "," : "").Append(Csv(Convert.ToString(r[i])));
                        sb.AppendLine();
                    }
                    File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                    FormHelper.Info("Đã xuất file: " + dlg.FileName);
                }
            });
        }

        private static string Csv(string s) { return "\"" + (s ?? "").Replace("\"", "\"\"") + "\""; }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
