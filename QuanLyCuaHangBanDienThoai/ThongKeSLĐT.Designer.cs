
namespace QuanLyCuaHangBanDienThoai
{
    partial class ThongKeSLĐT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeSLĐT));
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.crvTTSL = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnHien = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Tồn kho",
            "Sắp hết",
            "Hết hàng"});
            this.cbTrangThai.Location = new System.Drawing.Point(74, 27);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(121, 21);
            this.cbTrangThai.TabIndex = 1;
            // 
            // crvTTSL
            // 
            this.crvTTSL.ActiveViewIndex = -1;
            this.crvTTSL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crvTTSL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTTSL.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvTTSL.Location = new System.Drawing.Point(12, 71);
            this.crvTTSL.Name = "crvTTSL";
            this.crvTTSL.Size = new System.Drawing.Size(776, 367);
            this.crvTTSL.TabIndex = 1;
            // 
            // btnHien
            // 
            this.btnHien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHien.BackgroundImage")));
            this.btnHien.FlatAppearance.BorderSize = 0;
            this.btnHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHien.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHien.Location = new System.Drawing.Point(233, 24);
            this.btnHien.Name = "btnHien";
            this.btnHien.Size = new System.Drawing.Size(75, 23);
            this.btnHien.TabIndex = 2;
            this.btnHien.Text = "Hiện";
            this.btnHien.UseVisualStyleBackColor = true;
            this.btnHien.Click += new System.EventHandler(this.btnHien_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trạng thái :";
            // 
            // ThongKeSLĐT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHien);
            this.Controls.Add(this.crvTTSL);
            this.Controls.Add(this.cbTrangThai);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ThongKeSLĐT";
            this.Text = "Thống kê trạng thái số lượng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTrangThai;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvTTSL;
        private System.Windows.Forms.Button btnHien;
        private System.Windows.Forms.Label label1;
    }
}