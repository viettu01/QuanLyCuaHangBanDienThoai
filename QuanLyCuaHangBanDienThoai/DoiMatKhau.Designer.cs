
namespace QuanLyCuaHangBanDienThoai
{
    partial class DoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbOldPassword = new System.Windows.Forms.MaskedTextBox();
            this.mtbNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.mtbReNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập lại mật khẩu mới";
            // 
            // mtbOldPassword
            // 
            this.mtbOldPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mtbOldPassword.Location = new System.Drawing.Point(365, 6);
            this.mtbOldPassword.Name = "mtbOldPassword";
            this.mtbOldPassword.Size = new System.Drawing.Size(212, 22);
            this.mtbOldPassword.TabIndex = 3;
            this.mtbOldPassword.Validating += new System.ComponentModel.CancelEventHandler(this.mtbOldPassword_Validating);
            // 
            // mtbNewPassword
            // 
            this.mtbNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mtbNewPassword.Location = new System.Drawing.Point(365, 48);
            this.mtbNewPassword.Name = "mtbNewPassword";
            this.mtbNewPassword.Size = new System.Drawing.Size(212, 22);
            this.mtbNewPassword.TabIndex = 4;
            this.mtbNewPassword.TextChanged += new System.EventHandler(this.mtbNewPassword_TextChanged);
            this.mtbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.mtbNewPassword_Validating);
            // 
            // mtbReNewPassword
            // 
            this.mtbReNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mtbReNewPassword.Location = new System.Drawing.Point(365, 90);
            this.mtbReNewPassword.Name = "mtbReNewPassword";
            this.mtbReNewPassword.Size = new System.Drawing.Size(212, 22);
            this.mtbReNewPassword.TabIndex = 5;
            this.mtbReNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.mtbReNewPassword_Validating);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXacNhan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.BackgroundImage")));
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnXacNhan.Location = new System.Drawing.Point(365, 132);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(212, 25);
            this.btnXacNhan.TabIndex = 20;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.mtbReNewPassword);
            this.Controls.Add(this.mtbNewPassword);
            this.Controls.Add(this.mtbOldPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DoiMatKhau";
            this.Opacity = 0D;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbOldPassword;
        private System.Windows.Forms.MaskedTextBox mtbNewPassword;
        private System.Windows.Forms.MaskedTextBox mtbReNewPassword;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}