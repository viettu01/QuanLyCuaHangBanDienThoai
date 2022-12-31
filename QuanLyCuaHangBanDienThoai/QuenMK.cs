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
    public partial class QuenMK : Form
    {
        AccountDao accountDao = new AccountDao();
        bool check = true;
        public QuenMK()
        {
            InitializeComponent();
        }

        private void tbTênĐN_Validating_1(object sender, CancelEventArgs e)
        {
            if (accountDao.checkExistsUsername(tbTênĐN.Text))
            {
                errorProvider1.SetError(tbTênĐN, "Tên đăng nhập không tồn tại");
                check = false;
            }
            else
            {
                errorProvider1.SetError(tbTênĐN, "");
                check = true;
            }
        }

        private void txSDT_Validating(object sender, CancelEventArgs e)
        {
            if (!long.TryParse(tbSDT.Text, out _))
                errorProvider1.SetError(tbSDT, "Bạn phải nhập số");
            else if (tbSDT.Text.IndexOf("0") != 0)
                errorProvider1.SetError(tbSDT, "Moi ban nhap dúng định dang 0XXXXXX");
            else if (tbSDT.Text.Length != 10)
                errorProvider1.SetError(tbSDT, "Bạn phải nhập đủ 10 số");
            else if (accountDao.checkExistsPhone(tbSDT.Text))
            {
                errorProvider1.SetError(tbSDT, "Số điện thoại không tồn tại");
                check = false;
            }
            else if (check == true)
            {
                errorProvider1.SetError(tbSDT, "");
            }
        }

        private int CheckingPasswordStrength(string password)
        {
            int score = 1;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.IsMatch(password, @"^(?=.*[0-9]).+$", RegexOptions.ECMAScript))   //number only //"^\d+$" if you need to match more than one digit.
                score++;
            //if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)) //both, lower and upper case
            //    score++;
            if (Regex.IsMatch(password, @"^(?=.*[a-z]).+$", RegexOptions.ECMAScript)) //lower
                score++;
            if (Regex.IsMatch(password, @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript)) //upper case
                score++;
            if (Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript)) //^[A-Z]+$
                score++;

            return score;
        }

        private void tbMKml_Validating(object sender, CancelEventArgs e)
        {
            if(tbMKml.Text!=tbMKm.Text)
            {
                errorProvider1.SetError(tbMKml, "Mời bạn nhập lại mật khẩu");
                check = false;
            } 
            else
            {
                errorProvider1.SetError(tbMKml, "");
                check = true;
            }    
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if(check==true)
            {
                accountDao.changePasswordByPhone(tbSDT.Text, tbMKml.Text);
                MessageBox.Show("Bạn đã đổi mật khẩu thành công, mời bạn đăng nhập lại");

                this.Hide();
            }    
            else
                MessageBox.Show("Mời bạn kiểm tra dữ liệu");
        }

        private void tbMKm_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(tbMKm," "+ CheckingPasswordStrength(tbMKm.Text));
        }
    }
}
