
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    partial class FrmTraCuuHoSo
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

            // FrmTraCuuHoSo
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 560);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTraCuuHoSo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tra cứu hồ sơ bệnh án";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
