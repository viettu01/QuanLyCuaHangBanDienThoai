using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDienThoai
{
    class AccountDao
    {
        String constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        //string lasttimelogin;

        public DataTable findAll()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM showAllAccount", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllAccount"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public bool insert(String role, String username, String password, String fullName, String phone, DateTime birthday)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertAccount";
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@birthday", birthday);

                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool insertDetail(int id)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertDetailAccount";
                    cmd.Parameters.AddWithValue("@id", id);

                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool update(int id, String role, String username, String password, String fullName, String phone, DateTime birthday)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "updateAccount";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@birthday", birthday);
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
                    cmd.CommandText = "deleteAccountById";
                    cmd.Parameters.AddWithValue("@id", id);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool checkExistsPhone(String phone)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from showAllAccount", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (String.Equals(rd["SĐT"].ToString(), phone, StringComparison.InvariantCultureIgnoreCase))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }

        public bool checkExistsUsername(String username)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from showAllAccount", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (String.Equals(rd["Tên đăng nhập"].ToString(), username, StringComparison.InvariantCultureIgnoreCase))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }

        public bool checkPassword(int id, String password)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from showAllAccount where [ID] = " + id, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (String.Equals(rd["Mật khẩu"].ToString(), password, StringComparison.InvariantCultureIgnoreCase))
                                return true;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return false;
        }

        public bool checkStatus(string username, String status)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from showAllAccount where [Tên đăng nhập] = N'" + username + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (String.Equals(rd["Trạng thái"].ToString(), status, StringComparison.InvariantCultureIgnoreCase))
                                return true;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return false;
        }

        public string checkLasttimeLogin(String username)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select lastloginat from tblAccount where username = N'" + username + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            //lasttimelogin = rd["lastloginat"].ToString();
                            return rd["lastloginat"].ToString();
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            //return lasttimelogin;
            return "";
        }

        public bool changePassword(int id, String password)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "UPDATE dbo.tblAccount SET password = '" + password + "' WHERE id = " + id;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool changePasswordByPhone(String phone, String password)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "UPDATE dbo.tblAccount SET password = '" + password + "' WHERE phone = " + phone;
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool changeStatus(String username, int status)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "UPDATE dbo.tblAccount SET status = " + status + " WHERE username = N'" + username + "'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public bool changeLastTimeLogin(string username)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "UPDATE dbo.tblAccount SET lastloginat = '" + DateTime.Now + "' WHERE username = N'" + username + "'";

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();

                    return i > 0;
                }
            }
        }

        public DataTable search(String role, String username, String fullName, String phone)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT * FROM showAllAccount " +
                    "WHERE [Quyền] LIKE N'%" + role + "%' " +
                        "AND [Tên đăng nhập] LIKE N'%" + username + "%' " +
                        "AND [Họ tên] LIKE N'%" + fullName + "%' " +
                        "AND [SĐT] LIKE N'%" + phone + "%' ";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllAccount"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public int login(String username, String password)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT * FROM showAllAccount WHERE [Tên đăng nhập] = N'" + username + "'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllAccount"))
                        {
                            ad.Fill(dt);
                            if (dt.Rows.Count == 0)
                                return 0; //Tên đăng nhập không tồn tại
                            else
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    //lock 1p khi đn quá 3 lần
                                    if (dr["Trạng thái"].Equals("Khóa"))
                                    {
                                        /*MessageBox.Show(DateTime.Now.AddMinutes(-1).ToString());
                                        MessageBox.Show(checkLasttimeLogin(username).ToString());*/

                                        //if (DateTime.Compare(DateTime.Now.AddMinutes(-1), DateTime.Parse(checkLasttimeLogin(username))) >= 0)
                                        //{
                                        //    changeStatus(username, 1);
                                        //    if (dr["Mật khẩu"].Equals(password))
                                        //    {
                                        //        Program.accountId = int.Parse(dr["ID"].ToString());
                                        //        Program.role = dr["Quyền"].ToString();
                                        //        Program.username = dr["Tên đăng nhập"].ToString();
                                        //        return 1; //Đúng mật khẩu và tên đăng nhập
                                        //    }
                                        //}

                                        //else
                                        //{
                                        //    TimeSpan time = DateTime.Now.Subtract(DateTime.Parse(checkLasttimeLogin(username)));
                                        //    MessageBox.Show("Bạn chờ " + time.Minutes + " phút sau để đăng nhập vào chương trình");
                                        //}
                                        return 3; //tài khoản bị khóa
                                    }
                                    else if (dr["Mật khẩu"].Equals(password))
                                    {
                                        Program.accountId = int.Parse(dr["ID"].ToString());
                                        Program.role = dr["Quyền"].ToString();
                                        Program.username = dr["Tên đăng nhập"].ToString();
                                        return 1; //Đúng mật khẩu và tên đăng nhập
                                    }
                                    else
                                        return 2; //Đúng tên dăng nhập nhưng Sai mật khẩu 
                                }
                            }
                        }
                    }
                    return -1;
                }
            }
        }

        public DataTable searchBirthday(String startYear, String endYear)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String whereSql = "";
                if (startYear != "" && endYear == "")
                {
                    whereSql = "YEAR([Ngày sinh]) >= " + startYear;
                }
                else if (startYear == "" && endYear != "")
                {
                    whereSql = "YEAR([Ngày sinh]) <= " + endYear;
                }
                else
                {
                    whereSql = "YEAR([Ngày sinh]) >= " + startYear + " AND YEAR([Ngày sinh]) <= " + endYear;
                }

                String sql = "SELECT * FROM dbo.showAllAccount WHERE " + whereSql;

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllAccount"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public int showTime(int accountId)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sql = "SELECT * FROM dbo.showAllAccount WHERE ID = " + accountId;
                //MessageBox.Show(sql);

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showAllAccount"))
                        {
                            ad.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                return int.Parse(dr["Số lần đăng nhập"].ToString());
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}
