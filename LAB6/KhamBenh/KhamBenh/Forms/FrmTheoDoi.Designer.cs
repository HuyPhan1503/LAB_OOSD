
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    partial class FrmTheoDoi
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

            // FrmTheoDoi
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTheoDoi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Theo dõi sau điều trị";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
