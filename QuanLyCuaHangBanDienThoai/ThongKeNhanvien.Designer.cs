
namespace QuanLyCuaHangBanDienThoai
{
    partial class ThongKeNhanvien
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeNhanvien));
            this.tbTuoitu = new System.Windows.Forms.TextBox();
            this.crvNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnHien = new System.Windows.Forms.Button();
            this.tbTuoiden = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTuoitu
            // 
            this.tbTuoitu.Location = new System.Drawing.Point(84, 42);
            this.tbTuoitu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTuoitu.Name = "tbTuoitu";
            this.tbTuoitu.Size = new System.Drawing.Size(132, 22);
            this.tbTuoitu.TabIndex = 1;
            this.tbTuoitu.Validating += new System.ComponentModel.CancelEventHandler(this.tbTuoitu_Validating);
            // 
            // crvNV
            // 
            this.crvNV.ActiveViewIndex = -1;
            this.crvNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvNV.Location = new System.Drawing.Point(16, 75);
            this.crvNV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crvNV.Name = "crvNV";
            this.crvNV.Size = new System.Drawing.Size(1034, 481);
            this.crvNV.TabIndex = 1;
            this.crvNV.ToolPanelWidth = 267;
            // 
            // btnHien
            // 
            this.btnHien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHien.BackgroundImage")));
            this.btnHien.FlatAppearance.BorderSize = 0;
            this.btnHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHien.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHien.Location = new System.Drawing.Point(559, 39);
            this.btnHien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHien.Name = "btnHien";
            this.btnHien.Size = new System.Drawing.Size(100, 28);
            this.btnHien.TabIndex = 3;
            this.btnHien.Text = "Hiện";
            this.btnHien.UseVisualStyleBackColor = true;
            this.btnHien.Click += new System.EventHandler(this.btnHien_Click);
            // 
            // tbTuoiden
            // 
            this.tbTuoiden.Location = new System.Drawing.Point(355, 42);
            this.tbTuoiden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTuoiden.Name = "tbTuoiden";
            this.tbTuoiden.Size = new System.Drawing.Size(132, 22);
            this.tbTuoiden.TabIndex = 2;
            this.tbTuoiden.Validating += new System.ComponentModel.CancelEventHandler(this.tbTuoiden_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tuổi từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tuổi đến:";
            // 
            // ThongKeNhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTuoiden);
            this.Controls.Add(this.btnHien);
            this.Controls.Add(this.crvNV);
            this.Controls.Add(this.tbTuoitu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ThongKeNhanvien";
            this.Text = "Thống kê Nhân Viên theo tuổi";
            this.Load += new System.EventHandler(this.ThongKeNhanvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTuoitu;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvNV;
        private System.Windows.Forms.Button btnHien;
        private System.Windows.Forms.TextBox tbTuoiden;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}