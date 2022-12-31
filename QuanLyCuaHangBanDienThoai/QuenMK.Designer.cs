
namespace QuanLyCuaHangBanDienThoai
{
    partial class QuenMK
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
            this.tbTênĐN = new System.Windows.Forms.TextBox();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.tbMKm = new System.Windows.Forms.TextBox();
            this.tbMKml = new System.Windows.Forms.TextBox();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTênĐN
            // 
            this.tbTênĐN.Location = new System.Drawing.Point(191, 28);
            this.tbTênĐN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTênĐN.Name = "tbTênĐN";
            this.tbTênĐN.Size = new System.Drawing.Size(177, 22);
            this.tbTênĐN.TabIndex = 0;
            this.tbTênĐN.Validating += new System.ComponentModel.CancelEventHandler(this.tbTênĐN_Validating_1);
            // 
            // tbSDT
            // 
            this.tbSDT.Location = new System.Drawing.Point(191, 78);
            this.tbSDT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(177, 22);
            this.tbSDT.TabIndex = 1;
            this.tbSDT.Validating += new System.ComponentModel.CancelEventHandler(this.txSDT_Validating);
            // 
            // tbMKm
            // 
            this.tbMKm.Location = new System.Drawing.Point(191, 129);
            this.tbMKm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMKm.Name = "tbMKm";
            this.tbMKm.Size = new System.Drawing.Size(177, 22);
            this.tbMKm.TabIndex = 2;
            this.tbMKm.Validating += new System.ComponentModel.CancelEventHandler(this.tbMKm_Validating);
            // 
            // tbMKml
            // 
            this.tbMKml.Location = new System.Drawing.Point(191, 191);
            this.tbMKml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMKml.Name = "tbMKml";
            this.tbMKml.Size = new System.Drawing.Size(177, 22);
            this.tbMKml.TabIndex = 3;
            this.tbMKml.Validating += new System.ComponentModel.CancelEventHandler(this.tbMKml_Validating);
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Location = new System.Drawing.Point(191, 251);
            this.btnDoiMK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(179, 28);
            this.btnDoiMK.TabIndex = 4;
            this.btnDoiMK.Text = "Đổi mât khẩu";
            this.btnDoiMK.UseVisualStyleBackColor = true;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(115, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(115, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên ĐN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(115, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "SĐT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(115, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nhập lại:";
            // 
            // QuenMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoiMK);
            this.Controls.Add(this.tbMKml);
            this.Controls.Add(this.tbMKm);
            this.Controls.Add(this.tbSDT);
            this.Controls.Add(this.tbTênĐN);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QuenMK";
            this.Text = "Quên mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTênĐN;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.TextBox tbMKm;
        private System.Windows.Forms.TextBox tbMKml;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}