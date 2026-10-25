using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Ham tien ich dung chung de dung giao dien bang code.</summary>
    public static class UI
    {
        public static Label Lbl(Control parent, string text, int x, int y, int w = 110)
        {
            var c = new Label { Text = text, Left = x, Top = y + 3, Width = w, Height = 20 };
            parent.Controls.Add(c);
            return c;
        }

        public static Label Val(Control parent, int x, int y, int w = 400, bool bold = false)
        {
            var c = new Label { Left = x, Top = y + 3, Width = w, Height = 20 };
            if (bold) c.Font = new Font(c.Font, FontStyle.Bold);
            parent.Controls.Add(c);
            return c;
        }

        public static TextBox Txt(Control parent, int x, int y, int w = 200)
        {
            var c = new TextBox { Left = x, Top = y, Width = w };
            parent.Controls.Add(c);
            return c;
        }

        public static TextBox TxtMulti(Control parent, int x, int y, int w, int h)
        {
            var c = new TextBox { Left = x, Top = y, Width = w, Height = h, Multiline = true, ScrollBars = ScrollBars.Vertical };
            parent.Controls.Add(c);
            return c;
        }

        public static ComboBox Cbo(Control parent, int x, int y, int w = 200)
        {
            var c = new ComboBox { Left = x, Top = y, Width = w, DropDownStyle = ComboBoxStyle.DropDownList };
            parent.Controls.Add(c);
            return c;
        }

        public static DateTimePicker Dtp(Control parent, int x, int y, int w = 200, bool withTime = false)
        {
            var d = new DateTimePicker
            {
                Left = x,
                Top = y,
                Width = w,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = withTime ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy"
            };
            parent.Controls.Add(d);
            return d;
        }

        public static NumericUpDown Num(Control parent, int x, int y, int w, decimal min, decimal max, decimal value, int step = 1)
        {
            var n = new NumericUpDown
            {
                Left = x,
                Top = y,
                Width = w,
                Minimum = min,
                Maximum = max,
                Value = value,
                Increment = step,
                ThousandsSeparator = true
            };
            parent.Controls.Add(n);
            return n;
        }

        public static Button Btn(Control parent, string text, int x, int y, int w, EventHandler onClick)
        {
            var b = new Button { Text = text, Left = x, Top = y, Width = w, Height = 28 };
            b.Click += onClick;
            parent.Controls.Add(b);
            return b;
        }

        public static GroupBox Grp(Control parent, string text, int x, int y, int w, int h)
        {
            var g = new GroupBox { Text = text, Left = x, Top = y, Width = w, Height = h };
            parent.Controls.Add(g);
            return g;
        }

        public static DataGridView Grid(Control parent, int x, int y, int w, int h)
        {
            var g = new DataGridView
            {
                Left = x,
                Top = y,
                Width = w,
                Height = h,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = SystemColors.Window
            };
            parent.Controls.Add(g);
            return g;
        }

        public static void Bind(ComboBox c, DataTable dt, string display, string value)
        {
            c.DataSource = dt;
            c.DisplayMember = display;
            c.ValueMember = value;
        }

        public static string Money(decimal v)
        {
            return v.ToString("N0") + " đ";
        }

        public static void Info(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string msg)
        {
            MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}