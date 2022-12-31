using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDienThoai
{
    public partial class DoiMatKhau : Form
    {
        AccountDao account = new AccountDao();

        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!account.checkPassword(Program.accountId, mtbOldPassword.Text))
                MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (mtbReNewPassword.Text != mtbNewPassword.Text)
                MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if(account.changePassword(Program.accountId, mtbReNewPassword.Text))
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mtbOldPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!new AccountDao().checkPassword(Program.accountId, mtbOldPassword.Text))
                errorProvider1.SetError(mtbOldPassword, "Mật khẩu cũ không đúng");
            else
                errorProvider1.SetError(mtbOldPassword, "");
        }

        private void mtbNewPassword_Validating(object sender, CancelEventArgs e)
        {

        }

        private void mtbReNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (mtbReNewPassword.Text != mtbNewPassword.Text)
                errorProvider1.SetError(mtbReNewPassword, "Mật khẩu không khớp");
            else
                errorProvider1.SetError(mtbReNewPassword, "");
        }

        private int CheckingPasswordStrength(string password)
        {
            int score = 1;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            //Chekc xem mật khẩu có số hay không
            if (Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript))   //number only //"^\d+$" if you need to match more than one digit.
                score++;
            //if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)) //both, lower and upper case
            //    score++;

            //Chekc xem mật khẩu có chữ thường không
            if (Regex.IsMatch(password, @"^(?=.*[a-z]).+$", RegexOptions.ECMAScript)) //lower
                score++;

            //Chekc xem mật khẩu có chữ hoa không
            if (Regex.IsMatch(password, @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript)) //upper case
                score++;

            //Chekc xem mật khẩu có ký tự đặc biệt hay không
            if (Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript)) //^[A-Z]+$
                score++;

            return score;
        }

        private void mtbNewPassword_TextChanged(object sender, EventArgs e)
        {
            //if (!Regex.IsMatch(mtbNewPassword.Text.Substring(0, 1), @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript)) //^[A-Z]+$
            //    errorProvider1.SetError(mtbNewPassword, "Mật khẩu cần có chữ hoa ở đầu tiên");
            //else
            //    errorProvider1.SetError(mtbNewPassword, "");

            if (mtbNewPassword.Text.Length < 8)
                errorProvider1.SetError(mtbNewPassword, "Mật khẩu cần có từ 8 ký tự trở lên");
            else if (!Regex.IsMatch(mtbNewPassword.Text.Substring(0, 1), @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript))
                errorProvider1.SetError(mtbNewPassword, "Mật khẩu cần có chữ hoa ở đầu tiên");
            //else if ()

            errorProvider1.SetError(mtbNewPassword, "" + CheckingPasswordStrength(mtbNewPassword.Text));
        }
    }
}
