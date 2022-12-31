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
    public partial class ThongkeHoaDon : Form
    {
        public ThongkeHoaDon()
        {
            InitializeComponent();
        }

        private void crvBill_Load(object sender, EventArgs e)
        {
            
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"../../CrytalReport/ThongkeHĐ.rpt");
            rp.Load(path);
            
            crvBill.ReportSource = rp;
            crvBill.Refresh();
        }

        private void filterbydate(String filter)
        {
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"../../CrytalReport/ThongkeHĐ.rpt");
            rp.Load(path);
            rp.RecordSelectionFormula = filter;

            crvBill.ReportSource = rp;
            crvBill.Refresh();
        }
        private void btnHien_Click(object sender, EventArgs e)
        {

            String filter = "{FullDetailBillOut.Ngày lập} >= #" + dtpNgaytu.Value
                + "# AND {FullDetailBillOut.Ngày lập} <= #" + dtpNgayden.Value + "#";
            String filter2 = "{FullDetailBillOut.Ngày lập} >= #" + dtpNgaytu.Value + "#";
            String filter3 =  "{FullDetailBillOut.Ngày lập} <= #" + dtpNgayden.Value + "#";

            if(dtpNgayden.Text==" "&& dtpNgaytu.Text==" ")
            {
                MessageBox.Show("Mời bạn nhập thông tin lọc");

            }    
            else if(dtpNgayden.Text != " " && dtpNgaytu.Text != " ")
            {
                filterbydate(filter);
            }
            else if (dtpNgayden.Text == " " && dtpNgaytu.Text != " ")
            {
                filterbydate(filter2);
            }
            else if (dtpNgayden.Text != " " && dtpNgaytu.Text == " ")
            {
                filterbydate(filter3);
            }
        }

        private void dtpNgaytu_ValueChanged(object sender, EventArgs e)
        {
            dtpNgaytu.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpNgayden_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayden.CustomFormat = "dd/MM/yyyy";
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            dtpNgaytu.CustomFormat = " ";
            dtpNgayden.CustomFormat = " ";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"../../CrytalReport/ThongkeHĐ.rpt");
            rp.Load(path);
            rp.RecordSelectionFormula = "YEAR({FullDetailBillOut.Ngày lập}) = "+tbNam.Text+" AND MONTH({FullDetailBillOut.Ngày lập}) = " + tbThang.Text;

            crvBill.ReportSource = rp;
            crvBill.Refresh();
        }
    }
}
