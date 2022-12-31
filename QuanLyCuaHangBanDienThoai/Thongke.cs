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
    public partial class Thongke : Form
    {
        bool isChecked = false;
        String constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        String TKDT = @"..\..\CrytalReport\ThongkeDoanhThu.rpt";
        String SXTKDT = @"..\..\CrytalReport\SXTKDT.rpt";

        String TKĐT = @"..\..\CrytalReport\ThongkeĐT.rpt";
        String SXTKĐT = @"..\..\CrytalReport\SXTKĐT.rpt";
        String TKNV = @"..\..\CrytalReport\ThongkeNV.rpt";
        String SXTKNV = @"..\..\CrytalReport\SXTKNV.rpt";
        String TKKH = @"..\..\CrytalReport\ThongkeKH.rpt";
        String SXTKKH = @"..\..\CrytalReport\SXTKKH.rpt";

        public Thongke()
        {
            InitializeComponent();
        }

        private void Thongke_Load(object sender, EventArgs e)
        {
            loadYearCombox(cbNam);
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(TKDT);
            rp.Load(path);

            crvDT.ReportSource = rp;
            crvDT.Refresh();

            cbNam.Text = "";
        }

        private void rbNV_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = rbNV.Checked;
        }

        private void rbKH_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = rbKH.Checked;
        }

        private void rbĐT_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = rbĐT.Checked;
        }

        private void rbNV_Click(object sender, EventArgs e)
        {
            if (rbNV.Checked && !isChecked)
                rbNV.Checked = false;
            else
            {
                rbNV.Checked = true;
                isChecked = false;
            }
        }

        private void rbKH_Click(object sender, EventArgs e)
        {
            if (rbKH.Checked && !isChecked)
                rbKH.Checked = false;
            else
            {
                rbKH.Checked = true;
                isChecked = false;
            }
        }

        private void rbĐT_Click(object sender, EventArgs e)
        {
            if (rbĐT.Checked && !isChecked)
                rbĐT.Checked = false;
            else
            {
                rbĐT.Checked = true;
                isChecked = false;
            }
        }

        private void rbTang_Click(object sender, EventArgs e)
        {
            if (rbTang.Checked && !isChecked)
                rbTang.Checked = false;
            else
            {
                rbTang.Checked = true;
                isChecked = false;
            }
        }

        private void rbGiam_Click(object sender, EventArgs e)
        {
            if (rbGiam.Checked && !isChecked)
                rbGiam.Checked = false;
            else
            {
                rbGiam.Checked = true;
                isChecked = false;
            }
        }

        public DataTable findAllTKĐT()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select distinct [Năm] from TKĐT", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("TKĐT"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public void loadYearCombox(ComboBox cb)
        {
            DataTable dtProducer = findAllTKĐT();
            DataView v = new DataView(dtProducer);
            v.Sort = "Năm";

            cb.DataSource = v;
            cb.DisplayMember = "Năm";
            cb.ValueMember = "Năm";
        }

        private void locnamthang(string lenh, string ten)
        {
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(ten);
            rp.Load(path);
            rp.RecordSelectionFormula = lenh;
            crvDT.ReportSource = rp;
            crvDT.Refresh();
        }

        private void SXDT(string kieu, string loai)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select * from TKDT WHERE [Năm] like '%" + cbNam.Text + "%' and[Tháng]like'%" + cbThang.Text + "%'order by[" + loai + "] " + kieu;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet1 ds = new DataSet1();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKDT);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[4]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void MinmaxDT(string mm, string loai, string kieu)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select top(1) * from TKDT group by[Năm],[Tháng],[SLĐT bán],[Doanh thu] order by  " + mm + "([" + loai + "]) " + kieu;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                   // MessageBox.Show("SELECT TKDT.[Tháng],TKDT.[Năm],[SLĐT bán],[Doanh thu] from TKDT, (select[Năm], " + mm + "([" + loai + "]) as maxtin from TKDT group by [Năm]) a where[" + loai + "] = a.maxtin and TKDT.[Năm] like'%" + cbNam.Text + "%'");
                   // MessageBox.Show("select top(1) * from TKDT group by[Năm],[Tháng],[SLĐT bán],[Doanh thu] order by  " + mm + "([" + loai + "]) " + kieu);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet1 ds = new DataSet1();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKDT);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[4]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void SXNV(string kieu, string loai)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select * from TKNV WHERE [Năm] like '%" + cbNam.Text + "%' and[Tháng]like'%" + cbThang.Text + "%'order by[" + loai + "] " + kieu;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet2 ds = new DataSet2();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKNV);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[1]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void MinmaxNV(string mm, string loai,string thang)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select [Mã NV],[Tên NV],[Tuổi],[SLĐT bán],[Doanh thu],TKNV.[Tháng],TKNV.[Năm] from TKNV, (select[Tháng],[Năm], " + mm + "([" + loai + "]) as maxtin from TKNV group by [Năm], [Tháng])a where TKNV.Tháng = " + thang + " and [" + loai + "] = a.maxtin and TKNV.[Năm] like'%" + cbNam.Text + "%' GROUP BY [Mã NV],[Tên NV],[Tuổi],[SLĐT bán],[Doanh thu],TKNV.[Tháng],TKNV.[Năm]";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                   // MessageBox.Show("select [Mã NV],[Tên NV],[Tuổi],[SLĐT bán],[Doanh thu],TKNV.[Tháng],TKNV.[Năm] from TKNV, (select[Tháng],[Năm], a.Tháng ([" + loai + "]) as maxtin from TKNV group by [Năm], [Tháng])a where TKNV.Tháng = " + thang + " and [" + loai + "] = a.maxtin and TKNV.[Năm] like'%" + cbNam.Text + "%'");

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet2 ds = new DataSet2();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKNV);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[1]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void SXKH(string kieu, string loai)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select * from TKKH WHERE [Năm] like '%" + cbNam.Text + "%' and[Tháng]like'%" + cbThang.Text + "%'order by[" + loai + "] " + kieu;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet3 ds = new DataSet3();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKKH);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[1]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void MinmaxKH(string mm, string loai, string thang)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select [Mã KH],[Tên KH],[SLĐT mua],[Tổng tiền],TKKH.[Tháng],TKKH.[Năm] from TKKH, (select[Tháng],[Năm], " + mm + "([" + loai + "]) as maxtin from TKKH group by [Năm], [Tháng])a where TKKH.Tháng = " + thang + " and [" + loai + "] = a.maxtin and TKKH.[Năm] like'%" + cbNam.Text + "%' GROUP BY [Mã KH],[Tên KH],[SLĐT mua],[Tổng tiền],TKKH.[Tháng],TKKH.[Năm]";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                  //  MessageBox.Show("select [Mã KH],[Tên KH],[SLĐT mua],[Tổng tiền],TKKH.[Tháng],TKKH.[Năm] from TKKH, (select[Tháng],[Năm], " + mm + "([" + loai + "]) as maxtin from TKKH group by [Năm], [Tháng])a where TKKH.Tháng = " + thang + " and [" + loai + "] = a.maxtin and TKKH.[Năm] like'%" + cbNam.Text + "%' GROUP BY [Mã KH],[Tên KH],[SLĐT mua],[Tổng tiền],TKKH.[Tháng],TKKH.[Năm]");

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet3 ds = new DataSet3();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKKH);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[1]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void SXĐT(string kieu, string loai)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select * from TKĐT WHERE [Năm] like '%" + cbNam.Text + "%' and[Tháng]like'%" + cbThang.Text + "%'order by[" + loai + "] " + kieu;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet4 ds = new DataSet4();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKĐT);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[1]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void MinmaxĐT(string mm, string loai,string thang)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                String sql = "select [Mã ĐT], [Tên ĐT], [Hãng], [Giá bán], [Màu], [Rom], [Ram], [Bảo hành], [SL bán], [Doanh thu], [SL trong kho], TKĐT.[Năm], TKĐT.[Tháng] from TKĐT, (select[Tháng], [Năm], " + mm + "([" + loai + "]) as maxtin from TKĐT group by [Năm], [Tháng])a where TKĐT.Tháng = " + thang + " and [" + loai + "] = a.maxtin and TKĐT.[Năm] like'%" + cbNam.Text + "%' GROUP BY [Mã ĐT], [Tên ĐT],[Hãng],[Giá bán],[Màu],[Rom],[Ram],[Bảo hành],[SL bán],[Doanh thu],[SL trong kho],TKĐT.[Năm],TKĐT.[Tháng]";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                   // MessageBox.Show("select [Mã ĐT], [Tên ĐT],[Hãng],[Giá bán],[Màu],[Rom],[Ram],[Bảo hành],[SL bán],[Doanh thu],[SL trong kho],TKĐT.[Năm],TKĐT.[Tháng] from TKĐT, (select[Tháng],[Năm], " + mm + "([" + loai + "]) as maxtin from TKĐT group by [Năm], [Tháng])a where TKĐT.Tháng = " + thang + " and [" + loai + "] = a.maxtin and TKĐT.[Năm] like'%" + cbNam.Text + "%' GROUP BY [Mã ĐT], [Tên ĐT],[Hãng],[Giá bán],[Màu],[Rom],[Ram],[Bảo hành],[SL bán],[Doanh thu],[SL trong kho],TKĐT.[Năm],TKĐT.[Tháng]");

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet4 ds = new DataSet4();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(SXTKĐT);
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[1]);
                        crvDT.ReportSource = rpt;
                        crvDT.Refresh();
                    }
                }
            }
        }

        private void loc()
        {
            if (cbNam.Text != "")//năm
            {
                if (cbThang.Text != "")//năm+tháng
                {
                    if (cbLoaiSX.Text == "")//năm+tháng +loaisx
                    {
                        if (!rbTang.Checked && !rbGiam.Checked && !rbMin.Checked && !rbMax.Checked)//không có kiểu sx
                        {
                            //locnamthang("{@Nam}=" + cbNam.Text + " and {@Thang}=" + cbThang.Text, ten1);
                            if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text + " and {@Thang}=" + cbThang.Text, TKDT);
                            else if (rbNV.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text + " and {@Thang}=" + cbThang.Text, TKNV);
                            else if (rbKH.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text + " and {@Thang}=" + cbThang.Text, TKKH);
                            else if (rbĐT.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text + " and {@Thang}=" + cbThang.Text, TKĐT);
                        }
                        else
                            MessageBox.Show("Mời bạn nhập kiểu sắp xếp");
                    }
                    else
                    {
                        if (!rbTang.Checked && !rbGiam.Checked && !rbMin.Checked && ! rbMax.Checked)
                            MessageBox.Show("Mời bạn chọn kiểu sắp xếp");
                        if (cbLoaiSX.Text == "Số lượng")
                        {
                            if (rbGiam.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("desc", "SLĐT bán");
                                else if (rbNV.Checked)
                                    SXNV("desc", "SLĐT bán");
                                else if (rbKH.Checked)
                                    SXKH("desc", "SLĐT mua");
                                else if (rbĐT.Checked)
                                    SXĐT("desc", "SL bán");
                            }
                            else if (rbTang.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("asc", "SLĐT bán");
                                else if (rbNV.Checked)
                                    SXNV("asc", "SLĐT bán");
                                else if (rbKH.Checked)
                                    SXKH("asc", "SLĐT mua");
                                else if (rbĐT.Checked)
                                    SXĐT("asc", "SL bán");
                            }
                            else if (rbMax.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Max", "SLĐT bán", "desc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Max", "SLĐT bán",cbThang.Text);
                                else if(rbKH.Checked)
                                    MinmaxKH("Max", "SLĐT mua", cbThang.Text);
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Max", "SL bán", cbThang.Text);
                            }
                            else if (rbMin.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Min", "SLĐT bán", "asc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Min", "SLĐT bán", cbThang.Text);
                                else if (rbKH.Checked)
                                    MinmaxKH("Min", "SLĐT mua", cbThang.Text);
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Min", "SL bán", cbThang.Text);
                            }
                        }
                        if (cbLoaiSX.Text == "Doanh thu")
                        {
                            if (rbTang.Checked)
                            {
                                // sapxep("asc", ten2, loai2, i, tenv);
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("asc", "Doanh thu");
                                else if (rbNV.Checked)
                                    SXNV("asc", "Doanh thu");
                                else if (rbKH.Checked)
                                    SXKH("asc", "Tổng tiền");
                                else if (rbĐT.Checked)
                                    SXĐT("asc", "Doanh thu");
                            }
                            else if (rbGiam.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("desc", "Doanh thu");
                                else if (rbNV.Checked)
                                    SXNV("desc", "Doanh thu");
                                else if (rbKH.Checked)
                                    SXKH("desc", "Tổng tiền");
                                else if (rbĐT.Checked)
                                    SXĐT("desc", "Doanh thu");
                                //MessageBox.Show("ok");
                            }
                            else if (rbMax.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Max", "Doanh thu", "desc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Max", "Doanh thu", cbThang.Text);
                                else if (rbKH.Checked)
                                    MinmaxKH("Max", "Tổng tiền", cbThang.Text);
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Max", "Doanh thu", cbThang.Text);
                            }
                            else if (rbMin.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Min", "Doanh thu", "asc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Min", "Doanh thu", cbThang.Text);
                                else if (rbKH.Checked)
                                    MinmaxKH("Min", "Tổng tiền", cbThang.Text);
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Min", "Doanh thu", cbThang.Text);
                            }
                        }
                    }
                }
                else//năm thôi
                {
                    if (cbLoaiSX.Text == "")
                    {
                        if (!rbTang.Checked && !rbGiam.Checked && !rbMin.Checked && !rbMax.Checked)
                        {
                            if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text, TKDT);
                            else if (rbNV.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text, TKNV);
                            else if (rbKH.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text, TKKH);
                            else if (rbĐT.Checked)
                                locnamthang("{@Nam}=" + cbNam.Text, TKDT);
                        }
                        else
                            MessageBox.Show("Mời bạn nhập loại sắp xếp");
                    }
                    else
                    {
                        if (!rbTang.Checked && !rbGiam.Checked && !rbMin.Checked && !rbMax.Checked)
                            MessageBox.Show("Mời bạn chọn kiểu sắp xếp");
                        if (cbLoaiSX.Text == "Số lượng")
                        {
                            if (rbGiam.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("desc", "SLĐT bán");
                                else if (rbNV.Checked)
                                    SXNV("desc", "SLĐT bán");
                                else if (rbKH.Checked)
                                    SXKH("desc", "SLĐT mua");
                                else if (rbĐT.Checked)
                                    SXĐT("desc", "SL bán");
                            }
                            else if (rbTang.Checked)
                            {
                                // sapxep("asc", ten2, loai1, i, tenv);
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("asc", "SLĐT bán");
                                else if (rbNV.Checked)
                                    SXNV("asc", "SLĐT bán");
                                else if (rbKH.Checked)
                                    SXKH("asc", "SLĐT mua");
                                else if (rbĐT.Checked)
                                    SXĐT("asc", "SL bán");
                            }
                            else if (rbMax.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Max", "SLĐT bán", "desc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Max", "SLĐT bán", "a.Tháng");
                                else if (rbKH.Checked)
                                    MinmaxKH("Max", "SLĐT mua", "a.Tháng");
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Max", "SL bán", "a.Tháng");
                            }
                            else if (rbMin.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Min", "SLĐT bán", "asc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Min", "SLĐT bán", "a.Tháng");
                                else if (rbKH.Checked)
                                    MinmaxKH("Min", "SLĐT mua", "a.Tháng");
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Min", "SL bán", "a.Tháng");
                            }
                        }
                        if (cbLoaiSX.Text == "Doanh thu")
                        {
                            if (rbTang.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("asc", "Doanh thu");
                                else if (rbNV.Checked)
                                    SXNV("asc", "Doanh thu");
                                else if (rbKH.Checked)
                                    SXKH("asc", "Tổng tiền");
                                else if (rbĐT.Checked)
                                    SXĐT("asc", "Doanh thu");
                            }
                            else if (rbGiam.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    SXDT("desc", "Doanh thu");
                                else if (rbNV.Checked)
                                    SXNV("desc", "Doanh thu");
                                else if (rbKH.Checked)
                                    SXKH("desc", "Tổng tiền");
                                else if (rbĐT.Checked)
                                    SXĐT("desc", "Doanh thu");
                            }
                            else if (rbMax.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Max", "Doanh thu", "desc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Max", "Doanh thu", "a.Tháng");
                                else if (rbKH.Checked)
                                    MinmaxKH("Max", "Tổng tiền", "a.Tháng");
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Max", "Doanh thu", "a.Tháng");
                            }
                            else if (rbMin.Checked)
                            {
                                if (!rbNV.Checked && !rbKH.Checked && !rbĐT.Checked)
                                    MinmaxDT("Min", "Doanh thu", "asc");
                                else if (rbNV.Checked)
                                    MinmaxNV("Min", "Doanh thu", "a.Tháng");
                                else if (rbKH.Checked)
                                    MinmaxKH("Min", "Tổng tiền", "a.Tháng");
                                else if (rbĐT.Checked)
                                    MinmaxĐT("Min", "Doanh thu", "a.Tháng");
                            }
                        }
                    }
                }
            }
            else
            {
                ReportDocument rp = new ReportDocument();
                String path = Path.GetFullPath(TKDT);
                rp.Load(path);

                crvDT.ReportSource = rp;
                crvDT.Refresh();
            }
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            loc();
        }

        private void cbLoaiSX_Validating(object sender, CancelEventArgs e)
        {
            if (cbLoaiSX.Text == "")
            {
                rbGiam.Checked = false;
                rbTang.Checked = false;
                rbMax.Checked = false;
                rbMin.Checked = false;
            }
        }

        private void cbLoaiSX_TextChanged(object sender, EventArgs e)
        {
            if (cbLoaiSX.Text != "")
            {
                rbTang.Enabled = true;
                rbGiam.Enabled = true;
                rbMax.Enabled = true;
                rbMin.Enabled = true;

                //gbTheo.Enabled = true;
            }
            else
            {
                rbTang.Enabled = false;
                rbGiam.Enabled = false;
                rbMax.Enabled = false;
                rbMin.Enabled = false;

                //gbTheo.Enabled = false;
            }
        }

        private void rbTang_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = rbTang.Checked;

            if (!rbTang.Checked && !rbGiam.Checked)
                gbTheo.Enabled = false;
            else
                gbTheo.Enabled = true;
        }

        private void rbGiam_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = rbGiam.Checked;

            if (!rbTang.Checked && !rbGiam.Checked)
                gbTheo.Enabled = false;
            else
                gbTheo.Enabled = true;
        }

        private void cbNam_TextChanged(object sender, EventArgs e)
        {
            if (cbNam.Text == "")
                cbThang.Enabled = false;
            else
                cbThang.Enabled = true;
        }

        private void rbMax_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbMax.Checked && !rbMin.Checked)
                gbTheo.Enabled = false;
            else
                gbTheo.Enabled = true;
        }

        private void rbMin_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbMax.Checked && !rbMin.Checked)
                gbTheo.Enabled = false;
            else
                gbTheo.Enabled = true;
        }
    }
}
