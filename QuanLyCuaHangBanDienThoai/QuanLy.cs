using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDienThoai
{
    public partial class QuanLy : Form
    {
        PhoneDao phoneDao = new PhoneDao();
        ProducerDao producerDao = new ProducerDao();
        AccountDao accountDao = new AccountDao();
        CustomerDao customerDao = new CustomerDao();
        BillInDao billInDao = new BillInDao();
        BillOutDao billOutDao = new BillOutDao();
        int idProducer, idAccount, idCustomer, idBillIn, idBillOut;
        String namePhone, username;

        bool checkDeletePhoneBillIn = false, checkDeletePhoneBillOut = false;

        public QuanLy()
        {
            InitializeComponent();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            if (Program.role.Equals("Nhân viên"))
            {
                tabControl1.TabPages.Remove(tabAccount);
            }

            //Quản lý điện thoại
            producerDao.loadDataProducerCombox(cbHang);
            loadDataToDataGridView(dtgvDienThoai, phoneDao.findAllThanhTien());
            cbHang.Text = "";

            //Quản lý hãng sản xuất
            loadDataToDataGridView(dtgvHSX, producerDao.findAll());

            //Quản lý tài khoản
            loadDataToDataGridView(dtgvNV, accountDao.findAll());

            //Quản lý khách hàng
            loadDataToDataGridView(dtgvKH, customerDao.findAll());

            //Quản lý hóa đơn nhập
            loadDataToDataGridView(dtgvHDN, billInDao.findAll());
            loadDataIdPhoneCombox(cbMaDT);
            cbMaDT.Text = "";

            //Quản lý hóa đơn xuất
            loadDataIdPhoneCombox(cbMaDTHDX);
            loadDataToDataGridView(dtgvHDX, billOutDao.findAll());
            cbMaDTHDX.Text = "";
        }

        #region Quản lý điện thoại
        private void btnThemDT_Click(object sender, EventArgs e)
        {
            mtbMaDT.Enabled = true;
            mtbTenDT.Enabled = true;
            cbHang.Enabled = true;
            mtbGia.Enabled = true;
            mtbMau.Enabled = true;
            mtbRom.Enabled = true;
            mtbRam.Enabled = true;
            cbTGBH.Enabled = true;

            btnThemDT.Enabled = false;
            btnLuuDT.Enabled = true;
            btnLamMoiDT.Enabled = true;

            btnTimKiemDT.Visible = false;
            btnSuaDT.Visible = false;
            btnXoaDT.Visible = false;

            lbGiaMin.Visible = false;
            lbGiaMax.Visible = false;
            mtbGiaMax.Visible = false;

            btnLuuDT.Text = "Lưu";
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            if (mtbMaDT.Text == "")
            {
                mtbMaDT.Enabled = true;
            }
            else
            {
                mtbMaDT.Enabled = false;
            }

            mtbTenDT.Enabled = true;
            cbHang.Enabled = true;
            mtbGia.Enabled = true;
            mtbMau.Enabled = true;
            mtbRom.Enabled = true;
            mtbRam.Enabled = true;
            cbTGBH.Enabled = true;

            btnSuaDT.Enabled = false;
            btnLuuDT.Enabled = true;
            btnLamMoiDT.Enabled = true;

            btnTimKiemDT.Visible = false;
            btnThemDT.Visible = false;
            btnXoaDT.Visible = false;

            lbGiaMin.Visible = false;
            lbGiaMax.Visible = false;
            mtbGiaMax.Visible = false;

            btnLuuDT.Text = "Lưu";
        }

        private void btnXoaDT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (phoneDao.deleteById(mtbMaDT.Text))
                {
                    MessageBox.Show("Xóa điện thoại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLamMoiDT_Click(sender, e);
                }
                else
                    MessageBox.Show("Xóa điện thoại thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemDT_Click(object sender, EventArgs e)
        {
            mtbMaDT.Enabled = true;
            mtbTenDT.Enabled = true;
            cbHang.Enabled = true;
            mtbGia.Enabled = true;
            mtbMau.Enabled = true;
            mtbRom.Enabled = true;
            mtbRam.Enabled = true;
            cbTGBH.Enabled = true;

            btnTimKiemDT.Enabled = false;
            btnLuuDT.Enabled = true;
            btnLamMoiDT.Enabled = true;

            btnThemDT.Visible = false;
            btnSuaDT.Visible = false;
            btnXoaDT.Visible = false;

            //Tìm kiếm theo khoảng giá
            //lbGiaMin.Visible = true;
            //lbGiaMax.Visible = true;
            //mtbGiaMax.Visible = true;

            btnLuuDT.Text = "Tìm";
        }

        private void btnLamMoiDT_Click(object sender, EventArgs e)
        {
            mtbMaDT.Text = "";
            mtbTenDT.Text = "";
            mtbMau.Text = "";
            mtbRom.Text = "";
            mtbRam.Text = "";
            cbTGBH.Text = "";
            cbHang.Text = "";
            mtbGia.Text = "";

            mtbMaDT.Enabled = false;
            mtbTenDT.Enabled = false;
            cbHang.Enabled = false;
            mtbGia.Enabled = false;
            mtbMau.Enabled = false;
            mtbRom.Enabled = false;
            mtbRam.Enabled = false;
            cbTGBH.Enabled = false;

            btnTimKiemDT.Visible = true;
            btnThemDT.Visible = true;
            btnSuaDT.Visible = true;
            btnXoaDT.Visible = true;

            lbGiaMin.Visible = false;
            lbGiaMax.Visible = false;
            mtbGiaMax.Visible = false;

            btnTimKiemDT.Enabled = true;
            btnThemDT.Enabled = true;
            btnSuaDT.Enabled = true;
            btnXoaDT.Enabled = false;
            btnLuuDT.Enabled = false;
            btnLamMoiDT.Enabled = false;

            btnLuuDT.Text = "Lưu";

            errorProvider.Clear();
            QuanLy_Load(sender, e);
        }

        private void btnLuuDT_Click(object sender, EventArgs e)
        {
            String id = mtbMaDT.Text;
            String name = mtbTenDT.Text;
            String color = mtbMau.Text;
            String rom = mtbRom.Text;
            String ram = mtbRam.Text;
            String timeBH = cbTGBH.Text;

         
            if (btnTimKiemDT.Visible == true)
            {
                if (id == "" && name == "" && mtbGia.Text == "" && color == "" && rom == "" && ram == "" && timeBH == "" && cbHang.Text == "" && mtbGiaMax.Text == "")
                    MessageBox.Show("Bạn cần nhập thông tin muốn tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    loadDataToDataGridView(dtgvDienThoai, phoneDao.search(id, name, cbHang.Text, mtbGia.Text, mtbGiaMax.Text, color, rom, ram, timeBH));
            }
            else
            {
                if (id == "" || name == "" || mtbGia.Text == "" || color == "" || rom == "" || ram == "" || timeBH == "")
                    MessageBox.Show("Bạn cần nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (!double.TryParse(mtbGia.Text, out _))
                    MessageBox.Show("Giá phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (double.Parse(mtbGia.Text) <= 0)
                    MessageBox.Show("Giá sản phẩm phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    int idProducer = int.Parse(cbHang.SelectedValue.ToString());
                    double price = double.Parse(mtbGia.Text);
                    if (btnThemDT.Visible == true)
                    {
                        if (!phoneDao.checkExistsId(mtbMaDT.Text))
                        {
                            MessageBox.Show("Mã điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (phoneDao.insert(id, name, idProducer, price, color, rom, ram, timeBH))
                            {
                                MessageBox.Show("Thêm điện thoại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLamMoiDT_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Thêm điện thoại thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (btnSuaDT.Visible == true)
                    {
                        if (phoneDao.update(id, name, idProducer, price, color, rom, ram, timeBH))
                        {
                            MessageBox.Show("Sửa điện thoại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoiDT_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Sửa điện thoại thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dtgvDienThoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mtbMaDT.Text = dtgvDienThoai.CurrentRow.Cells[0].Value.ToString();
            mtbTenDT.Text = dtgvDienThoai.CurrentRow.Cells[1].Value.ToString();
            cbHang.Text = dtgvDienThoai.CurrentRow.Cells[2].Value.ToString();
            mtbGia.Text = dtgvDienThoai.CurrentRow.Cells[4].Value.ToString();
            mtbMau.Text = dtgvDienThoai.CurrentRow.Cells[5].Value.ToString();
            mtbRom.Text = dtgvDienThoai.CurrentRow.Cells[6].Value.ToString();
            mtbRam.Text = dtgvDienThoai.CurrentRow.Cells[7].Value.ToString();
            cbTGBH.Text = dtgvDienThoai.CurrentRow.Cells[8].Value.ToString();

            if (btnSuaDT.Enabled == false)
                mtbMaDT.Enabled = false;

            btnXoaDT.Enabled = true;
            btnLamMoiDT.Enabled = true;
        }

        private void mtbMaDT_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemDT.Visible != true)
            {
                if (mtbMaDT.Text == "")
                    errorProvider.SetError(mtbMaDT, "Mã điện thoại không được để trống");
                else if (!phoneDao.checkExistsId(mtbMaDT.Text))
                    errorProvider.SetError(mtbMaDT, "Mã điện thoại đã tồn tại");
                else
                    errorProvider.SetError(mtbMaDT, "");
            }
        }

        private void mtbTenDT_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemDT.Visible != true)
            {
                if (mtbTenDT.Text == "")
                    errorProvider.SetError(mtbTenDT, "Tên điện thoại không được để trống");
                else
                    errorProvider.SetError(mtbTenDT, "");
            }
        }

        private void cbHang_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemDT.Visible != true)
            {
                if (cbHang.Text == "")
                    errorProvider.SetError(cbHang, "Hãng điện thoại không được để trống");
                else
                    errorProvider.SetError(cbHang, "");
            }
        }

        private void mtbGia_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemDT.Visible != true)
            {
                if (mtbGia.Text == "")
                    errorProvider.SetError(mtbGia, "Giá điện thoại không được để trống");
                else if (!double.TryParse(mtbGia.Text, out _))
                    errorProvider.SetError(mtbGia, "Giá phải là số");
                else if (double.Parse(mtbGia.Text) <= 0)
                    errorProvider.SetError(mtbGia, "Giá sản phẩm phải lớn hơn 0");
                else
                    errorProvider.SetError(mtbGia, "");
            }
        }

        private void mtbMau_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemDT.Visible != true)
            {
                if (mtbMau.Text == "")
                    errorProvider.SetError(mtbMau, "Màu không được để trống");
                else
                    errorProvider.SetError(mtbMau, "");
            }
        }

        private void mtbRom_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemDT.Visible != true)
            {
                if (mtbRom.Text == "")
                    errorProvider.SetError(mtbRom, "Rom không được để trống");
                else
                    errorProvider.SetError(mtbRom, "");
            }
        }

        private void mtbRam_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemDT.Visible != true)
            {
                if (mtbRam.Text == "")
                    errorProvider.SetError(mtbRam, "Ram không được để trống");
                else
                    errorProvider.SetError(mtbRam, "");
            }
        }

        private void cbTGBH_Validating(object sender, CancelEventArgs e)
        {
            if (cbTGBH.Text != "")
            {
                string timeX = cbTGBH.Text;
                timeX = timeX.Trim(); //Xóa khoảng trắng đầu tiên

                //Xóa dấu cách thừa
                Regex trimmer = new Regex(@"\s\s+"); 
                timeX = trimmer.Replace(timeX, " ");
                cbTGBH.Text = timeX;

                String time = cbTGBH.Text;
                if (Regex.IsMatch(time, @"^[0-9]{1,2} +")) //Nếu chuỗi theo format 6 ... hoặc 12 ...
                {
                    string[] arr = time.Split(' '); //Cắt chuỗi có dấu cách VD: 6 tháng = ["6", "tháng"]
                    if (arr.Length == 2)
                    {
                        if (arr[1].Equals("năm") || arr[1].Equals("tháng"))
                            errorProvider1.Clear();
                        else
                            errorProvider1.SetError(cbTGBH, "Mời bạn nhập đúng định dạng  vd: 6 tháng, 1 năm");
                    }
                }
                else
                    errorProvider1.SetError(cbTGBH, "Mời bạn nhập đúng định dạng  vd: 6 tháng, 1 năm");
            }

            if (btnTimKiemDT.Visible != true)
            {
                if (cbTGBH.Text == "")
                    errorProvider.SetError(cbTGBH, "Thời gian bảo hành không được để trống");
                else
                    errorProvider.SetError(cbTGBH, "");
            }
        }
        #endregion

        #region Quản lý hãng sản xuất
        private void btnThemHSX_Click(object sender, EventArgs e)
        {
            mtbTenHSX.Enabled = true;

            btnThemHSX.Enabled = false;
            btnLuuHSX.Enabled = true;
            btnLamMoiHSX.Enabled = true;

            btnTimKiemHSX.Visible = false;
            btnSuaHSX.Visible = false;
            btnXoaHSX.Visible = false;

            btnLuuHSX.Text = "Lưu";
        }

        private void btnSuaHSX_Click(object sender, EventArgs e)
        {
            mtbTenHSX.Enabled = true;

            btnSuaHSX.Enabled = false;
            btnLuuHSX.Enabled = true;
            btnLamMoiHSX.Enabled = true;

            btnTimKiemHSX.Visible = false;
            btnThemHSX.Visible = false;
            btnXoaHSX.Visible = false;

            btnLuuHSX.Text = "Lưu";
        }

        private void btnXoaHSX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (producerDao.deleteByName(mtbTenHSX.Text))
                {
                    MessageBox.Show("Xóa hãng sản xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLamMoiHSX_Click(sender, e);
                }
                else
                    MessageBox.Show("Xóa hãng sản xuất thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemHSX_Click(object sender, EventArgs e)
        {
            mtbTenHSX.Enabled = true;

            btnTimKiemHSX.Enabled = false;
            btnLuuHSX.Enabled = true;
            btnLamMoiHSX.Enabled = true;

            btnThemHSX.Visible = false;
            btnSuaHSX.Visible = false;
            btnXoaHSX.Visible = false;

            btnLuuHSX.Text = "Tìm";
        }

        private void btnLamMoiHSX_Click(object sender, EventArgs e)
        {
            mtbTenHSX.Text = "";

            mtbTenHSX.Enabled = false;

            btnTimKiemHSX.Visible = true;
            btnThemHSX.Visible = true;
            btnSuaHSX.Visible = true;
            btnXoaHSX.Visible = true;

            btnTimKiemHSX.Enabled = true;
            btnThemHSX.Enabled = true;
            btnSuaHSX.Enabled = false;
            btnXoaHSX.Enabled = false;
            btnLuuHSX.Enabled = false;
            btnLamMoiHSX.Enabled = false;

            btnLuuHSX.Text = "Lưu";

            errorProvider.Clear();
            QuanLy_Load(sender, e);
        }

        private void btnLuuHSX_Click(object sender, EventArgs e)
        {
            String name = mtbTenHSX.Text;
            if (btnTimKiemHSX.Visible == true)
            {
                if (name == "")
                    MessageBox.Show("Bạn cần nhập tên hãng cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    loadDataToDataGridView(dtgvHSX, producerDao.search(name));
            }
            else
            {
                if (name == "")
                {
                    MessageBox.Show("Bạn cần nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (btnThemHSX.Visible == true)
                    {
                        if (!producerDao.checkExistsName(name))
                        {
                            MessageBox.Show("Hãng sản xuất đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (producerDao.insert(name))
                            {
                                MessageBox.Show("Thêm hãng sản xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLamMoiHSX_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Thêm hãng sản xuất thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (btnSuaHSX.Visible == true)
                    {
                        if (producerDao.update(idProducer, name))
                        {
                            MessageBox.Show("Sửa hãng sản xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoiHSX_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Sửa hãng sản xuất thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dtgvHSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProducer = int.Parse(dtgvHSX.CurrentRow.Cells[0].Value.ToString());
            mtbTenHSX.Text = dtgvHSX.CurrentRow.Cells[1].Value.ToString();

            btnXoaHSX.Enabled = true;
            btnSuaHSX.Enabled = true;
            btnLamMoiHSX.Enabled = true;
        }

        private void mtbTenHSX_Validating(object sender, CancelEventArgs e)
        {
            if (btnTimKiemHSX.Visible != true)
            {
                if (mtbTenHSX.Text == "")
                    errorProvider.SetError(mtbTenHSX, "Không được để trống");
                else if (!producerDao.checkExistsName(mtbTenHSX.Text))
                    errorProvider.SetError(mtbTenHSX, "Hãng sản xuất đã tồn tại");
                else
                    errorProvider.SetError(mtbTenHSX, "");
            }
        }
        #endregion

        #region Quản lý tài khoản
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            mtbHoTenNV.Enabled = true;
            dtpNgaySinhNV.Enabled = true;
            mtbSDTNV.Enabled = true;
            mtbTenDN.Enabled = true;
            mtbMK.Enabled = true;
            cbQuyen.Enabled = true;

            btnThemNV.Enabled = false;
            btnLuuNV.Enabled = true;
            btnLamMoiNV.Enabled = true;

            btnTimKiemNV.Visible = false;
            btnSuaNV.Visible = false;
            btnXoaNV.Visible = false;
            btnMoK.Visible = false;
            btnLuuNV.Text = "Lưu";
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            mtbHoTenNV.Enabled = true;
            dtpNgaySinhNV.Enabled = true;
            mtbSDTNV.Enabled = true;
            mtbTenDN.Enabled = true;
            mtbMK.Enabled = true;
            cbQuyen.Enabled = true;

            btnSuaNV.Enabled = false;
            btnLuuNV.Enabled = true;
            btnLamMoiNV.Enabled = true;

            btnTimKiemNV.Visible = false;
            btnThemNV.Visible = false;
            btnXoaNV.Visible = false;
            if (username != Program.username)
            {
                btnMoK.Visible = true;
            }
            btnLuuDT.Text = "Lưu";
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (accountDao.deleteById(idAccount))
                {
                    MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLamMoiNV_Click(sender, e);
                }
                else
                    MessageBox.Show("Xóa tài khoản thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            mtbHoTenNV.Enabled = true;
            mtbSDTNV.Enabled = true;
            mtbTenDN.Enabled = true;
            cbQuyen.Enabled = true;

            btnTimKiemNV.Enabled = false;
            btnLuuNV.Enabled = true;
            btnLamMoiNV.Enabled = true;

            btnThemNV.Visible = false;
            btnSuaNV.Visible = false;
            btnXoaNV.Visible = false;

            btnLuuNV.Text = "Tìm";
            btnMoK.Visible = false;
        }

        private void btnTimKiemNamSinh_Click(object sender, EventArgs e)
        {
            loadDataToDataGridView(dtgvNV, accountDao.searchBirthday(tbStartYear.Text, tbEndYear.Text));
        }

        private void btnLamMoiNV_Click(object sender, EventArgs e)
        {
            mtbHoTenNV.Text = "";
            mtbSDTNV.Text = "";
            dtpNgaySinhNV.CustomFormat = " ";
            mtbTenDN.Text = "";
            mtbMK.Text = "";
            cbQuyen.Text = "";

            mtbHoTenNV.Enabled = false;
            dtpNgaySinhNV.Enabled = false;
            mtbSDTNV.Enabled = false;
            mtbTenDN.Enabled = false;
            mtbMK.Enabled = false;
            cbQuyen.Enabled = false;

            btnTimKiemNV.Visible = true;
            btnThemNV.Visible = true;
            btnSuaNV.Visible = true;
            btnXoaNV.Visible = true;

            btnTimKiemNV.Enabled = true;
            btnThemNV.Enabled = true;
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            btnLuuNV.Enabled = false;
            btnLamMoiNV.Enabled = false;
            btnMoK.Visible = false;
            btnLuuNV.Text = "Lưu";

            errorProvider.Clear();
            QuanLy_Load(sender, e);
        }

        private void mtbTenDN_TextChanged(object sender, EventArgs e)
        {
            if (accountDao.checkStatus(mtbTenDN.Text, "Bình thường"))
                btnMoK.Text = "Khóa";
            else
                btnMoK.Text = "Mở khóa";
        }

        private void btnMoK_Click(object sender, EventArgs e)
        {
            if (btnMoK.Text == "Khóa")
                accountDao.changeStatus(mtbTenDN.Text, 0);
            else
                accountDao.changeStatus(mtbTenDN.Text, 1);

            QuanLy_Load(sender, e);
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            String fullName = mtbHoTenNV.Text;
            String birthday = dtpNgaySinhNV.Value.Date.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            String phone = mtbSDTNV.Text;
            String username = mtbTenDN.Text;
            String password = mtbMK.Text;
            String role = cbQuyen.Text;
            if (btnTimKiemNV.Visible == true)
            {
                if (fullName == "" && phone == "" && username == "" && password == "" && role == "" && dtpNgaySinhNV.Text == " ")
                    MessageBox.Show("Bạn cần nhập thông tin muốn tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //MessageBox.Show(DateTime.Parse(dtpNgaySinhNV.Text).ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("en-US")));
                    loadDataToDataGridView(dtgvNV, accountDao.search(role, username, fullName, phone));
                }
            }
            else
            {
                if (fullName == "" || phone == "" || username == "" || password == "" || role == "")
                    MessageBox.Show("Bạn cần nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (!double.TryParse(phone, out _))
                    MessageBox.Show("Số điện thoại phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (phone.Length < 10 || phone.Length > 10)
                    MessageBox.Show("Số điện thoại phải đủ 12 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (btnThemNV.Visible == true)
                    {
                        if (!accountDao.checkExistsPhone(phone))
                            MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!accountDao.checkExistsUsername(username))
                            MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            if (accountDao.insert(role, username, password, fullName, phone, DateTime.Parse(birthday)))
                            {
                                MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLamMoiNV_Click(sender, e);
                            }
                            else
                                MessageBox.Show("Thêm tài khoản thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (btnSuaNV.Visible == true)
                    {
                        if (accountDao.update(idAccount, role, username, password, fullName, phone, DateTime.Parse(birthday)))
                        {
                            MessageBox.Show("Sửa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoiNV_Click(sender, e);
                        }
                        else
                            MessageBox.Show("Sửa tài khoản thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idAccount = int.Parse(dtgvNV.CurrentRow.Cells[0].Value.ToString());
            cbQuyen.Text = dtgvNV.CurrentRow.Cells[1].Value.ToString();
            mtbTenDN.Text = dtgvNV.CurrentRow.Cells[2].Value.ToString();
            username = dtgvNV.CurrentRow.Cells[2].Value.ToString();
            mtbMK.Text = dtgvNV.CurrentRow.Cells[3].Value.ToString();
            mtbHoTenNV.Text = dtgvNV.CurrentRow.Cells[4].Value.ToString();
            mtbSDTNV.Text = dtgvNV.CurrentRow.Cells[5].Value.ToString();

            if (dtgvNV.CurrentRow.Cells[6].Value.ToString() != "")
                dtpNgaySinhNV.Value = DateTime.Parse(dtgvNV.CurrentRow.Cells[6].Value.ToString());
            else
                dtpNgaySinhNV.CustomFormat = " ";

            btnXoaNV.Enabled = true;
            btnSuaNV.Enabled = true;
            btnLamMoiNV.Enabled = true;
        }

        private void dtpNgaySinhNV_ValueChanged(object sender, EventArgs e)
        {
            dtpNgaySinhNV.CustomFormat = "dd/MM/yyyy";
        }
        #endregion

        #region Quản lý khách hàng
        public void btnThemKH_Click(object sender, EventArgs e)
        {
            mtbHoTenKH.Enabled = true;
            mtbSDTKH.Enabled = true;

            btnThemKH.Enabled = false;
            btnLuuKH.Enabled = true;
            btnLamMoiKH.Enabled = true;

            btnTimKiemKH.Visible = false;
            btnSuaKH.Visible = false;
            btnXoaKH.Visible = false;

            btnLuuKH.Text = "Lưu";
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            mtbHoTenKH.Enabled = true;
            mtbSDTKH.Enabled = true;

            btnSuaKH.Enabled = false;
            btnLuuKH.Enabled = true;
            btnLamMoiKH.Enabled = true;

            btnTimKiemKH.Visible = false;
            btnThemKH.Visible = false;
            btnXoaKH.Visible = false;

            btnLuuKH.Text = "Lưu";
           
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (customerDao.deleteById(idCustomer))
                {
                    MessageBox.Show("Xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLamMoiKH_Click(sender, e);
                }
                else
                    MessageBox.Show("Xóa khách hàng thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            mtbHoTenKH.Enabled = true;
            mtbSDTKH.Enabled = true;

            btnTimKiemKH.Enabled = false;
            btnLuuKH.Enabled = true;
            btnLamMoiKH.Enabled = true;

            btnThemKH.Visible = false;
            btnSuaKH.Visible = false;
            btnXoaKH.Visible = false;

            btnLuuKH.Text = "Tìm";
        }

        private void btnLamMoiKH_Click(object sender, EventArgs e)
        {
            mtbHoTenKH.Text = "";
            mtbSDTKH.Text = "";

            mtbHoTenKH.Enabled = false;
            mtbSDTKH.Enabled = false;

            btnTimKiemKH.Visible = true;
            btnThemKH.Visible = true;
            btnSuaKH.Visible = true;
            btnXoaKH.Visible = true;

            btnTimKiemKH.Enabled = true;
            btnThemKH.Enabled = true;
            btnSuaKH.Enabled = false;
            btnXoaKH.Enabled = false;
            btnLuuKH.Enabled = false;
            btnLamMoiKH.Enabled = false;

            btnLuuKH.Text = "Lưu";

            errorProvider.Clear();
            QuanLy_Load(sender, e);
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            String name = mtbHoTenKH.Text;
            String phone = mtbSDTKH.Text;
            if (btnTimKiemKH.Visible == true)
            {
                if (name == "" && phone == "")
                    MessageBox.Show("Bạn cần nhập thông tin muốn tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    loadDataToDataGridView(dtgvKH, customerDao.search(name, phone));
            }
            else
            {
                if (name == "" || phone == "")
                    MessageBox.Show("Bạn cần nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if(!double.TryParse(phone, out _))
                    MessageBox.Show("Giá trị nhập vào phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (phone.IndexOf("0") != 0)
                    MessageBox.Show("Ký tự đầu tiên phải là số 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (phone.Length < 10 || phone.Length > 10)
                    MessageBox.Show("Số điện thoại cần đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (btnThemKH.Visible == true)
                    {
                        if (!customerDao.checkExistsPhone(phone))
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (customerDao.insert(name, phone))
                            {
                                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLamMoiNV_Click(sender, e);
                            }
                            else
                                MessageBox.Show("Thêm khách hàng thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (btnSuaKH.Visible == true)
                    {
                        if (customerDao.update(idCustomer, name, phone))
                        {
                            MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoiNV_Click(sender, e);
                        }
                        else
                            MessageBox.Show("Sửa khách hàng thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCustomer = int.Parse(dtgvKH.CurrentRow.Cells[0].Value.ToString());
            mtbHoTenKH.Text = dtgvKH.CurrentRow.Cells[1].Value.ToString();
            mtbSDTKH.Text = dtgvKH.CurrentRow.Cells[2].Value.ToString();

            btnXoaKH.Enabled = true;
            btnSuaKH.Enabled = true;
            btnLamMoiKH.Enabled = true;
        }
        #endregion

        #region Quản lý hóa đơn nhập
        private void cbMaDT_TextChanged(object sender, EventArgs e)
        {
            String dacDiem = "", giaNhap = "";
            if (cbMaDT.Text == "")
            {
                tbDacDiem.Text = "";
                tbGiaNhap.Text = "";
                nudSoLuong.Value = 1;
            }
            else
            {
                DataTable dt = phoneDao.searchById(cbMaDT.Text);
                DataView v = new DataView(dt);

                foreach (DataRowView r in v)
                {
                    namePhone = r["Tên ĐT"].ToString();
                    dacDiem = namePhone + "/" + r["Màu"] + "/" + r["Rom"] + "/" + r["Ram"];
                    giaNhap = r["Giá"].ToString();
                }
                tbDacDiem.Text = dacDiem;
                tbGiaNhap.Text = giaNhap;
            }
        }

        private void cbMaDT_Validating(object sender, CancelEventArgs e)
        {
            DataTable dt = phoneDao.searchById(cbMaDT.Text);
            DataView v = new DataView(dt);
            String namePhone = "";

            foreach (DataRowView r in v)
            {
                namePhone = r["Tên ĐT"].ToString();
            }

            if (namePhone == "")
            {
                DialogResult dialogResult = MessageBox.Show("Điện thoại chưa có trong danh sách. Mời bạn thêm mới.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    tabControl1.SelectedIndex = 0;
                    mtbMaDT.Text = cbMaDT.Text;
                    btnThemDT_Click(sender, e);
                }
            }
        }

        private void btnThemDTC_Click(object sender, EventArgs e)
        {
            if (dtgvDSDTC.Rows.Count != 1)
            {
                for (int rows = 0; rows < dtgvDSDTC.Rows.Count - 1; rows++)
                {
                    if (dtgvDSDTC.Rows[rows].Cells[0].Value.ToString().Equals(cbMaDT.Text))
                    {
                        int sl = int.Parse(dtgvDSDTC.Rows[rows].Cells[2].Value.ToString());
                        sl = sl + int.Parse(nudSoLuong.Value.ToString());
                        dtgvDSDTC.Rows[rows].Cells[2].Value = sl.ToString();
                        return;
                    }
                }
            }
            String[] row = new string[] { cbMaDT.Text, namePhone, nudSoLuong.Value.ToString(), tbGiaNhap.Text };
            dtgvDSDTC.Rows.Add(row);

            //Tạo nut delete sản phẩm trong bảng chờ
            //for (int i = 0; i < dtgvDSDTC.Rows.Count - 1; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    dtgvDSDTC[4, i] = linkCell;
            //    dtgvDSDTC[4, i].Value = "Delete";
            //}

            //dtgvDSDTC.Rows[e.RowIndex].Cells[4].Value = "Delete";
        }

        //Hàm thực hiện chức năng xóa sản phẩm
        private void dtgvDSDTC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string Task = dtgvDSDTC.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (Task == "Delete")
                {
                    if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (checkDeletePhoneBillIn)
                        {
                            billInDao.deletePhoneInDetailBillIn(idBillIn, dtgvDSDTC.Rows[e.RowIndex].Cells[0].Value.ToString());
                        }
                        int rowIndex = e.RowIndex;
                        dtgvDSDTC.Rows.RemoveAt(rowIndex);
                    }
                }
            }
        }

        private void btnThemHDN_Click(object sender, EventArgs e)
        {
            dtgvDSDTC.Rows.Clear();

            cbMaDT.Enabled = true;
            tbGiaNhap.Enabled = true;
            nudSoLuong.Enabled = true;

            btnThemDTC.Enabled = true;
            btnLuuHDN.Enabled = true;
            btnLamMoiHDN.Enabled = true;

            btnThemHDN.Enabled = false;

            btnTimKiemHDN.Visible = false;
            //btnSuaHDN.Visible = false;
            btnXoaHDN.Visible = false;

            btnLuuHDN.Text = "Lưu";
        }

        private void btnSuaHDN_Click(object sender, EventArgs e)
        {
            cbMaDT.Enabled = true;
            tbGiaNhap.Enabled = true;
            nudSoLuong.Enabled = true;

            btnThemDTC.Enabled = true;
            btnLuuHDN.Enabled = true;
            btnLamMoiHDN.Enabled = true;

            btnThemHDN.Enabled = false;
            //btnSuaHDN.Enabled = false;

            btnTimKiemHDN.Visible = false;
            btnThemHDN.Visible = false;
            btnXoaHDN.Visible = false;

            btnLuuHDN.Text = "Lưu";
        }

        private void btnTimKiemHDN_Click(object sender, EventArgs e)
        {
            tbMaHDN.Enabled = true;
            tbTenNVHDN.Enabled = true;
            dtpNgayBDHDN.Enabled = true;
            dtpNgayKTHDN.Enabled = true;

            btnTimKiemHDN.Enabled = false;
            btnLuuHDN.Enabled = true;
            btnLamMoiHDN.Enabled = true;

            //btnSuaHDN.Visible = false;
            btnThemHDN.Visible = false;
            btnXoaHDN.Visible = false;

            btnLuuHDN.Text = "Tìm";
        }

        private void btnLuuHDN_Click(object sender, EventArgs e)
        {
            if (btnTimKiemHDN.Visible == true)
            {
                String billId = tbMaHDN.Text;
                String nameAccount = tbTenNVHDN.Text;
                String startDate = dtpNgayBDHDN.Value.Date.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                String endDate = dtpNgayKTHDN.Value.Date.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                if (dtpNgayBDHDN.Text == " " && dtpNgayKTHDN.Text != " ")
                {
                    startDate = "";
                }

                if (dtpNgayBDHDN.Text == " " && dtpNgayKTHDN.Text == " ")
                {
                    startDate = "";
                    endDate = "";
                }

                if (billId == "" && nameAccount == "" && dtpNgayBDHDN.Text == " " && dtpNgayKTHDN.Text == " ")
                    MessageBox.Show("Bạn cần nhập thông tin muốn tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    loadDataToDataGridView(dtgvHDN, billInDao.search(billId, nameAccount, startDate, endDate));
            }
            else
            {
                if (btnThemHDN.Visible == true)
                {
                    if (dtgvDSDTC.Rows.Count <= 1)
                        MessageBox.Show("Bạn chưa thêm sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        bool check = false;
                        billInDao.insertBillIn(Program.accountId);

                        for (int rows = 0; rows < dtgvDSDTC.Rows.Count - 1; rows++)
                        {
                            String phoneId = dtgvDSDTC.Rows[rows].Cells[0].Value.ToString();
                            int quantity = int.Parse(dtgvDSDTC.Rows[rows].Cells[2].Value.ToString());
                            double price = double.Parse(dtgvDSDTC.Rows[rows].Cells[3].Value.ToString());

                            check = billInDao.insertDetailBillIn(billInDao.getIdMax(), phoneId, price, quantity);
                        }

                        if (check)
                            MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Sủa số lượng hoặc đơn giá của sản phẩm trong chi tiết hóa đơn
                //else if (btnSuaHDN.Visible == true)
                //{
                //    bool check = false;

                //    for (int rows = 0; rows < dtgvDSDTC.Rows.Count - 1; rows++)
                //    {
                //        String phoneId = dtgvDSDTC.Rows[rows].Cells[0].Value.ToString();
                //        int quantity = int.Parse(dtgvDSDTC.Rows[rows].Cells[2].Value.ToString());
                //        double price = double.Parse(dtgvDSDTC.Rows[rows].Cells[3].Value.ToString());

                //        check = billInDao.updateBillIn(idBillIn, phoneId, price, quantity);
                //    }

                //    if (check)
                //        MessageBox.Show("Sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                QuanLy_Load(sender, e);
            }
        }

        private void btnLamMoiHDN_Click(object sender, EventArgs e)
        {
            dtgvDSDTC.Rows.Clear();

            cbMaDT.Text = " ";
            tbDacDiem.Text = "";
            tbGiaNhap.Text = "";
            nudSoLuong.Value = 1;
            dtpNgayBDHDN.CustomFormat = " ";
            dtpNgayKTHDN.CustomFormat = " ";

            cbMaDT.Enabled = false;
            tbGiaNhap.Enabled = false;
            nudSoLuong.Enabled = false;
            btnThemDTC.Enabled = false;

            tbMaHDN.Enabled = false;
            tbTenNVHDN.Enabled = false;
            dtpNgayBDHDN.Enabled = false;
            dtpNgayKTHDN.Enabled = false;

            btnTimKiemHDN.Visible = true;
            btnThemHDN.Visible = true;
            //btnSuaHDN.Visible = true;
            btnXoaHDN.Visible = true;

            btnTimKiemHDN.Enabled = true;
            btnThemHDN.Enabled = true;
            //btnSuaHDN.Enabled = false;
            btnXoaHDN.Enabled = false;
            btnLuuHDN.Enabled = false;
            btnLamMoiHDN.Enabled = false;

            btnLuuHDN.Text = "Lưu";

            checkDeletePhoneBillIn = false;

            errorProvider.Clear();
            QuanLy_Load(sender, e);
        }

        private void btnXoaHDN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (billInDao.deleteById(idBillIn))
                {
                    MessageBox.Show("Xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLamMoiHDN_Click(sender, e);
                }
                else
                    MessageBox.Show("Xóa hóa đơn thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpNgayBDHDN_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayBDHDN.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpNgayKTHDN_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayKTHDN.CustomFormat = "dd/MM/yyyy";
        }
        
        private void dtgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idBillIn = int.Parse(dtgvHDN.CurrentRow.Cells[0].Value.ToString());
            dtgvDSDTC.Rows.Clear();
            foreach (DataRow dr in billInDao.getAllDetailBillIn(idBillIn).Rows)
            {
                string idPhone = dr["Mã ĐT"].ToString();
                string namePhone = dr["Tên ĐT"].ToString();
                string quantity = dr["Số lượng"].ToString();
                string price = dr["Giá"].ToString();

                String[] row = new string[] { idPhone, namePhone, quantity, price };
                dtgvDSDTC.Rows.Add(row);
            }

            //Tạo nut delete xóa sản phẩm trong chi tiết hóa đơn
            //for (int i = 0; i < billInDao.getAllDetailBillIn(idBillIn).Rows.Count; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    dtgvDSDTC[4, i] = linkCell;
            //    dtgvDSDTC[4, i].Value = "Delete";
            //}

            checkDeletePhoneBillIn = true;

            btnLamMoiHDN.Enabled = true;
            btnXoaHDN.Enabled = true;
            //btnSuaHDN.Enabled = true;
        }
        #endregion

        #region Quản lý hóa đơn xuất
        private void dtgvDTHDX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                string Task = dtgvDTHDX.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (Task == "Delete")
                {
                    if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (checkDeletePhoneBillOut)
                        {
                            billOutDao.deletePhoneInDetailBillOut(idBillOut, dtgvDTHDX.Rows[e.RowIndex].Cells[0].Value.ToString());
                        }
                        int rowIndex = e.RowIndex;
                        dtgvDTHDX.Rows.RemoveAt(rowIndex);
                    }
                }
            }
        }

        private void dtgvHDX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idBillOut = int.Parse(dtgvHDX.CurrentRow.Cells[0].Value.ToString());
            dtgvDTHDX.Rows.Clear();
            foreach (DataRow dr in billOutDao.getAllDetailBillOut(idBillOut).Rows)
            {
                string idPhone = dr["Mã ĐT"].ToString();
                string namePhone = dr["Tên ĐT"].ToString();
                string quantity = dr["Số lượng"].ToString();
                string price = dr["Đơn giá"].ToString();
                string total = dr["Thành tiền"].ToString();
                string time = dr["Hạn bảo hành"].ToString();

                String[] row = new string[] { idPhone, namePhone, quantity, price , total, time};
                dtgvDTHDX.Rows.Add(row);
            }

            //Tạo nút delete xóa sản phẩm trong chi tiết hóa đơn xuất
            //for (int i = 0; i < billOutDao.getAllDetailBillOut(idBillOut).Rows.Count; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    dtgvDTHDX[6, i] = linkCell;
            //    dtgvDTHDX[6, i].Value = "Delete";
            //}

            checkDeletePhoneBillOut = true;

            btnXoaHDX.Enabled = true;
            btnLamMoiHDX.Enabled = true;
            cbMaDTHDX.Enabled = true;
            tbTenDTHDX.Enabled = true;
            btnTimKiemDTHDX.Enabled = true;
        }

        private void btnLamMoiHDX_Click(object sender, EventArgs e)
        {
            dtgvDTHDX.Rows.Clear();

            cbMaDTHDX.Text = " ";
            tbTenDTHDX.Text = "";
            dtpNgayBDHDX.CustomFormat = " ";
            dtpNgayKTHDX.CustomFormat = " ";

            cbMaDTHDX.Enabled = false;
            tbTenDTHDX.Enabled = false;
            btnTimKiemDTHDX.Enabled = false;


            tbMaHDX.Enabled = false;
            tbTenNVHDX.Enabled = false;
            dtpNgayBDHDX.Enabled = false;
            dtpNgayKTHDX.Enabled = false;

            btnTimKiemHDX.Visible = true;
            btnXoaHDX.Visible = true;

            btnTimKiemHDX.Enabled = true;
            btnXoaHDX.Enabled = false;
            btnLuuHDX.Enabled = false;
            btnLamMoiHDX.Enabled = false;

            btnLuuHDX.Text = "Lưu";

            checkDeletePhoneBillOut = false;

            QuanLy_Load(sender, e);
        }

        private void btnXoaHDX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (billOutDao.deleteById(idBillOut))
                {
                    MessageBox.Show("Xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLamMoiHDX_Click(sender, e);
                }
                else
                    MessageBox.Show("Xóa hóa đơn thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemDTHDX_Click(object sender, EventArgs e)
        {
            String phoneId = cbMaDTHDX.Text;
            String phoneName = tbTenDTHDX.Text;
            int dem = 0;
            dtgvDTHDX.Rows.Clear();
            foreach (DataRow dr in billOutDao.searchPhoneInBillOut(idBillOut, phoneId, phoneName).Rows)
            {
                string idPhone = dr["Mã ĐT"].ToString();
                string namePhone = dr["Tên ĐT"].ToString();
                string quantity = dr["Số lượng"].ToString();
                string price = dr["Đơn giá"].ToString();
                string total = dr["Thành tiền"].ToString();
                string time = dr["Hạn bảo hành"].ToString();
                dem++;
                String[] row = new string[] { idPhone, namePhone, quantity, price, total, time };
                dtgvDTHDX.Rows.Add(row);
            }
            if (dem == 0)
            {
                MessageBox.Show("Điện thoại không có trong hóa đơn");
            }
        }

        private void btnTimKiemHDX_Click(object sender, EventArgs e)
        {
            tbMaHDX.Enabled = true;
            tbTenNVHDX.Enabled = true;
            dtpNgayBDHDX.Enabled = true;
            dtpNgayKTHDX.Enabled = true;

            btnTimKiemHDX.Enabled = false;
            btnLuuHDX.Enabled = true;
            btnLamMoiHDX.Enabled = true;

            btnXoaHDX.Visible = false;

            btnLuuHDX.Text = "Tìm";
        }

        private void btnLuuHDX_Click(object sender, EventArgs e)
        {
            if (btnTimKiemHDX.Visible == true)
            {
                String billId = tbMaHDX.Text;
                String nameAccount = tbTenNVHDX.Text;
                String startDate = dtpNgayBDHDX.Value.Date.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                String endDate = dtpNgayKTHDX.Value.Date.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                if (dtpNgayBDHDX.Text == " " && dtpNgayKTHDX.Text != " ")
                {
                    startDate = "";
                }

                if (dtpNgayBDHDX.Text == " " && dtpNgayKTHDX.Text == " ")
                {
                    startDate = "";
                    endDate = "";
                }

                if (billId == "" && nameAccount == "" && dtpNgayBDHDX.Text == " " && dtpNgayKTHDX.Text == " ")
                    MessageBox.Show("Bạn cần nhập thông tin muốn tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    loadDataToDataGridView(dtgvHDX, billOutDao.search(billId, nameAccount, startDate, endDate));
            }
        }

        private void dtpNgayBDHDX_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayBDHDX.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpNgayKTHDX_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayKTHDX.CustomFormat = "dd/MM/yyyy";
        }
        #endregion

        //Load data
        private void loadDataToDataGridView(DataGridView dtgv, DataTable dt)
        {
            dtgv.DataSource = dt;
            dtgv.AutoResizeColumns();
        }

        public void loadDataIdPhoneCombox(ComboBox cb)
        {
            DataTable dt = phoneDao.findAll();
            DataView v = new DataView(dt);
            v.Sort = "Mã ĐT";

            cb.DataSource = v;
            cb.DisplayMember = "Mã ĐT";
            cb.ValueMember = "Mã ĐT";
        }
    }
}
