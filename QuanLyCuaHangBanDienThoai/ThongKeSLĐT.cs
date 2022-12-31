using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;
using QuanLyCuaHangBanDienThoai.CrytalReport;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace QuanLyCuaHangBanDienThoai
{
    public partial class ThongKeSLĐT : Form
    {
        public ThongKeSLĐT()
        {
            InitializeComponent();
        }

        private void loctrangthai(string lenh)
        {
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"../../CrytalReport/ThongketrangthaiĐT.rpt");
            rp.Load(path);
            rp.RecordSelectionFormula = lenh;
            crvTTSL.ReportSource = rp;
            crvTTSL.Refresh();
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            if (cbTrangThai.Text == "Tồn kho")
                loctrangthai("{ showAllPhone.SL}>" + "100");
            else if (cbTrangThai.Text == "Hết hàng")
                loctrangthai("{ showAllPhone.SL}=" + "0");
            else if (cbTrangThai.Text == "Sắp hết")
                loctrangthai("{ showAllPhone.SL}<" + "10");
        }
    }

}
