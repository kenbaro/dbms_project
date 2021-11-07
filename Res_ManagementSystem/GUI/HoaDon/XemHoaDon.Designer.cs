
namespace Res_ManagementSystem.GUI.HoaDon
{
    partial class XemHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crysterviewHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crysterviewHD
            // 
            this.crysterviewHD.ActiveViewIndex = -1;
            this.crysterviewHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crysterviewHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crysterviewHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crysterviewHD.Location = new System.Drawing.Point(0, 0);
            this.crysterviewHD.Name = "crysterviewHD";
            this.crysterviewHD.Size = new System.Drawing.Size(823, 484);
            this.crysterviewHD.TabIndex = 0;
            // 
            // XemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 484);
            this.Controls.Add(this.crysterviewHD);
            this.Name = "XemHoaDon";
            this.Text = "XemHoaDon";
            this.Load += new System.EventHandler(this.XemHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crysterviewHD;
    }
}