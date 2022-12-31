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
    class BillInDao
    {
        String constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public DataTable findAll()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM showAllBillIn", cnn))
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

        public bool insertBillIn(int accountId)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertBillIn";
                    cmd.Parameters.AddWithValue("@accountId", accountId);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool insertDetailBillIn(int billInId, String phoneId, double price, int quantity)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertDetailBillIn";
                    cmd.Parameters.AddWithValue("@billInId", billInId);
                    cmd.Parameters.AddWithValue("@phoneId", phoneId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool updateBillIn(int billInId, String phoneId, double price, int quantity)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "updateBillIn";
                    cmd.Parameters.AddWithValue("@billInId", billInId);
                    cmd.Parameters.AddWithValue("@phoneId", phoneId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool deleteById(int id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "deleteBillIn";
                    cmd.Parameters.AddWithValue("@billInId", id);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool deletePhoneInDetailBillIn(int billInId, String phoneId)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "deletePhoneInDetailBillIn";
                    cmd.Parameters.AddWithValue("@billInId", billInId);
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
                String sql = "SELECT MAX([Mã hóa đơn]) AS [Mã hóa đơn max] FROM showAllBillIn";
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

        public DataTable getAllDetailBillIn(int id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT * FROM showAllDetailBillIn WHERE [Mã HĐ] = " + id;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllDetailBillIn"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable search(String billId, String nameAcount, String startDate, String endDate)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sqlSearchBillId = "";
                String sqlSearchDate = "";
                if (billId != "")
                {
                    sqlSearchBillId = " AND [Mã hóa đơn] = " + int.Parse(billId);
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
                    
                String sql = "SELECT * FROM showAllBillIn " +
                    "WHERE [Người tạo] LIKE N'%" + nameAcount + "%'" 
                            + sqlSearchBillId
                            + sqlSearchDate;
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
