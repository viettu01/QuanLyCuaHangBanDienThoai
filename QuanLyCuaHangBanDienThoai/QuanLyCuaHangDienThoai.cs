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
    public partial class QuanLyCuaHangDienThoai : Form
    {
        public QuanLyCuaHangDienThoai()
        {
            InitializeComponent();
        }

        private void QuanLyCuaHangDienThoai_Load(object sender, EventArgs e)
        {
            //Set màu nền MDI parent
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.White;
                }
            }
        }

        private void toolStripMenuItemQuanLy_Click(object sender, EventArgs e)
        {
            QuanLy quanLy = new QuanLy();
            quanLy.MdiParent = this;
            quanLy.Dock = DockStyle.Fill;
            quanLy.Show();
        }

        private void toolStripMenuItemDangXuat_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void toolStripMenuItemBanHang_Click(object sender, EventArgs e)
        {
            BanHang banHang = new BanHang();
            banHang.MdiParent = this;
            banHang.Dock = DockStyle.Fill;
            banHang.Show();
        }

        private void ToolStripMenuItemTKNV_Click(object sender, EventArgs e)
        {
            ThongKeNhanvien thongKeNhanvien = new ThongKeNhanvien();
            thongKeNhanvien.MdiParent = this;
            thongKeNhanvien.Dock = DockStyle.Fill;
            thongKeNhanvien.Show();
        }

        private void ToolStripMenuItemtrạngTháiSốLượngĐT_Click(object sender, EventArgs e)
        {
            ThongKeSLĐT thongKeSLĐT = new ThongKeSLĐT();
            thongKeSLĐT.MdiParent = this;
            thongKeSLĐT.Dock = DockStyle.Fill;
            thongKeSLĐT.Show();
        }

        private void ToolStripMenuItemDoanhThu_Click(object sender, EventArgs e)
        {
            Thongke thongKe = new Thongke();
            thongKe.MdiParent = this;
            thongKe.Dock = DockStyle.Fill;
            thongKe.Show();
        }

        private void ToolStripMenuItemDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.MdiParent = this;
            doiMatKhau.Show();
        }

        private void ToolStripMenuItemHoaDon_Click(object sender, EventArgs e)
        {
            ThongkeHoaDon thongkeHoaDon = new ThongkeHoaDon();
            thongkeHoaDon.MdiParent = this;
            thongkeHoaDon.Dock = DockStyle.Fill;
            thongkeHoaDon.Show();
        }
    }
}
