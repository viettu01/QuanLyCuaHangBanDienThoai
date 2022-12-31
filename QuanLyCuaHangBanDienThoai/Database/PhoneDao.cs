using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangBanDienThoai
{
    class PhoneDao
    {
        String constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public DataTable findAllThanhTien()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vv_HienThiHoaDonThanhTien", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("vv_HienThiHoaDonThanhTien"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable findAll()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM showAllPhone", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllPhone"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public bool checkExistsId(String id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from showAllPhone", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (String.Equals(rd["Mã ĐT"].ToString(), id, StringComparison.InvariantCultureIgnoreCase))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }

        public bool insert(String id, String name, int idProducer, double price,
                                 String color, String rom, String ram, String timeBH)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertPhone";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@idProducer", idProducer);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@rom", rom);
                    cmd.Parameters.AddWithValue("@ram", ram);
                    cmd.Parameters.AddWithValue("@timeBH", timeBH);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool update(String id, String name, int idProducer, double price,
                                 String color, String rom, String ram, String timeBH)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "updatePhone";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@idProducer", idProducer);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@rom", rom);
                    cmd.Parameters.AddWithValue("@ram", ram);
                    cmd.Parameters.AddWithValue("@timeBH", timeBH);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool deleteById(String id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "deletePhoneById";
                    cmd.Parameters.AddWithValue("@id", id);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public DataTable search(String id, String name, String producer, String priceMin, String priceMax,
                                String color, String rom, String ram, String timeBH)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sqlSearchPrice = "";
                if (priceMin != "" && priceMax != "")
                {
                    sqlSearchPrice = "AND [Giá] >= " + double.Parse(priceMin) + " AND [Giá] <= " + double.Parse(priceMax) + " ";
                } 
                else if (priceMin != "")
                {
                    sqlSearchPrice = "AND [Giá] >= " + double.Parse(priceMin) + " ";
                }
                else if (priceMax != "")
                {
                    sqlSearchPrice = "AND [Giá] <= " + double.Parse(priceMax) + " ";
                }
                String sql = "SELECT * FROM showAllPhone " +
                    "WHERE [Mã ĐT] LIKE N'%" + id + "%' " +
                        "AND [Tên ĐT] LIKE N'%" + name + "%' " +
                        "AND [Hãng] LIKE N'%" + producer + "%' " +
                        sqlSearchPrice +
                        "AND [Màu] LIKE N'%" + color + "%' " +
                        "AND [Rom] LIKE N'%" + rom + "%' " +
                        "AND [Ram] LIKE N'%" + ram + "%' " +
                        "AND [Thời gian BH] LIKE N'%" + timeBH + "%' ";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllPhone"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable searchById(String id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT * FROM showAllPhone WHERE [Mã ĐT] LIKE N'" + id + "' ";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllPhone"))
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
