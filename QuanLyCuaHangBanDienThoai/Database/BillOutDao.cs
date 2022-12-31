using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDienThoai
{
    class BillOutDao
    {
        String constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public DataTable findAll()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM showAllBillOut", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllBillOut"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable getAllDetailBillOut(int id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT * FROM showAllDetailBillOut WHERE [Mã HĐ] = " + id;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllBillOut"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public bool insertBillOut(int accountId, int customerId)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertBillOut";
                    cmd.Parameters.AddWithValue("@accountId", accountId);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool insertDetailBillOut(int billInId, String phoneId, int quantity)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertDetailBillOut";
                    cmd.Parameters.AddWithValue("@billOutId", billInId);
                    cmd.Parameters.AddWithValue("@phoneId", phoneId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        //public bool updateBillOut(int billInId, String phoneId, double price, int quantity)
        //{
        //    using (SqlConnection cnn = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = cnn.CreateCommand())
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "updateBillIn";
        //            cmd.Parameters.AddWithValue("@billInId", billInId);
        //            cmd.Parameters.AddWithValue("@phoneId", phoneId);
        //            cmd.Parameters.AddWithValue("@price", price);
        //            cmd.Parameters.AddWithValue("@quantity", quantity);
        //            cnn.Open();
        //            int i = cmd.ExecuteNonQuery();
        //            cnn.Close();

        //            return i > 0;
        //        }
        //    }
        //}

        public bool deleteById(int id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "deleteBillOut";
                    cmd.Parameters.AddWithValue("@billOutId", id);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool deletePhoneInDetailBillOut(int billOutId, String phoneId)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "deletePhoneInDetailBillOut";
                    cmd.Parameters.AddWithValue("@billOutId", billOutId);
                    cmd.Parameters.AddWithValue("@phoneId", phoneId);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }


        public int getIdMax()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT MAX([id]) AS [Mã hóa đơn max] FROM tblBillOut";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            return Convert.ToInt32(rd["Mã hóa đơn max"]);
                        }
                        rd.Close();
                    }
                }
            }
            return -1;
        }

        public DataTable search(String billId, String nameAcount, String startDate, String endDate)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sqlSearchBillId = "";
                String sqlSearchDate = "";
                if (billId != "")
                {
                    sqlSearchBillId = " AND [Mã HĐ] = " + int.Parse(billId);
                }

                if (startDate == "" && endDate != "")
                {
                    sqlSearchDate = " AND [Ngày tạo] <= '" + DateTime.Parse(endDate) + "'";
                }
                else if (startDate == "" && endDate == "")
                {
                    sqlSearchDate = "";
                }
                else
                {
                    sqlSearchDate = " AND [Ngày tạo] BETWEEN '" + startDate + "' AND '" + endDate + "'";
                }
                    
                String sql = "SELECT * FROM showAllBillOut " +
                    "WHERE [Người tạo] LIKE N'%" + nameAcount + "%'" 
                            + sqlSearchBillId
                            + sqlSearchDate;
                MessageBox.Show(sql);
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllBillOut"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable searchPhoneInBillOut(int billOutId, String phoneId, String phoneName)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT * FROM showAllDetailBillOut " +
                    "WHERE [Mã HĐ] = " + billOutId + " AND [Mã ĐT] LIKE N'%" + phoneId + "%' " +
                    "AND [Tên ĐT] LIKE N'%" + phoneName + "%'";
                MessageBox.Show(sql);
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllBillIn"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}
