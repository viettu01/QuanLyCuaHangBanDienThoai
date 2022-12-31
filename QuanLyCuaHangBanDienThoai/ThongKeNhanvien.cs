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
    public partial class ThongKeNhanvien : Form
    {
        String constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        bool test = true;

        public ThongKeNhanvien()
        {
            InitializeComponent();
        }

        private void ThongKeNhanvien_Load(object sender, EventArgs e)
        {
            // sapxep();
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"..\..\CrytalReport\ThongkeTuoiNV.rpt");
            rp.Load(path);

            crvNV.ReportSource = rp;
            crvNV.Refresh();
        }

        public DataTable findAllTKNV()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select distinct [Năm] from TKNV", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("TKNV"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        private void sapxep()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from TKNV order by [Doanh thu] asc", cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataSet2 ds = new DataSet2();
                        DataTable dt = new DataTable();
                        ad.Fill(ds);
                        //ThongKeDienThoai rpt = new ThongKeDienThoai();
                        ReportDocument rpt = new ReportDocument();
                        String path = Path.GetFullPath(@"..\..\CrytalReport\SXTKNV.rpt");
                        rpt.Load(path);
                        rpt.SetDataSource(ds.Tables[1]);
                        crvNV.ReportSource = rpt;
                        crvNV.Refresh();
                    }
                }
            }
        }

        private void loctuoi(string lenh)
        {
            ReportDocument rp = new ReportDocument();
            String path = Path.GetFullPath(@"..\..\CrytalReport\ThongkeTuoiNV.rpt");
            rp.Load(path);
           
            rp.RecordSelectionFormula = lenh;
            crvNV.ReportSource = rp;
            crvNV.Refresh();
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            if (test == true)
            {
                if (tbTuoitu.Text != "" && tbTuoiden.Text != "")
                {
                    if (Int32.Parse(tbTuoitu.Text) > Int32.Parse(tbTuoiden.Text))
                    {
                        MessageBox.Show("Nhập tuổi từ phải nhỏ hơn tuổi đến");
                    }
                    else
                    {
                        loctuoi("{@Tuoi}>= " + tbTuoitu.Text + " and {@Tuoi} <= " + tbTuoiden.Text);
                    }
                }
                else if (tbTuoitu.Text != "" && tbTuoiden.Text == "")
                {
                    loctuoi("{@Tuoi}>= " + tbTuoitu.Text);
                    MessageBox.Show("{@Tuoi}>= " + tbTuoitu.Text);
                }
                else if (tbTuoitu.Text == "" && tbTuoiden.Text != "")
                {
                    loctuoi(" {@Tuoi} <= " + tbTuoiden.Text);
                }
                else if (tbTuoitu.Text == "" && tbTuoiden.Text == "")
                {
                    //MessageBox.Show("Mời bạn nhập ít nhất 1 trong hai ô để có thể lọc");
                    sapxep();
                }
            }
        }

        private void tbTuoitu_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(tbTuoitu.Text, out _))
            {
                if (tbTuoitu.Text == "")
                {
                    errorProvider1.Clear();
                    test = true;
                }
                else
                {
                    errorProvider1.SetError(tbTuoitu, "Tuổi từ phải là số");
                    test = false;
                }
            }
            else
            {
                //errorProvider1.SetError(tbTuoiden, "");
                errorProvider1.Clear();
                test = true;
            }
        }

        private void tbTuoiden_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(tbTuoiden.Text, out _))
            {
                if (tbTuoiden.Text == "")
                {
                    errorProvider1.Clear();
                    test = true;
                }
                else
                {
                    errorProvider1.SetError(tbTuoiden, "Tuổi đến phải là số");
                    test = false;
                }
            }
            else
            {
                //errorProvider1.SetError(tbTuoiden, "");
                errorProvider1.Clear();
                test = true;
            }
        }
    }
}
