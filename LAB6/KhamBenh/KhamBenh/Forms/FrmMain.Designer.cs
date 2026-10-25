
namespace QL_KhamBenh
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();

            this.SuspendLayout();

            // FrmMain
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1200, 700);

            this.Name = "FrmMain";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Hệ thống quản lý khám bệnh";

            this.WindowState =
                System.Windows.Forms.FormWindowState.Maximized;

            this.IsMdiContainer = true;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
