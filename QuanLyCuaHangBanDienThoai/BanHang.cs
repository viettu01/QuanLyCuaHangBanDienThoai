using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDienThoai
{
    public partial class BanHang : Form
    {
        PhoneDao phoneDao = new PhoneDao();
        CustomerDao customerDao = new CustomerDao();
        BillOutDao billOutDao = new BillOutDao();

        String namePhone = "";

        public BanHang()
        {
            InitializeComponent();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            loadDataPhoneCustomerCombox();
            loadDataIdPhoneCombox();
            cbSDTKH.Text = "";
            cbMaDT.Text = "";
        }

        private void cbSDTKH_TextChanged(object sender, EventArgs e)
        {
            if (cbSDTKH.Text == "")
            {
                tbTenKH.Text = "";
            }
            else
            {
                String nameCustomer = "";
                DataTable dt = customerDao.searchByPhone(cbSDTKH.Text);
                DataView v = new DataView(dt);

                foreach (DataRowView r in v)
                {
                    nameCustomer = r["Họ tên"].ToString();
                }
                tbTenKH.Text = nameCustomer;
            }
        }

        private void cbSDTKH_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(cbSDTKH.Text, out _))
                MessageBox.Show("Số điện thoại phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (cbSDTKH.Text.Length < 10 || cbSDTKH.Text.Length > 10)
                MessageBox.Show("Số điện thoại phải đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DataTable dt = customerDao.searchByPhone(cbSDTKH.Text);
                DataView v = new DataView(dt);
                String nameCustomer = "";

                foreach (DataRowView r in v)
                {
                    nameCustomer = r["Họ tên"].ToString();
                }
                tbTenKH.Text = nameCustomer;

                if (cbSDTKH.Text != "" && nameCustomer == "")
                {
                    MessageBox.Show("Khách hàng chưa có trong danh sách. Mời bạn thêm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //Tụ chuyển hướng khi không có khách hàng
                    //DialogResult dialogResult = MessageBox.Show("Khách hàng chưa có trong danh sách. Mời bạn thêm mới.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //if (dialogResult == DialogResult.OK)
                    //{
                    //    QuanLy quanLy = new QuanLy();
                    //    quanLy.tabControl1.SelectedIndex = 3;
                    //    quanLy.mtbSDTKH.Text = cbSDTKH.Text;
                    //    quanLy.btnThemKH_Click(sender, e);
                    //    quanLy.Show();
                    //}
                }
            }
        }

        private void cbMaDT_TextChanged(object sender, EventArgs e)
        {
            if (cbMaDT.Text == "")
            {
                tbDacDiem.Text = "";
                tbGiaBan.Text = "";
                nudSoLuong.Value = 1;
            }
            else
            {
                String dacDiem = "", price = "";
                String quantity = "";
                DataTable dt = phoneDao.searchById(cbMaDT.Text);
                DataView v = new DataView(dt);

                foreach (DataRowView r in v)
                {
                    namePhone = r["Tên ĐT"].ToString();
                    dacDiem = namePhone + "/" + r["Màu"] + "/" + r["Rom"] + "/" + r["Ram"];
                    price = r["Giá"].ToString();
                    quantity = r["SL"].ToString();
                }
                tbDacDiem.Text = dacDiem;
                tbGiaBan.Text = price;

                //if (quantity != "" && double.Parse(quantity) == 0) 
                //{
                //    MessageBox.Show("Sản phẩm đã hết. Vui lòng chọn sản phẩm khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            if (dtgvDSDT.Rows.Count != 1)
            {
                for (int rows = 0; rows < dtgvDSDT.Rows.Count - 1; rows++)
                {
                    if (dtgvDSDT.Rows[rows].Cells[0].Value.ToString().Equals(cbMaDT.Text))
                    {
                        int sl = int.Parse(dtgvDSDT.Rows[rows].Cells[2].Value.ToString());
                        sl = sl + int.Parse(nudSoLuong.Value.ToString());
                        dtgvDSDT.Rows[rows].Cells[2].Value = sl.ToString();

                        double price = double.Parse(dtgvDSDT.Rows[rows].Cells[3].Value.ToString());
                        dtgvDSDT.Rows[rows].Cells[4].Value = (price * sl).ToString();
                        return;
                    }
                }
            }
            double total = (double.Parse(tbGiaBan.Text) * int.Parse(nudSoLuong.Value.ToString()));
            String[] row = new string[] { cbMaDT.Text, namePhone, nudSoLuong.Value.ToString(), tbGiaBan.Text, total.ToString() };
            dtgvDSDT.Rows.Add(row);

            //Chức năng xóa sản phẩm trong danh sách chờ
            //for (int rows = 0; rows < dtgvDSDT.Rows.Count - 1; rows++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    dtgvDSDT[5, rows] = linkCell;
            //    dtgvDSDT[5, rows].Value = "Delete";
            //}

            btnThanhToan.Enabled = true;
        }

        private void dtgvDSDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                String task = dtgvDSDT.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dtgvDSDT.Rows.RemoveAt(rowIndex);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtgvDSDT.Rows.Clear();
            btnThanhToan.Enabled = false;

            cbSDTKH.Text = "";
            tbTenKH.Text = "";
            cbMaDT.Text = "";
            tbDacDiem.Text = "";
            nudSoLuong.Value = 1;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtgvDSDT.Rows.Count <= 1)
                MessageBox.Show("Bạn chưa thêm sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                bool check = false;
                int customerId = 0;
                foreach (DataRow row in customerDao.searchByPhone(cbSDTKH.Text).Rows)
                {
                    customerId = int.Parse(row["ID"].ToString());
                }
                billOutDao.insertBillOut(Program.accountId, customerId);

                for (int rows = 0; rows < dtgvDSDT.Rows.Count - 1; rows++)
                {
                    String phoneId = dtgvDSDT.Rows[rows].Cells[0].Value.ToString();
                    int quantity = int.Parse(dtgvDSDT.Rows[rows].Cells[2].Value.ToString());

                    check = billOutDao.insertDetailBillOut(billOutDao.getIdMax(), phoneId, quantity);
                }

                if (check)
                    MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"../../CrytalReport/CrystalReportBillOut.rpt");
            rp.Load(path);
            rp.RecordSelectionFormula = "{tblBillOut.id} = " + billOutDao.getIdMax();
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void dtgvDSDT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double tongTien = 0;
            for (int rows = 0; rows < dtgvDSDT.Rows.Count - 1; rows++)
            {
                double thanhTien = double.Parse(dtgvDSDT.Rows[rows].Cells[4].Value.ToString());
                tongTien += thanhTien;
            }
            lbTongTien.Text = tongTien + " ₫";
        }

        public void loadDataIdPhoneCombox()
        {
            DataTable dt = phoneDao.findAll();
            DataView v = new DataView(dt);
            v.Sort = "Mã ĐT";

            cbMaDT.DataSource = v;
            cbMaDT.DisplayMember = "Mã ĐT";
            cbMaDT.ValueMember = "Mã ĐT";
        }

        public void loadDataPhoneCustomerCombox()
        {
            DataTable dt = customerDao.findAll();
            DataView v = new DataView(dt);
            v.Sort = "SĐT";

            cbSDTKH.DataSource = v;
            cbSDTKH.DisplayMember = "SĐT";
            cbSDTKH.ValueMember = "SĐT";
        }

        private void dtgvDSDT_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double tongTien = 0;
            for (int rows = 0; rows < dtgvDSDT.Rows.Count - 1; rows++)
            {
                double thanhTien = double.Parse(dtgvDSDT.Rows[rows].Cells[4].Value.ToString());
                tongTien += thanhTien;
            }
            lbTongTien.Text = tongTien + " ₫";
        }
    }
}
