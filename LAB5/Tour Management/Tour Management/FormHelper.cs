using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using LAB5.Services;

namespace LAB5
{
    /// <summary>Hàm dùng chung cho các form: bắt lỗi, nạp ComboBox/DataGridView, đọc dòng lưới.</summary>
    internal static class FormHelper
    {
        public static bool TryRun(Action action)
        {
            try { action(); return true; }
            catch (NghiepVuException ex) { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return false;
        }

        public static void Info(string msg) { MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        public static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void BindCombo(ComboBox c, object ds, string display, string value, bool selectNone = false)
        {
            c.DataSource = null;
            c.Items.Clear();
            c.DisplayMember = display ?? "";
            c.ValueMember = value ?? "";
            c.DataSource = ds;
            c.SelectedIndex = (selectNone || c.Items.Count == 0) ? -1 : 0;
        }

        public static void SelectValue(ComboBox c, object value)
        {
            if (value == null || value == DBNull.Value || Convert.ToString(value) == "") { c.SelectedIndex = -1; return; }
            c.SelectedValue = value;
        }

        /// <param name="headers">Cặp (tên cột, tiêu đề hiển thị).</param>
        public static void BindGrid(DataGridView g, object source, params string[] headers)
        {
            g.DataSource = source;
            for (int i = 0; i + 1 < headers.Length; i += 2)
            {
                var col = g.Columns[headers[i]];
                if (col != null) col.HeaderText = headers[i + 1];
            }
            foreach (DataGridViewColumn c in g.Columns)
            {
                if (c.ValueType == typeof(DateTime)) c.DefaultCellStyle.Format = "dd/MM/yyyy";
                else if (c.ValueType == typeof(decimal)) c.DefaultCellStyle.Format = "N0";
            }
        }

        public static string Str(DataGridViewRow r, string col)
        {
            if (!r.DataGridView.Columns.Contains(col)) return "";
            var v = r.Cells[col].Value;
            return (v == null || v == DBNull.Value) ? "" : Convert.ToString(v);
        }

        public static decimal Dec(DataGridViewRow r, string col)
        {
            if (!r.DataGridView.Columns.Contains(col)) return 0m;
            var v = r.Cells[col].Value;
            return (v == null || v == DBNull.Value) ? 0m : Convert.ToDecimal(v);
        }

        public static bool Bool(DataGridViewRow r, string col)
        {
            if (!r.DataGridView.Columns.Contains(col)) return false;
            var v = r.Cells[col].Value;
            return v != null && v != DBNull.Value && Convert.ToBoolean(v);
        }

        public static DateTime Date(DataGridViewRow r, string col)
        {
            if (!r.DataGridView.Columns.Contains(col)) return DateTime.Today;
            var v = r.Cells[col].Value;
            return (v == null || v == DBNull.Value) ? DateTime.Today : Convert.ToDateTime(v);
        }

        public static void SetNum(NumericUpDown n, decimal v)
        {
            n.Value = Math.Max(n.Minimum, Math.Min(n.Maximum, v));
        }

        public static string EscapeFilter(string s) { return (s ?? "").Replace("'", "''").Replace("[", "[[]"); }

        public static void ClearInputs(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox) c.Text = "";
                else if (c is NumericUpDown) { var n = (NumericUpDown)c; n.Value = n.Minimum; }
                else if (c is CheckBox) ((CheckBox)c).Checked = false;
                else if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;
                else if (c is DateTimePicker) ((DateTimePicker)c).Value = DateTime.Today;
            }
        }
    }
}
