using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDienThoai
{
    public partial class Login : Form
    {
        AccountDao accountDao = new AccountDao();

        int dem = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String username = tbTenDangNhap.Text;
            String password = tbMatKhau.Text;

            if (accountDao.login(username, password) == 0)
                errorProviderLogin.SetError(tbTenDangNhap, "Tên đăng nhập không tồn tại");
            else
                errorProviderLogin.SetError(tbTenDangNhap, "");

            if (accountDao.login(username, password) == 2)
            {
                errorProviderLogin.SetError(tbMatKhau, "Sai mật khẩu");
                tbMatKhau.Text = "";
                dem++;
            }
            else
                errorProviderLogin.SetError(tbMatKhau, "");

            //Nhập quá 3 lần thì sẽ khóa tài khoản
            //if (dem > 3)
            //{
            //    accountDao.changeStatus(tbTenDangNhap.Text, 0);
            //    //MessageBox.Show("Tài khoản đã bị khóa, mời bạn liên hệ với admin để lấy lại mật khẩu");
            //    MessageBox.Show("Bạn chờ 1 phút sau để đăng nhập vào chương trình");
            //    dem = 0;

            //    return;
            //}
            //else if (dem == 3)
            //{
            //    accountDao.changeLastTimeLogin(username);
            //}

            if (accountDao.login(username, password) == 1)
            {
                accountDao.changeLastTimeLogin(username);
                accountDao.insertDetail(Program.accountId);
                //accountDao.changeStatus(tbTenDangNhap.Text, 1);
                /*MessageBox.Show("đntc");*/

                new QuanLyCuaHangDienThoai().Show();
                this.Hide();
            }
            else if (accountDao.login(username, password) == 3)
            {
                MessageBox.Show("Tài khoản đã bị khóa , mời bạn liên hệ với admin để lấy lại mật khẩu");
                //MessageBox.Show("Bạn chờ 5 phút sau để đăng nhập vào chương trình");
            }
        }

        private void tbTenDangNhap_Validating(object sender, CancelEventArgs e)
        {
            String username = tbTenDangNhap.Text;
            String password = tbMatKhau.Text;


            if (accountDao.login(username, password) == 0)
                errorProviderLogin.SetError(tbTenDangNhap, "Tên đăng nhập không tồn tại");
            else
                errorProviderLogin.SetError(tbTenDangNhap, "");
        }

        private void lbQuenMK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ với admin để lấy lại mật khẩu", "Thông báo");
            //QuenMK quenMK = new QuenMK();
            //quenMK.Show();
        }
    }
}
