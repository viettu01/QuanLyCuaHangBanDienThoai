
namespace QuanLyCuaHangBanDienThoai
{
    partial class Thongke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Thongke));
            this.gbTheo = new System.Windows.Forms.GroupBox();
            this.rbĐT = new System.Windows.Forms.RadioButton();
            this.rbNV = new System.Windows.Forms.RadioButton();
            this.rbKH = new System.Windows.Forms.RadioButton();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.cbLoaiSX = new System.Windows.Forms.ComboBox();
            this.rbTang = new System.Windows.Forms.RadioButton();
            this.rbGiam = new System.Windows.Forms.RadioButton();
            this.crvDT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnHien = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbMax = new System.Windows.Forms.RadioButton();
            this.rbMin = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTheo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTheo
            // 
            this.gbTheo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbTheo.Controls.Add(this.rbĐT);
            this.gbTheo.Controls.Add(this.rbNV);
            this.gbTheo.Controls.Add(this.rbKH);
            this.gbTheo.Enabled = false;
            this.gbTheo.Location = new System.Drawing.Point(470, 5);
            this.gbTheo.Name = "gbTheo";
            this.gbTheo.Size = new System.Drawing.Size(122, 101);
            this.gbTheo.TabIndex = 0;
            this.gbTheo.TabStop = false;
            this.gbTheo.Text = "Theo";
            // 
            // rbĐT
            // 
            this.rbĐT.AutoSize = true;
            this.rbĐT.Location = new System.Drawing.Point(16, 67);
            this.rbĐT.Name = "rbĐT";
            this.rbĐT.Size = new System.Drawing.Size(73, 17);
            this.rbĐT.TabIndex = 10;
            this.rbĐT.TabStop = true;
            this.rbĐT.Text = "Điện thoại";
            this.rbĐT.UseVisualStyleBackColor = true;
            this.rbĐT.CheckedChanged += new System.EventHandler(this.rbĐT_CheckedChanged);
            this.rbĐT.Click += new System.EventHandler(this.rbĐT_Click);
            // 
            // rbNV
            // 
            this.rbNV.AutoSize = true;
            this.rbNV.Location = new System.Drawing.Point(16, 21);
            this.rbNV.Name = "rbNV";
            this.rbNV.Size = new System.Drawing.Size(74, 17);
            this.rbNV.TabIndex = 8;
            this.rbNV.TabStop = true;
            this.rbNV.Text = "Nhân viên";
            this.rbNV.UseVisualStyleBackColor = true;
            this.rbNV.CheckedChanged += new System.EventHandler(this.rbNV_CheckedChanged);
            this.rbNV.Click += new System.EventHandler(this.rbNV_Click);
            // 
            // rbKH
            // 
            this.rbKH.AutoSize = true;
            this.rbKH.Location = new System.Drawing.Point(16, 45);
            this.rbKH.Name = "rbKH";
            this.rbKH.Size = new System.Drawing.Size(83, 17);
            this.rbKH.TabIndex = 9;
            this.rbKH.TabStop = true;
            this.rbKH.Text = "Khách hàng";
            this.rbKH.UseVisualStyleBackColor = true;
            this.rbKH.CheckedChanged += new System.EventHandler(this.rbKH_CheckedChanged);
            this.rbKH.Click += new System.EventHandler(this.rbKH_Click);
            // 
            // cbNam
            // 
            this.cbNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(157, 32);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(121, 21);
            this.cbNam.TabIndex = 1;
            this.cbNam.TextChanged += new System.EventHandler(this.cbNam_TextChanged);
            // 
            // cbThang
            // 
            this.cbThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang.Location = new System.Drawing.Point(157, 58);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(121, 21);
            this.cbThang.TabIndex = 2;
            // 
            // cbLoaiSX
            // 
            this.cbLoaiSX.FormattingEnabled = true;
            this.cbLoaiSX.Items.AddRange(new object[] {
            "Số lượng",
            "Doanh thu"});
            this.cbLoaiSX.Location = new System.Drawing.Point(37, 16);
            this.cbLoaiSX.Name = "cbLoaiSX";
            this.cbLoaiSX.Size = new System.Drawing.Size(132, 21);
            this.cbLoaiSX.TabIndex = 3;
            this.cbLoaiSX.TextChanged += new System.EventHandler(this.cbLoaiSX_TextChanged);
            this.cbLoaiSX.Validating += new System.ComponentModel.CancelEventHandler(this.cbLoaiSX_Validating);
            // 
            // rbTang
            // 
            this.rbTang.AutoSize = true;
            this.rbTang.Enabled = false;
            this.rbTang.Location = new System.Drawing.Point(16, 47);
            this.rbTang.Name = "rbTang";
            this.rbTang.Size = new System.Drawing.Size(71, 17);
            this.rbTang.TabIndex = 4;
            this.rbTang.Text = "Tăng dần";
            this.rbTang.UseVisualStyleBackColor = true;
            this.rbTang.CheckedChanged += new System.EventHandler(this.rbTang_CheckedChanged);
            // 
            // rbGiam
            // 
            this.rbGiam.AutoSize = true;
            this.rbGiam.Enabled = false;
            this.rbGiam.Location = new System.Drawing.Point(90, 46);
            this.rbGiam.Name = "rbGiam";
            this.rbGiam.Size = new System.Drawing.Size(70, 17);
            this.rbGiam.TabIndex = 5;
            this.rbGiam.Text = "Giảm dần";
            this.rbGiam.UseVisualStyleBackColor = true;
            this.rbGiam.CheckedChanged += new System.EventHandler(this.rbGiam_CheckedChanged);
            // 
            // crvDT
            // 
            this.crvDT.ActiveViewIndex = -1;
            this.crvDT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crvDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDT.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvDT.Location = new System.Drawing.Point(3, 112);
            this.crvDT.Name = "crvDT";
            this.crvDT.Size = new System.Drawing.Size(785, 338);
            this.crvDT.TabIndex = 5;
            // 
            // btnHien
            // 
            this.btnHien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHien.BackgroundImage")));
            this.btnHien.FlatAppearance.BorderSize = 0;
            this.btnHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHien.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHien.Location = new System.Drawing.Point(597, 44);
            this.btnHien.Name = "btnHien";
            this.btnHien.Size = new System.Drawing.Size(75, 23);
            this.btnHien.TabIndex = 11;
            this.btnHien.Text = "Hiện";
            this.btnHien.UseVisualStyleBackColor = true;
            this.btnHien.Click += new System.EventHandler(this.btnHien_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rbMax);
            this.groupBox2.Controls.Add(this.rbTang);
            this.groupBox2.Controls.Add(this.rbMin);
            this.groupBox2.Controls.Add(this.rbGiam);
            this.groupBox2.Controls.Add(this.cbLoaiSX);
            this.groupBox2.Location = new System.Drawing.Point(290, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 101);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sắp xếp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loại";
            // 
            // rbMax
            // 
            this.rbMax.AutoSize = true;
            this.rbMax.Enabled = false;
            this.rbMax.Location = new System.Drawing.Point(16, 74);
            this.rbMax.Name = "rbMax";
            this.rbMax.Size = new System.Drawing.Size(68, 17);
            this.rbMax.TabIndex = 6;
            this.rbMax.TabStop = true;
            this.rbMax.Text = "Cao nhất";
            this.rbMax.UseVisualStyleBackColor = true;
            this.rbMax.CheckedChanged += new System.EventHandler(this.rbMax_CheckedChanged);
            // 
            // rbMin
            // 
            this.rbMin.AutoSize = true;
            this.rbMin.Enabled = false;
            this.rbMin.Location = new System.Drawing.Point(90, 74);
            this.rbMin.Name = "rbMin";
            this.rbMin.Size = new System.Drawing.Size(74, 17);
            this.rbMin.TabIndex = 7;
            this.rbMin.TabStop = true;
            this.rbMin.Text = "Thấp nhất";
            this.rbMin.UseVisualStyleBackColor = true;
            this.rbMin.CheckedChanged += new System.EventHandler(this.rbMin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Năm";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tháng";
            // 
            // Thongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnHien);
            this.Controls.Add(this.crvDT);
            this.Controls.Add(this.cbThang);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.gbTheo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Thongke";
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.Thongke_Load);
            this.gbTheo.ResumeLayout(false);
            this.gbTheo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTheo;
        private System.Windows.Forms.RadioButton rbĐT;
        private System.Windows.Forms.RadioButton rbNV;
        private System.Windows.Forms.RadioButton rbKH;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.ComboBox cbLoaiSX;
        private System.Windows.Forms.RadioButton rbTang;
        private System.Windows.Forms.RadioButton rbGiam;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDT;
        private System.Windows.Forms.Button btnHien;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rbMax;
        private System.Windows.Forms.RadioButton rbMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}