
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    partial class FrmThongKe
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // FrmThongKe
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 520);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
