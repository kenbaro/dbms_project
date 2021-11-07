using iTextSharp.text;
using iTextSharp.text.pdf;
using Res_ManagementSystem.BUS;
using Res_ManagementSystem.DAO;
using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Res_ManagementSystem.GUI
{
    public partial class Res_Management : Form
    {
        public Res_Management()
        {
            InitializeComponent();
            tab_Res.SelectedIndexChanged += new EventHandler(tab_Res_SelectedIndexChanged);
        }
        private NhanVienDTO _nv = new NhanVienDTO();
        public NhanVienDTO Nv
        {
            get { return _nv; }
            set { _nv = value; }
        }
/*        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }*/

        private void Res_Management_Load(object sender, EventArgs e)
        {


            DuaLoaiThucDonLenCombobox();
            DuaDSHoaDonLenDataGridView();
            DuaBanLenCombobox();
            DuaDSNhanVienLenCombobox();
            DuaDSNhanVienLenDataGridView();
            DuaDSBanDagoiLenCombobox();
            DuaDanhSachPhanCongLenDataGridView();
            LoadNhanVienPhanCongLenCombobox();
            LoadThongTinNguoiDung();
            DuaBanPhanCongLenCombobox();
            DuaLoaiTDLenCombobox();
            dtiNgaySinh.MaxDate = DateTime.Today;
            dtiNgayAD.MaxDate = DateTime.Today;



        }

        public void DuaBanPhanCongLenCombobox()
        {
            List<BanDTO> dt = new List<BanDTO>();
            dt = BanBUS.LayDSBan();
            cmbBanPC.DataSource = dt;
            cmbBanPC.DisplayMember = "MaBan";
            cmbBanPC.ValueMember = "MaBan";
        }
        public void LoadNhanVienPhanCongLenCombobox()
        {
            DataTable dt = NhanVienBUS.LayDSNhanVienTiepTan();
            cmbNhanVienPC.DataSource = dt;
            cmbNhanVienPC.DisplayMember = "Họ Tên";
            cmbNhanVienPC.ValueMember = "Mã NV";
        }
        public void DuaDanhSachPhanCongLenDataGridView()
        {
            DataTable dt = PhanCongBUS.LayDSPhanCong();
            dgvDSPhanCong.DataSource = dt;
        }
        public void DuaDSBanDagoiLenCombobox()
        {
            cmB_DSBanCanLHD.Items.Clear();
            cmb_chonbanCN.Items.Clear();
            cmB_DSBanCanLHD.Text = "";
            cmb_chonbanCN.Text = "";
            List<int> _dsMaBan = HoaDonBUS.LayDSBanChuaThanhToan();
            for (int i = 0; i < _dsMaBan.Count; i++)
            {
                cmB_DSBanCanLHD.Items.Add(_dsMaBan[i].ToString());
                cmb_chonbanCN.Items.Add(_dsMaBan[i].ToString());
            }
        }
        public void DuaBanLenCombobox()
        {
            List<BanDTO> _dsban = BanBUS.LayDSBan();
            List<int> _dsBanDaDat = HoaDonBUS.LayDSBanChuaThanhToan();
            List<int> _dsTam = new List<int>();
            for (int i = 0; i < _dsban.Count; i++)
            {
                bool flag = false;
                for (int j = 0; j < _dsBanDaDat.Count; j++)
                {
                    if (_dsban[i].MaBan == _dsBanDaDat[j])
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    _dsTam.Add(int.Parse(_dsban[i].MaBan.ToString()));
                }
            }
            cmB_ChonBan.DataSource = _dsTam;
        }

        private void tab_Res_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
   

        private void LoadThongTinNguoiDung()
        {
            TenDN.Text = Nv.TenDN.ToString();
            hoTen.Text = Nv.HoTen.ToString();
            quyen.Text = Nv.Quyen.ToString();
        }

        public void DuaLoaiThucDonLenCombobox()
        {
            List<LoaiThucDonDTO> _dsltd = LoaiThucDonBUS.LayDSLoaiThucDon();
            cmb_LoaiThucDon.DataSource = _dsltd;
            cmb_LoaiThucDon.DisplayMember = "TenLoai";
            cmb_LoaiThucDon.ValueMember = "MaLoai";

            cmB_loaitdCNGM.DataSource = _dsltd;
            cmB_loaitdCNGM.DisplayMember = "TenLoai";
            cmB_loaitdCNGM.ValueMember = "MaLoai";

            cmB_loaitdTD.DataSource = _dsltd;
            cmB_loaitdTD.DisplayMember = "TenLoai";
            cmB_loaitdTD.ValueMember = "MaLoai";
        }

        public void DuaLoaiTDLenCombobox()
        {
            List<LoaiThucDonDTO> _dsltd = LoaiThucDonBUS.LayDSLoaiThucDon();
            cmB_loaitd_TD.DataSource = _dsltd;
            cmB_loaitd_TD.DisplayMember = "TenLoai";
            cmB_loaitd_TD.ValueMember = "MaLoai";

        }

        public void DuaDSNhanVienLenCombobox()
        {
            DataTable _dsNV = NhanVienBUS.LayDSNhanVienTiepTan();
            cmB_nguoilhdLHD.DataSource = _dsNV;
            cmB_nguoilhdLHD.DisplayMember = "Họ Tên";
            cmB_nguoilhdLHD.ValueMember = "Mã NV";
        }

        public void DuaDSHoaDonLenDataGridView()
        {
            DataTable _dshd = HoaDonBUS.LayDSHoaDon();
            dgv_dshdQLHD.DataSource = _dshd;
        }
        public void DuaDSNhanVienLenDataGridView()
        {
            DataTable _dsnd = NhanVienBUS.LayDSNhanVien();
            dgv_NhanVien.DataSource = _dsnd;
        }

        /*------------------------------------------------Nhân Viên-----------------------------------------------*/
        public void ThemNhanVien()
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.HoTen = tbx_DisplName.Text;
            nv.NgaySinh = DateTime.Parse(dtiNgaySinh.Text);
            nv.TenDN = tbx_User.Text;
            nv.MatKhau = tbx_Pass.Text;
            nv.Quyen = cmB_Type.Text;
            if (!NhanVienBUS.KiemTraTenDNTonTai(nv.TenDN, nv.MaNV))
            {
                bool kq = NhanVienBUS.ThemNhanVien(nv);
                if (kq == true)
                {
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DuaDSNhanVienLenDataGridView();
                    tbx_User.Text = "";
                    tbx_Pass.Text = "";
                    tbx_Repass.Text = "";
                    tbx_DisplName.Text = "";
                    cmB_Type.Text = "Tiếp Tân";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Tên đăng nhập này đã tồn tại!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
                ThemNhanVien();
            else
                MessageBox.Show("Chỉ có Quản Lý mới được sử dụng chức năng này","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private bool verify()
        {
            if (tbx_User.Text == "" || tbx_Pass.Text == "" || tbx_Repass.Text == "" || tbx_DisplName.Text == ""||cmB_Type.Text=="")
            {
                return false;
            }
            else return true;
        }
        private void btn_DSNV_Click(object sender, EventArgs e)
        {
            HienThiDSNV();
        }
        private void HienThiDSNV()
        {
            if (_nv.Quyen != "Admin")
            {
                DataTable dt = NhanVienBUS.LayDSNhanVien();
                dgv_NhanVien.DataSource = dt;
            }
            else
            {
                DataTable dt = NhanVienBUS.LayDSNhanVienCoMK();
                dgv_NhanVien.DataSource = dt;
            }
        }
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                loginForm frm = new loginForm();
                frm.Show();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                int index = dgv_NhanVien.CurrentRow.Index;
                int maNV = int.Parse(dgv_NhanVien.Rows[index].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    string quyen = NhanVienBUS.LayQuyenNVTheoMaNV(maNV);
                    if (quyen != "Admin")
                    {
                        bool kq;
                        try
                        {
                            kq = NhanVienBUS.XoaNhanVien(maNV);
                            if (kq == true)
                            {
                                MessageBox.Show("Đã xóa nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DuaDSNhanVienLenDataGridView();
                                tbx_User.Text = "";
                                tbx_Pass.Text = "";
                                tbx_Repass.Text = "";
                                tbx_DisplName.Text = "";
                            }
                            else
                                MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch
                        {
                            MessageBox.Show("Nhân viên đang được phân công không thể xóa!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Không thể xóa tài khoản Admin!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if(tbx_Search.Text=="")
            {
                MessageBox.Show("Chưa Nhập Tên Cần Tra Cứu ! ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                tbx_DisplName.Text = "";
                tbx_User.Text = "";
                tbx_Repass.Text = "";
                tbx_Pass.Text = "";
                cmB_Type.Text = "Tiếp Tân";
                DataTable dt = NhanVienBUS.TraCuuNhanVienTheoTen(tbx_Search.Text);
                dgv_NhanVien.DataSource = dt;
            }    
        }

        private void dgv_DSNV_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                int idx = dgv_NhanVien.CurrentRow.Index;
                tbx_DisplName.Text = dgv_NhanVien.Rows[idx].Cells[1].Value.ToString();
                dtiNgaySinh.Text = dgv_NhanVien.Rows[idx].Cells[2].Value.ToString();
                tbx_User.Text = dgv_NhanVien.Rows[idx].Cells[3].Value.ToString();
                cmB_Type.Text = dgv_NhanVien.Rows[idx].Cells[4].Value.ToString();
                if (cmB_Type.Text == "Admin")
                {
                    tbx_User.ReadOnly = false;
                    tbx_Pass.ReadOnly = false;
                    tbx_Repass.ReadOnly = false;
                    cmB_Type.Enabled = false;
                }
                else
                    cmB_Type.Enabled = true;
                string MatKhau = NhanVienBUS.LayMatKhauTuTenDN(dgv_NhanVien.Rows[idx].Cells[3].Value.ToString());
                tbx_Pass.Text = MatKhau;
                tbx_Repass.Text = tbx_Pass.Text;
            }
        }
        private void ChinhSuaTTNhanVien()
        {
            NhanVienDTO nv = new NhanVienDTO();
            
            if (verify())
            {
                nv.HoTen = tbx_DisplName.Text;
                nv.MatKhau = tbx_Pass.Text;
                nv.TenDN = tbx_User.Text;
                if(NhanVienBUS.CapNhatNhanVien(nv))
                {
                    MessageBox.Show("Cập Nhật Thành Công !!");
                }
            }
            else
            {
                MessageBox.Show("Không được ĐỂ TRỐNG bất cứ thông tin nào !!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                try
                {
                    int index = dgv_NhanVien.CurrentRow.Index;
                    tbx_User.Text = dgv_NhanVien.Rows[index].Cells[1].Value.ToString();
                    //tbx_Pass.Text = dgv_NhanVien.Rows[index].Cells[2].Value.ToString();
                    tbx_DisplName.Text = dgv_NhanVien.Rows[index].Cells[3].Value.ToString();
                    cmB_Type.Text = dgv_NhanVien.Rows[index].Cells[4].Value.ToString();
                    tbx_User.ReadOnly = false;
                    tbx_Pass.ReadOnly = false;
                    tbx_Repass.ReadOnly = false;
                    tbx_DisplName.ReadOnly = false;
                    cmB_Type.Enabled = false;
                    cmB_Type.Enabled = true;
                    string MK = NhanVienBUS.LayMatKhauTuTenDN(dgv_NhanVien.Rows[index].Cells[1].Value.ToString());
                    tbx_Pass.Text = MK;
                    tbx_Repass.Text = MK;
                }
                catch { }
            }    
                
            
            


        }
        public void SuaNhanVien()
        {
            NhanVienDTO nv = new NhanVienDTO();
            int idx = dgv_NhanVien.CurrentRow.Index;
            nv.MaNV = int.Parse(dgv_NhanVien.Rows[idx].Cells[0].Value.ToString());
            nv.HoTen = tbx_DisplName.Text;
            nv.NgaySinh = DateTime.Parse(dtiNgaySinh.Text);
            nv.TenDN = tbx_User.Text;
            nv.MatKhau = tbx_Pass.Text;
            nv.Quyen = cmB_Type.Text;
            if (!NhanVienBUS.KiemTraTenDNTonTai(nv.TenDN, nv.MaNV))
            {
                bool kq = NhanVienBUS.CapNhatNhanVien(nv);
                if (kq == true)
                {
                    MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                    DuaDSNhanVienLenDataGridView();
                    tbx_User.Text = "";
                    tbx_Pass.Text = "";
                    tbx_Repass.Text = "";
                    tbx_DisplName.Text = "";
                    cmB_Type.Text = "Tiếp Tân";
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            else
                MessageBox.Show("Tên đăng nhập này đã tồn tại!");
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                if (cmB_Type.Text != "Tiếp Tân")
                {
                    if (tbx_User.Text.Length >= 6 && tbx_User.Text.Length <= 20)
                    {
                        if (tbx_DisplName.Text != "")
                        {
                            if (tbx_Pass.Text.Length >= 6 && tbx_Pass.Text.Length <= 20)
                            {
                                if (tbx_Pass.Text == tbx_Repass.Text)
                                {
                                    if (dtiNgaySinh.Text != "")
                                    {
                                        SuaNhanVien();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ngày sinh không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Mật khẩu không trùng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbx_Repass.Text = "";
                                    tbx_Repass.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mật khẩu phải lớn hơn 5 và nhỏ hơn 21 ký tự!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbx_Pass.Text = "";
                                tbx_Pass.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Họ tên nhân viên không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbx_DisplName.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên Đăng nhập phải lớn hơn 5 và nhỏ hơn 21 ký tự!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbx_User.Text = "";
                        tbx_User.Focus();
                    }
                }
                else
                {
                    if (tbx_DisplName.Text != "")
                    {
                        if (dtiNgaySinh.Text != "")
                        {
                            SuaNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Ngày sinh không được rỗng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Họ tên nhân viên không được rỗng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /*------------------------------------------------Kết Thúc Phần Nhân Viên-----------------------------------------------*/



        /*------------------------------------------------Phân Công-----------------------------------------------*/

        /*private void dgv_PhanCong_Click(object sender, EventArgs e)
        {
            int index = dgv_PhanCong.CurrentRow.Index;
            DataTable dt = NhanVienBUS.LayDSNhanVien();
            tbx_TennvPc.Text = dt.Rows[index][1].ToString();
            cmb_ManvPC.Text= dgv_PhanCong.Rows[index].Cells[0].Value.ToString();
            tbx_TennvPc.ReadOnly = true;
           
            int ca1 = Convert.ToInt32(dgv_PhanCong.Rows[index].Cells[1].Value.ToString());
            int ca2 = Convert.ToInt32(dgv_PhanCong.Rows[index].Cells[2].Value.ToString());
            int ca3 = Convert.ToInt32(dgv_PhanCong.Rows[index].Cells[3].Value.ToString());
            ckB_Ca1PC.Checked = true;
            ckB_Ca2PC.Checked = true;
            ckB_Ca3.Checked = true;
            if(ca1==0)
            {
                ckB_Ca1PC.Checked = false;
            }
            if (ca2 == 0)
            {
                ckB_Ca2PC.Checked = false;
            }
            if (ca3 == 0)
            {
                ckB_Ca3.Checked = false;
            }
            

        }*/
        private void ExportToPDF(DataGridView dgv)
        {

            if (dgv.Rows.Count > 0)

            {

                string.Format("LuongNgay{0}.pdf", DateTime.Now.ToString("dd/MM/yy"));
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = string.Format("LuongNgay{0}.pdf", DateTime.Now.ToString("dd/MM/yy"));

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dgv.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
                            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12);

                            foreach (DataGridViewColumn col in dgv.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, f));

                                pTable.AddCell(pCell);

                            }

                            int RowCount = dgv.Rows.Count;
                            int ColumnCount = dgv.Columns.Count;
                            //add rows
                            //
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pTable.AddCell(new Phrase(cell.Value.ToString(), f));
                                }
                            }
                            //
                            string path = "D:\\PDF\\";
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            using (FileStream fileStream = new FileStream(path + save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();
                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }

        /*------------------------------------------------Kết Thúc Phần Phân Công-----------------------------------------------*/


        /*------------------------------------------------Check in-----------------------------------------------*/






        /*private void button_Checkin_Click_1(object sender, EventArgs e)
        {
            if (_id != "MNG1" && _id!="MNG2")
            {
                DataTable _ds = Res_ManagementSystem.BUS.PhanCongBUS.LayDSChiaCa();

                //MessageBox.Show(_id,"Test",MessageBoxButtons.OK,MessageBoxIcon.Information);
                for (int i = 0; i < _ds.Rows.Count; i++)
                {
                    if (_id == _ds.Rows[i][0].ToString())
                    {
                        chkinhour = Convert.ToInt32(dateTimePicker_Checkio.Value.ToString("HH"));
                        chkinmin = Convert.ToInt32(dateTimePicker_Checkio.Value.ToString("mm"));
                        //chkinhour = 7;
                        //chkinmin = 0;
                        int ca = BUS.PhanCongBUS.LayCaTheoGio(chkinhour);
                        CheckinDTO ck = new CheckinDTO();
                        ck.MaNV = _id;

                        if (ca != 0)
                        {
                            DataTable _ds1 = Res_ManagementSystem.BUS.PhanCongBUS.NVLamTrongCa(ca.ToString(), _id);
                            if (_ds1.Rows.Count != 0)
                            {
                                int _gioTre;
                                int _phutTre;
                                if (ca == 1)
                                {
                                    _gioTre = chkinhour - 7;
                                    _phutTre = chkinmin - 0;
                                    if (_gioTre == 0 && _phutTre == 0)
                                    {
                                        ck_i_hour += chkinhour;
                                        ck.Checkin1 = ck_i_hour;
                                        if (CheckinBUS.CapNhatCheckinDungGio(ck) && PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công !", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    }
                                    else if (_gioTre == 0 && _phutTre <= 15)
                                    {

                                        ck_i_hour = chkinhour;
                                        ck.Checkin1 = ck_i_hour;

                                        if (CheckinBUS.CapNhatCheckinDungGio(ck) && PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công !", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else if (_gioTre == 0 && _phutTre > 15)
                                    {

                                        ck_i_hour = chkinhour + 1;
                                        ck.Checkin1 = ck_i_hour;

                                        if (PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công ! Bạn Bị Trễ " + _gioTre + "giờ" + _phutTre + "phút", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        _gioTre += 1;
                                        _caTre = 1;
                                    }
                                    else
                                    {

                                        ck_i_hour = chkinhour;
                                        ck.Checkin1 = ck_i_hour;
                                        if (PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công ! Bạn Bị Trễ " + _gioTre + "giờ" + _phutTre + "phút", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        _caTre = 1;
                                    }

                                }
                                else if (ca == 2)
                                {
                                    _gioTre = chkinhour - 11;
                                    _phutTre = chkinmin - 0;
                                    if (_gioTre == 0 && _phutTre == 0)
                                    {
                                        ck_i_hour = chkinhour;
                                        ck.Checkin2 = ck_i_hour;

                                        if (CheckinBUS.CapNhatCheckinDungGio(ck) && PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Ca 2 Thành Công !", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else if (_gioTre == 0 && _phutTre <= 15)
                                    {

                                        ck_i_hour = chkinhour;
                                        ck.Checkin2 = ck_i_hour;

                                        if (CheckinBUS.CapNhatCheckinDungGio(ck) && PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Ca 2 Thành Công !", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else if (_gioTre == 0 && _phutTre > 15)
                                    {

                                        ck_i_hour = chkinhour + 1;
                                        ck.Checkin2 = ck_i_hour;
                                        if (PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công ! Bạn Bị Trễ " + _gioTre + "giờ" + _phutTre + "phút", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        _gioTre += 1;
                                        _caTre = 2;
                                    }
                                    else
                                    {

                                        ck_i_hour = chkinhour;
                                        ck.Checkin2 = ck_i_hour;
                                        if (PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công ! Bạn Bị Trễ " + _gioTre + "giờ" + _phutTre + "phút", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        _caTre = 2;
                                    }
                                }
                                else
                                {
                                    _gioTre = chkinhour - 18;
                                    _phutTre = chkinmin - 0;
                                    if (_gioTre == 0 && _phutTre == 0)
                                    {
                                        ck_i_hour = chkinhour;
                                        ck.Checkin3 = ck_i_hour;
                                        if (CheckinBUS.CapNhatCheckinDungGio(ck) && PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Ca 3 Thành Công !", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else if (_gioTre == 0 && _phutTre <= 15)
                                    {
                                        ck_i_hour = chkinhour;
                                        ck.Checkin3 = ck_i_hour;
                                        if (CheckinBUS.CapNhatCheckinDungGio(ck) && PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Ca 3 Thành Công !", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else if (_gioTre == 0 && _phutTre > 15)
                                    {

                                        ck_i_hour = chkinhour + 1;
                                        ck.Checkin3 = ck_i_hour;
                                        if (PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công ! Bạn Bị Trễ " + _gioTre + "giờ" + _phutTre + "phút", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        _gioTre += 1;
                                        _caTre = 3;
                                    }
                                    else
                                    {

                                        ck_i_hour = chkinhour;
                                        ck.Checkin3 = ck_i_hour;
                                        if (PhanCongBUS.CapNhatCheckin(ck.MaNV))
                                            MessageBox.Show("Check In Thành Công ! Bạn Bị Trễ " + _gioTre + "giờ" + _phutTre + "phút", "Check In Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        _caTre = 3;
                                    }
                                }
                                int giotre = Convert.ToInt32(_ds.Rows[i][5].ToString()) + _gioTre;
                                int catre = Convert.ToInt32(_ds.Rows[i][8].ToString()) * 10 + _caTre;
                                if (PhanCongBUS.ThemGioTreCaTre(_id, giotre, catre))
                                {
                                    if (CheckinBUS.CapNhatCheckin(ck))
                                    {

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nhân Viên Không có Ca Làm Này Hôm nay", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hệ Thống Chấm Công đang tạm dừng do đang ngoài giờ làm việc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Chỉ Nhân Viên mới sử dụng chức năng này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //private CheckinDTO CheckinDTO()
        //{
        //    throw new NotImplementedException();
        //}*/

        /*private void button_Checkout_Click_1(object sender, EventArgs e)
        {
            if (_id != "MNG1" && _id != "MNG2")
            {
                //int chkouthour = Convert.ToInt32(dateTimePicker_Checkio.Value.ToString("HH"));
                // int chkoutmin = Convert.ToInt32(dateTimePicker_Checkio.Value.ToString("mm"));

                //DataTable _ds = BUS.AssignmentBUS.NVLamTrongCa((ca+1).ToString(), _id);
                CheckinDTO ck = new CheckinDTO();
                ck.MaNV = _id;

                int chkouthour = 15;
                if (chkouthour == 11)
                {
                    int ca = BUS.PhanCongBUS.LayCaTheoGio(chkouthour + 1);
                    DataTable _ds = BUS.PhanCongBUS.NVLamTrongCa(ca.ToString(), _id);
                    if (_ds.Rows.Count > 0)
                    {
                        //_giolam += 11 - ck_i_hour;
                        ck_i_hour = 11;
                        ck.Checkout1 = 11;

                        MessageBox.Show("Bạn Còn Ca 2 Trong Ngày !!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int _ca = BUS.PhanCongBUS.LayCaTheoGio(chkouthour + 7);
                        DataTable _ds_ = BUS.PhanCongBUS.NVLamTrongCa(_ca.ToString(), _id);
                        if (_ds_.Rows.Count > 0)
                        {
                            //MessageBox.Show("Bạn Còn Ca 3 Trong Ngày !!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //_giolam += 11 - ck_i_hour;
                            ck_i_hour = 18;
                            ck.Checkout1 = 11;

                            MessageBox.Show("Bạn Còn Ca 3 Trong Ngày !!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Hết Ca 1", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    //_giolam += 11 - ck_i_hour;
                            ck.Checkout1 = 11;
                            //     MessageBox.Show("Bạn Còn Ca 3 Trong Ngày !!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        }
                    }
                }
                else if (chkouthour == 15)
                {
                    int ca = BUS.PhanCongBUS.LayCaTheoGio(chkouthour + 3);
                    DataTable _ds = BUS.PhanCongBUS.NVLamTrongCa(ca.ToString(), _id);
                    if (_ds.Rows.Count > 0)
                    {
                        //_giolam += 15 - ck_i_hour;
                        ck_i_hour = 18;
                        ck.Checkout2 = 15;

                        MessageBox.Show("Bạn Còn Ca 3 Trong Ngày !!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ck.Checkout2 = 15;

                        MessageBox.Show("Hết Ca 2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //_giolam += 15 - ck_i_hour;


                    }
                }
                else if (chkouthour == 22)
                {
                    ck.Checkout3 = 22;

                    MessageBox.Show("Hết Ca 3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //_giolam += 22 - ck_i_hour;
                }
                else
                {
                    if ((MessageBox.Show("Đang trong giờ làm ! Bạn có chắc muốn check out??", "CheckOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {

                        if (chkouthour > 18 && chkouthour < 22)
                            ck.Checkout3 = chkouthour;
                        else if (chkouthour > 11 && chkouthour < 15)
                            ck.Checkout2 = chkouthour;
                        else
                            ck.Checkout1 = chkouthour;

                        MessageBox.Show("Check Out Xong", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //_giolam += chkouthour - ck_i_hour;
                    }
                }
                CheckinBUS.CapNhatCheckOut(ck);
                DataTable ds = CheckinBUS.LayDSCheckinMotNhanVien(_id);
                DataTable dt = PhanCongBUS.LayDSChiaCaTuMaNV(_id);
                if (int.Parse(ds.Rows[0][1].ToString()) != 0 || int.Parse(ds.Rows[0][3].ToString()) != 0)
                    if (int.Parse(dt.Rows[0][9].ToString()) == 1)
                    {
                        TinhTienLuongNgay();
                        TinhTienThuongNgay();
                    }

                dgvCheckin.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Chỉ Nhân Viên mới sử dụng chức năng này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }*/
        
      
        





        /////////////////////////////////////   KẾT Thúc CHeckIN /////////////////////////////
        ///

        /////////////////////////////////////////    Thực Đơn   /////////////////////////////////

        private void LoadLoaiThucDonIntoCombobox()
        {
            List<LoaiThucDonDTO> _dsltd = LoaiThucDonBUS.LayDSLoaiThucDon();
            cmB_loaitd_TD.DataSource = _dsltd;
            cmB_loaitd_TD.DisplayMember = "TenLoai";
            cmB_loaitd_TD.ValueMember = "MaLoai";



            cmb_LoaiThucDon.DataSource = _dsltd;
            cmb_LoaiThucDon.DisplayMember = "TenLoai";
            cmb_LoaiThucDon.ValueMember = "MaLoai";

            cmB_loaitdTD.DataSource = _dsltd;
            cmB_loaitdTD.DisplayMember = "TenLoai";
            cmB_loaitdTD.ValueMember = "MaLoai";


            cmB_loaitdCNGM.DataSource = _dsltd;
            cmB_loaitdCNGM.DisplayMember = "TenLoai";
            cmB_loaitdCNGM.ValueMember = "MaLoai";
        }
        public void ThemThucDon()
        {
            ThucDonDTO td = new ThucDonDTO();
            GiaDTO g = new GiaDTO();
            td.MaTD = ThucDonBUS.MaTuTang();
            td.MaLoai = LoaiThucDonBUS.LayMaLoaiTuTenLoai(cmB_loaitd_TD.Text);
            td.TenTD = tbx_tentd_TD.Text;
            td.DonViTinh = tbx_donvitinhTD.Text;

            g.MaTD = td.MaTD;
            g.NgayADGia = dtiNgayAD.Value;

            try
            {
                g.Gia = double.Parse(tbx_dongiaTD.Text);
                bool kt = ThucDonBUS.KiemTraTrungTenThucDon(td.TenTD);
                if (kt == true)
                {
                    bool kq1 = ThucDonBUS.ThemThucDon(td);
                    bool kq2 = GiaBUS.ThemGia(g);
                    if (kq1 == true && kq2 == true)
                        MessageBox.Show("Thêm thực đơn thành công!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thực đơn này đã có!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu nhập đơn giá không chính xác! Vui lòng nhập lại đơn giá!");
            }
        }

        private void btn_ThemTD_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                if (tbx_tentd_TD.Text != "")
                {
                    if (tbx_dongiaTD.Text != "")
                    {
                        if (dtiNgayAD.Text != "")
                        {
                            if (tbx_donvitinhTD.Text != "")
                            {
                                ThemThucDon();
                            }
                            else
                                MessageBox.Show("Chưa nhập đơn vị tính!");
                        }
                        else
                            MessageBox.Show("Chưa nhập ngày áp dụng đơn giá!");
                    }
                    else
                        MessageBox.Show("Chưa nhập đơn giá!");
                }
                else
                    MessageBox.Show("Chưa nhập tên thực đơn!");
            }
            else
            {
                MessageBox.Show("Chỉ có Quản Lý mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///
        private void btn_EditTD_Click(object sender, EventArgs e)// Sửa Thực đơn
        {
            if (_nv.Quyen == "Admin")
            {
                ThucDonDTO td = new ThucDonDTO();
                GiaDTO g = new GiaDTO();

                int index = dgv_DSTD.CurrentRow.Index;
                if (tbx_tentd_TD.Text != "")
                {

                    if (tbx_donvitinhTD.Text != "")
                    {
                        td.MaTD = int.Parse(dgv_DSTD.Rows[index].Cells[0].Value.ToString());
                        td.MaLoai = LoaiThucDonBUS.LayMaLoaiTuTenLoai(cmB_loaitd_TD.Text);
                        td.TenTD = tbx_tentd_TD.Text;
                        td.DonViTinh = tbx_donvitinhTD.Text;
                        bool kt;
                        kt = ThucDonBUS.KiemTraTenTDCapNhat(tbx_tentd_TD.Text, td.MaTD);
                        if (kt == true)
                        {
                            g.MaTD = td.MaTD;
                            if (dtiNgayAD.Text != "")
                            {
                                g.NgayADGia = DateTime.Parse(dtiNgayAD.Text);

                                try
                                {
                                    double gia = double.Parse(tbx_dongiaTD.Text);
                                    if (gia > 0)
                                    {
                                        g.Gia = gia;
                                        bool kq1 = ThucDonBUS.CapNhatThucDon(td);
                                        bool kq2 = GiaBUS.CapNhatGia(g);
                                        if (kq1 == true && kq2 == true)
                                        {
                                            MessageBox.Show("Cập nhật thực đơn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            tbx_tentd_TD.Text = "";
                                            tbx_dongiaTD.Text = "";
                                            dtiNgayAD.Text = "";
                                            tbx_donvitinhTD.Text = "";
                                            cmB_loaitdTD_SelectedIndexChanged(sender, e);
                                        }
                                        else
                                            MessageBox.Show("Cập nhật thực đơn thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Đơn giá phải lớn hơn 0!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        tbx_dongiaTD.Text = "";
                                        tbx_dongiaTD.Focus();
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Chưa nhập đơn giá hoặc kiểu dữ liệu đơn giá không đúng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbx_dongiaTD.Text = "";
                                    tbx_dongiaTD.Focus();
                                }
                            }
                            else
                                MessageBox.Show("Chưa nhập ngày áp dụng giá!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Tên thực đơn bị trùng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbx_tentd_TD.Text = "";
                            tbx_tentd_TD.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập đơn vị tính!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbx_donvitinhTD.Text = "";
                        tbx_donvitinhTD.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập tên thực đơn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbx_tentd_TD.Text = "";
                    tbx_tentd_TD.Focus();
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Quản Lý mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btn_Xoa_Click(object sender, EventArgs e)//Xóa Thức Đơn
        {
            if (_nv.Quyen == "Admin")
            {
                try
                {
                    int index = dgv_DSTD.CurrentRow.Index;
                    int maTD = int.Parse(dgv_DSTD.Rows[index].Cells[0].Value.ToString());
                    DateTime ngayAD = DateTime.Parse(dtiNgayAD.Text);
                    DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                    if (result == DialogResult.Yes)
                    {
                        bool kq1, kq2;
                        try
                        {
                            kq1 = GiaBUS.XoaGiaTheoMaTDVaNgayAD(maTD, ngayAD);
                            kq2 = ThucDonBUS.XoaThucDonTheoMaTD(maTD);

                            if (kq1 == true && kq2 == true)
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbx_tentd_TD.Text = "";
                                tbx_dongiaTD.Text = "";
                                dtiNgayAD.Text = "";
                                tbx_donvitinhTD.Text = "";

                                if (tbx_tentdTD.Text != "")
                                    btn_TimTD_Click(sender, e);
                                if (cmB_loaitdTD.Text != "")
                                    cmB_loaitdTD_SelectedIndexChanged(sender, e);
                            }
                            else
                                MessageBox.Show("Xóa thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBox.Show("Thực đơn đã được gọi món hoặc có trong hóa đơn. Không thể xóa!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Chưa chọn thực đơn cần xóa!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Quản Lý mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_TimTD_Click(object sender, EventArgs e)// Tìm Thực Đơn
        {
            tbx_tentd_TD.Text = "";
            cmB_loaitdTD.Text = "";
            dtiNgayAD.Text = "";
            tbx_dongiaTD.Text = "";
            tbx_donvitinhTD.Text = "";
            if (tbx_tentdTD.Text == "")
                MessageBox.Show("Chưa nhập tên thực đơn cần tra cứu!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataTable kq = ThucDonBUS.TraCuuThucDonTheoTen(tbx_tentdTD.Text);
                dgv_DSTD.DataSource = kq;
            }
        }

        private void dgv_DSTD_Click(object sender, EventArgs e)
        {

            int index = dgv_DSTD.CurrentRow.Index;
            tbx_tentd_TD.Text = dgv_DSTD.Rows[index].Cells[1].Value.ToString();
            tbx_dongiaTD.Text = dgv_DSTD.Rows[index].Cells[2].Value.ToString();
            dtiNgayAD.Text = dgv_DSTD.Rows[index].Cells[3].Value.ToString();
            tbx_donvitinhTD.Text = dgv_DSTD.Rows[index].Cells[4].Value.ToString();
            cmB_loaitd_TD.Text = dgv_DSTD.Rows[index].Cells[5].Value.ToString();
        }


        public void LoadBanIntoCombobox()
        {
            List<BanDTO> _dsban = BanBUS.LayDSBan();
            List<int> _dsBanDaDat = HoaDonBUS.LayDSBanChuaThanhToan();
            List<int> _dsTam = new List<int>();
            for (int i = 0; i < _dsban.Count; i++)
            {
                bool flag = false;
                for (int j = 0; j < _dsBanDaDat.Count; j++)
                {
                    if (_dsban[i].MaBan == _dsBanDaDat[j])
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    _dsTam.Add(int.Parse(_dsban[i].MaBan.ToString()));
                }
            }
            cmB_ChonBan.DataSource = _dsTam;
            //cmb_chonbanCN.DataSource = _dsTam;
        }
        //public void DuaDSBanDaGoiLenCombobox()
        //{
        //    cmbDSBanCanLapHD.Items.Clear();
        //    cmbDSBanCapNhat.Items.Clear();
        //    cmbDSBanCanLapHD.Text = "";
        //    cmbDSBanCapNhat.Text = "";
        //    List<int> _dsMaBan = HoaDonBUS.LayDSBanChuaThanhToan();
        //    for (int i = 0; i < _dsMaBan.Count; i++)
        //    {
        //        cmbDSBanCanLapHD.Items.Add(_dsMaBan[i].ToString());
        //        cmbDSBanCapNhat.Items.Add(_dsMaBan[i].ToString());
        //    }
        //}

        private void btn_ThemMon_Click(object sender, EventArgs e)
        {
            if (tbx_DonGia.Text != "")
            {
                int maTD = int.Parse(lb_DSTD.SelectedValue.ToString());
                string tenTD = ThucDonBUS.LayTenThucDonTuMaThucDon(maTD);
                bool tonTai = false;
                int dong = 0;
                for (int i = 0; i < lv_CTgoimon.Items.Count; i++)
                {
                    if (int.Parse(lv_CTgoimon.Items[i].SubItems[0].Text) == maTD)
                    {
                        tonTai = true;
                        dong = i;
                    }
                }
                //string soLuong = "1";
                
                string soLuong = numerud_SoLuong.Text;
                
                if (tonTai == false)
                {
                    string donGia = tbx_DonGia.Text;
                    string thanhTien = (double.Parse(donGia) * double.Parse(soLuong)).ToString() ;
                    ListViewItem item = new ListViewItem();
                    item.Text = maTD.ToString();
                    item.SubItems.Add(tenTD);
                    item.SubItems.Add(donGia);
                    item.SubItems.Add(soLuong);
                    item.SubItems.Add(thanhTien);
                    this.lv_CTgoimon.Items.Add(item);
                    numerud_SoLuong.Text = "1";
                }
                else
                {
                    int sl = int.Parse(lv_CTgoimon.Items[dong].SubItems[3].Text) + int.Parse(soLuong);
                    double thanhTien = double.Parse(tbx_DonGia.Text) * sl;
                    lv_CTgoimon.Items[dong].SubItems[3].Text = sl.ToString();
                    lv_CTgoimon.Items[dong].SubItems[4].Text = thanhTien.ToString();

                }
            }
            else
            {
                MessageBox.Show("Bạn nhập giá không chính xác!");
            }
        }

        private void lb_DSTD_Click(object sender, EventArgs e)
        {
            int maTD = int.Parse(lb_DSTD.SelectedValue.ToString());
            double gia = GiaBUS.LayGiaTheoMaThucDon(maTD);
            lbl_GTK.Text = gia.ToString();
            //tbx_DonGia.Text = Convert.ToString(double.Parse(lbl_GTK.Text));
            tbx_DonGia.Text = gia.ToString();
        }

        private void cmb_LoaiThucDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ThucDonDTO> _dstd = new List<ThucDonDTO>();
            string tenLoai = cmb_LoaiThucDon.Text.ToString();
            int maLoaiTD = LoaiThucDonBUS.LayMaLoaiTuTenLoai(tenLoai);
            _dstd = ThucDonBUS.LayDSThucDonTheoMaLoai(maLoaiTD);
            lb_DSTD.DataSource = _dstd;
            lb_DSTD.DisplayMember = "TenTD";
            lb_DSTD.ValueMember = "MaTD";
            tbx_DonGia.Text = "";
            lbl_GTK.Text = "0";
        }

        private void numerud_SoLuong_ValueChanged(object sender, EventArgs e)
        {
            lbl_GTK.Text = (double.Parse(tbx_DonGia.Text) * int.Parse(numerud_SoLuong.Value.ToString())).ToString();
        }

        private void btn_XoaTD_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa thực đơn này không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    lv_CTgoimon.FocusedItem.Remove();
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn Thực Đơn cần xóa!");
            }
        }

        private void btn_XoaDSTD_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa hết danh sách không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
            if (result == DialogResult.Yes)
            {
                lv_CTgoimon.Items.Clear();
            }
        }

        private void cmB_loaitd_TD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maLoai = LoaiThucDonBUS.LayMaLoaiTuTenLoai(cmB_loaitd_TD.Text);
            DataTable dsTD = ThucDonBUS.LayDanhSachTDTheoMaLoai(maLoai);

            dgv_DSTD.DataSource = dsTD;
            tbx_tentdTD.Text = "";
        }

        private void cmB_loaitdTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maLoai = LoaiThucDonBUS.LayMaLoaiTuTenLoai(cmB_loaitd_TD.Text);
            DataTable dsTD = ThucDonBUS.LayDanhSachTDTheoMaLoai(maLoai);

            dgv_DSTD.DataSource = dsTD;
            tbx_tentdTD.Text = "";
        }

        private void btn_LuuGoiMonGM_Click(object sender, EventArgs e)
        {
            if (lv_CTgoimon.Items.Count > 0)
            {
                if (tbx_SoKhach.Text != "")
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    CT_HoaDonDTO cthd = new CT_HoaDonDTO();
                    hd.MsBan = int.Parse(cmB_ChonBan.Text);
                    int maHD = HoaDonBUS.LayMaHoaDonCanLap();
                    hd.TongTien = 0;
                    hd.MsNVLap = _nv.MaNV;

                    hd.MsNVTT = _nv.MaNV;
                    int soKhach = int.Parse(tbx_SoKhach.Text);
                    if (soKhach > 0)
                    {
                        hd.SoKhach = soKhach;

                        bool kq = HoaDonBUS.LapHoaDon(hd);
                        if (kq == true)
                        {
                            for (int i = 0; i < lv_CTgoimon.Items.Count; i++)
                            {
                                cthd.SoHD = hd.SoHD;
                                cthd.MaTD = int.Parse(lv_CTgoimon.Items[i].SubItems[0].Text);
                                cthd.DonGia = double.Parse(lv_CTgoimon.Items[i].SubItems[2].Text);
                                cthd.SoLuong = int.Parse(lv_CTgoimon.Items[i].SubItems[3].Text);
                                CT_HoaDonBUS.ThemChiTietHoaDon(cthd);
                            }
                            MessageBox.Show("Lưu gọi món thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DuaDSBanDaGoiLenCombobox();
                            LoadBanIntoCombobox();
                            lv_CTgoimon.Items.Clear();
                            tbx_DonGia.Text = "";
                            tbx_SoKhach.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số khách phải lớn hơn 0!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbx_SoKhach.Text = "";
                        tbx_SoKhach.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập số lượng khách!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbx_SoKhach.Text = "";
                    tbx_SoKhach.Focus();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn thực đơn!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DuaDSBanDaGoiLenCombobox()
        {
            cmB_DSBanCanLHD.Items.Clear();
            cmb_chonbanCN.Items.Clear();
            cmB_DSBanCanLHD.Text = "";
            cmb_chonbanCN.Text = "";
            List<int> _dsMaBan = HoaDonBUS.LayDSBanChuaThanhToan();
            for (int i = 0; i < _dsMaBan.Count; i++)
            {
                cmB_DSBanCanLHD.Items.Add(_dsMaBan[i].ToString());
                cmb_chonbanCN.Items.Add(_dsMaBan[i].ToString());
            }
        }

        private void btn_addCN_Click(object sender, EventArgs e)
        {
            if (cmb_chonbanCN.Text != "")
            {
                if (tbx_dongiaCN.Text != "")
                {
                    int maTD = int.Parse(lb_dstdCNGM.SelectedValue.ToString());
                    string tenTD = ThucDonBUS.LayTenThucDonTuMaThucDon(maTD);
                    bool tonTai = false;
                    int dong = 0;
                    for (int i = 0; i < lv_ctgmCNGM.Items.Count; i++)
                    {
                        if (int.Parse(lv_ctgmCNGM.Items[i].SubItems[0].Text) == maTD)
                        {
                            tonTai = true;
                            dong = i;
                        }
                    }
                    //string soLuong = "1";

                    string soLuong = numeric_solCN.Text;

                    if (tonTai == false)
                    {
                        string donGia = tbx_dongiaCN.Text;
                        double thanhTienCN = double.Parse(donGia) * double.Parse(soLuong);
                        ListViewItem item = new ListViewItem();
                        item.Text = maTD.ToString();
                        item.SubItems.Add(tenTD);
                        item.SubItems.Add(donGia);
                        item.SubItems.Add(soLuong);
                        item.SubItems.Add(thanhTienCN.ToString());
                        this.lv_ctgmCNGM.Items.Add(item);
                        numeric_solCN.Text = "1";
                    }
                    else
                    {
                        int sl = int.Parse(lv_ctgmCNGM.Items[dong].SubItems[3].Text) + int.Parse(soLuong);
                        double thanhtienCN = double.Parse(tbx_dongiaCN.Text) * sl;
                        lv_ctgmCNGM.Items[dong].SubItems[3].Text = sl.ToString();
                        lv_ctgmCNGM.Items[dong].SubItems[4].Text = thanhtienCN.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn nhập giá không chính xác!");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn bàn cần cập nhật!");
            }
        }

        private void cmB_loaitdCNGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ThucDonDTO> _dstd = new List<ThucDonDTO>();
            string tenLoai = cmB_loaitdCNGM.Text.ToString();
            int maLoaiTD = LoaiThucDonBUS.LayMaLoaiTuTenLoai(tenLoai);
            _dstd = ThucDonBUS.LayDSThucDonTheoMaLoai(maLoaiTD);
            lb_dstdCNGM.DataSource = _dstd;
            lb_dstdCNGM.DisplayMember = "TenTD";
            lb_dstdCNGM.ValueMember = "MaTD";
            tbx_dongiaCN.Text = "";
            lbl_giatkCN.Text = "0";
        }

        private void lb_dstdCNGM_Click(object sender, EventArgs e)
        {
            int maTD = int.Parse(lb_dstdCNGM.SelectedValue.ToString());
            double gia = GiaBUS.LayGiaTheoMaThucDon(maTD);
            lbl_giatkCN.Text = gia.ToString();
            //tbx_DonGia.Text = Convert.ToString(double.Parse(lbl_GTK.Text));
            tbx_dongiaCN.Text = gia.ToString();
        }

        private void btn_LuuGoiMonCN_Click(object sender, EventArgs e)
        {
            if (lv_ctgmCNGM.Items.Count > 0)
            {
                if (tbx_sokCN.Text != "")
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    CT_HoaDonDTO cthd = new CT_HoaDonDTO();
                    hd.MsBan = int.Parse(cmb_chonbanCN.Text);
                    hd.SoKhach = int.Parse(tbx_sokCN.Text);
                    hd.SoHD = HoaDonBUS.LaySoHDTuMaBan(int.Parse(cmb_chonbanCN.Text));
                    HoaDonBUS.CapNhatSoKhach(hd.SoKhach, hd.SoHD);
                    bool kq = CT_HoaDonBUS.XoaCTHDTheoSoHD(hd.SoHD);

                    for (int i = 0; i < lv_ctgmCNGM.Items.Count; i++)
                    {
                        cthd.SoHD = hd.SoHD;
                        cthd.MaTD = ThucDonBUS.LayMaThucDonTuTenThucDon(lv_ctgmCNGM.Items[i].SubItems[1].Text);
                        cthd.DonGia = double.Parse(lv_ctgmCNGM.Items[i].SubItems[2].Text);
                        cthd.SoLuong = int.Parse(lv_ctgmCNGM.Items[i].SubItems[3].Text);
                        CT_HoaDonBUS.ThemChiTietHoaDon(cthd);
                    }
                    if (kq == true)
                    {
                        MessageBox.Show("Cập nhật gọi món thành công!");
                        DuaDSBanDaGoiLenCombobox();
                        LoadBanIntoCombobox();
                        lv_ctgmCNGM.Items.Clear();
                        tbx_dongiaCN.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Nhập số lượng khách!");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn thực đơn!");
            }
        }

        private void numeric_solCN_ValueChanged(object sender, EventArgs e)
        {
            lbl_giatkCN.Text = (double.Parse(tbx_dongiaCN.Text) * int.Parse(numeric_solCN.Value.ToString())).ToString();
        }

        private void btn_CapNhatMoiGM_Click(object sender, EventArgs e)
        {
            if (lv_ctgmCNGM.Items.Count > 0)
            {
                if (tbx_sokCN.Text != "")
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    CT_HoaDonDTO cthd = new CT_HoaDonDTO();
                    hd.MsBan = int.Parse(cmb_chonbanCN.Text);
                    hd.SoKhach = int.Parse(tbx_sokCN.Text);
                    hd.SoHD = HoaDonBUS.LaySoHDTuMaBan(int.Parse(cmb_chonbanCN.Text));
                    HoaDonBUS.CapNhatSoKhach(hd.SoKhach, hd.SoHD);
                    //bool kq = CT_HoaDonBUS.XoaCTHDTheoSoHD(hd.SoHD);

                    for (int i = 0; i < lv_ctgmCNGM.Items.Count; i++)
                    {
                        cthd.SoHD = hd.SoHD;
                        cthd.MaTD = ThucDonBUS.LayMaThucDonTuTenThucDon(lv_ctgmCNGM.Items[i].SubItems[1].Text);
                        cthd.DonGia = double.Parse(lv_ctgmCNGM.Items[i].SubItems[2].Text);
                        cthd.SoLuong = int.Parse(lv_ctgmCNGM.Items[i].SubItems[3].Text);
                        CT_HoaDonBUS.ThemChiTietHoaDon(cthd);
                    }
                    MessageBox.Show("Cập nhật gọi món thành công!");
                    DuaDSBanDaGoiLenCombobox();
                    LoadBanIntoCombobox();
                    lv_ctgmCNGM.Items.Clear();
                    tbx_dongiaCN.Text = "";
                }
                else
                {
                    MessageBox.Show("Nhập số lượng khách!");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn thực đơn!");
            }
        }

        private void btn_tinhtienLHD_Click(object sender, EventArgs e)
        {
            if (cmB_DSBanCanLHD.Text == "")
                MessageBox.Show("Chưa chọn bàn cần tính!");
            else
            {
                double tongTien = 0;
                for (int i = 0; i < lv_dsctgmLHD.Items.Count; i++)
                {
                    double donGia = double.Parse(lv_dsctgmLHD.Items[i].SubItems[1].Text);
                    int soLuong = int.Parse(lv_dsctgmLHD.Items[i].SubItems[2].Text);
                    tongTien += donGia * soLuong;
                }
                lbl_tinhtienLHD.Text = tongTien.ToString();
            }
        }

        private void cmB_DSBanCanLHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmB_nguoilhdLHD.Text = "";
            lv_dsctgmLHD.Items.Clear();
            DataTable _ds = new DataTable();
            int maBan = int.Parse(cmB_DSBanCanLHD.Text);
            int maHD = HoaDonBUS.LaySoHDTuMaBan(maBan);
            _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
            for (int i = 0; i < _ds.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = _ds.Rows[i][0].ToString();
                item.SubItems.Add(_ds.Rows[i][1].ToString());
                item.SubItems.Add(_ds.Rows[i][2].ToString());
                item.SubItems.Add((double.Parse(_ds.Rows[i][1].ToString())*double.Parse(_ds.Rows[i][2].ToString())).ToString());
                lv_dsctgmLHD.Items.Add(item);
            }

            int gioLap = HoaDonBUS.LayGioLapHDChuaThanhToanTheoMaBan(maBan);
            int ca = PhanCongBUS.LayCaTheoGio(gioLap);
            int maNV = PhanCongBUS.LayMaNVTheoMaBanVaCa(maBan, ca);

            string tenNV = NhanVienBUS.LayTenNVTheoMaNV(maNV);
            cmB_DSBanCanLHD.Text = tenNV;

        }
        private void btn_lhdLHD_Click(object sender, EventArgs e)
        {
            if (lv_dsctgmLHD.Items.Count > 0)
            {
                if (cmB_nguoilhdLHD.Text == "")
                    MessageBox.Show("Chưa chọn nhân viên tiếp tân!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (lbl_tinhtienLHD.Text == "0")
                        MessageBox.Show("Chưa tính tổng tiền!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        HoaDonDTO hd = new HoaDonDTO();
                        //hd.MsNVTT = cmB_nguoilhdLHD.SelectedValue.ToString();
                        hd.MsNVTT = int.Parse(cmB_nguoilhdLHD.SelectedValue.ToString());
                        hd.MsBan = int.Parse(cmB_DSBanCanLHD.Text);
                        hd.SoHD = HoaDonBUS.LaySoHDTuMaBan(hd.MsBan);
                        hd.TongTien = double.Parse(lbl_tinhtienLHD.Text);
                        bool kq = HoaDonBUS.CapNhatLapHoaDon(hd);
                        if (kq == true)
                        {
                            MessageBox.Show("Lập hóa đơn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DuaDSHoaDonLenDataGridView();
                            LoadBanIntoCombobox();
                            /*loadThangvaoComboBox();*/
                            lv_dsctgmLHD.Items.Clear();
                            DuaDSBanDaGoiLenCombobox();
                            lbl_tinhtienLHD.Text = "0";
                            DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn này ra không!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                            if (result == DialogResult.Yes)
                            {

                                GUI.HoaDon.XemHoaDon frm = new GUI.HoaDon.XemHoaDon();
                                frm.SoHD = hd.SoHD;
                                frm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lập hóa đơn thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn bàn!");
            }
        }

       // Quan ly hoa don
        
        private void btn_TraCuuTN_QLHD_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dti_ngayQLHD.Value;
                DataTable kq = HoaDonBUS.ThongKeHDTheoNgay(ngay);
                dgv_dshdQLHD.DataSource = kq;
            }
            catch
            {
                MessageBox.Show("Mời chọn ngày cần tra cứu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Tracuuthang_QLHD_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(cmB_thang_QLHD.Text);
                int nam = int.Parse(tbx_nam_QLHD.Text);
                DataTable dt = HoaDonBUS.ThongKeHDTheoThang(thang, nam);
                dgv_dshdQLHD.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Mời chọn tháng cần tra cứu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_XoangayQLHD_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dti_ngayQLHD.Value;
                DataTable dt = HoaDonBUS.ThongKeHDTheoNgay(ngay);
                XoaDSHD(dt);
            }
            catch
            {
                MessageBox.Show("Xóa hóa đơn không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaDSHD(DataTable dt)
        {
            if (_nv.Quyen == "Admin")
            {
                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int soHD = int.Parse(dt.Rows[i][0].ToString());
                        CT_HoaDonBUS.XoaCTHDTheoSoHD(soHD);
                        HoaDonBUS.XoaHDTheoSoHD(soHD);
                    }
                    MessageBox.Show("Xóa hóa đơn thành công!");
                    DuaDSHoaDonLenDataGridView();

                    dgv_dscthdQLHD.DataSource = null;
                    try
                    {
                        int idx2 = dgv_dshdQLHD.CurrentRow.Index;
                        int maHD = int.Parse(dgv_dshdQLHD.Rows[idx2].Cells[0].Value.ToString());
                        DataTable _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
                        dgv_dscthdQLHD.DataSource = _ds;
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Quản Lý mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_xoathang_QLHD_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(cmB_thang_QLHD.Text);
                int nam = int.Parse(tbx_nam_QLHD.Text);
                DataTable dt = HoaDonBUS.ThongKeHDTheoThang(thang, nam);
                dgv_dshdQLHD.DataSource = dt;
                XoaDSHD(dt);
            }
            catch
            {
                MessageBox.Show("Xóa hóa đơn không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_inhdQLHD_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon.XemHoaDon frm = new HoaDon.XemHoaDon();
                int idx = dgv_dshdQLHD.CurrentRow.Index;
                frm.SoHD = int.Parse(dgv_dshdQLHD.Rows[idx].Cells[0].Value.ToString());
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chưa chọn hóa đơn cần in!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoahd_QLHD_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idx = dgv_dshdQLHD.CurrentRow.Index;
                        int SoHD = int.Parse(dgv_dshdQLHD.Rows[idx].Cells[0].Value.ToString());
                        CT_HoaDonBUS.XoaCTHDTheoSoHD(SoHD);
                        HoaDonBUS.XoaHDTheoSoHD(SoHD);
                        MessageBox.Show("Xóa Thành Công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DuaDSHoaDonLenDataGridView();
                        dgv_dscthdQLHD.DataSource = null;
                        try
                        {
                            int idx2 = dgv_dshdQLHD.CurrentRow.Index;
                            int maHD = int.Parse(dgv_dshdQLHD.Rows[idx2].Cells[0].Value.ToString());
                            DataTable _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
                            dgv_dscthdQLHD.DataSource = _ds;
                        }
                        catch { }
                    }
                    catch
                    {
                        MessageBox.Show("Không có hóa đơn thanh toán nào trong hệ thống!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_dshdQLHD_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = dgv_dshdQLHD.CurrentRow.Index;
                int maHD = int.Parse(dgv_dshdQLHD.Rows[idx].Cells[0].Value.ToString());
                DataTable _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
                dgv_dscthdQLHD.DataSource = _ds;
            }
            catch { }
        }

/*        private void loadThangvaoComboBox()
        {
            DataTable dt = HoaDonBUS.LayCacThangLapHD();
            cmB_thang_QLHD.DataSource = dt;
            cmB_thang_QLHD.DisplayMember = "ThangLap";
            cmB_thang_QLHD.ValueMember = "ThangLap";

            cmB_thangTK.DataSource = dt;
            cmB_thangTK.DisplayMember = "ThangLap";
            cmB_thangTK.ValueMember = "ThangLap";
        }*/
        /****************** Thống Kê **********************/
        int flag;
        private void btn_tktheongayTK_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dti_ngayTK.Value;
                DataTable kq = HoaDonBUS.ThongKeHDTheoNgay(ngay);
                dgv_TK.DataSource = kq;
                ThongKe(kq);
                if (kq.Rows.Count > 0)
                    flag = 1;
                else
                    flag = 0;
            }
            catch
            {
                //MessageBox.Show("Mời chọn ngày cần thống kê!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKe(DataTable kq)
        {
            if (kq.Rows.Count > 0)
            {
                double tongDoanhThu = 0;
                int tongKhachDen = 0;
                for (int i = 0; i < dgv_TK.Rows.Count - 1; i++)
                {
                    tongDoanhThu += double.Parse(dgv_TK.Rows[i].Cells[5].Value.ToString());
                    tongKhachDen += int.Parse(dgv_TK.Rows[i].Cells[3].Value.ToString());
                }
                lbl_dtTK.Text = tongDoanhThu.ToString() + " VNÐ";
                lbl_soKhachTK.Text = tongKhachDen.ToString() + " Khách";

                DataTable _ds = new DataTable();
                _ds.Columns.Add("SoHD", typeof(int));
                _ds.Columns.Add("MaThucDon", typeof(int));
                _ds.Columns.Add("SoLuong", typeof(int));
                _ds.Columns.Add("DonGia", typeof(double));
                _ds.PrimaryKey = new DataColumn[] { _ds.Columns["SoHD"], _ds.Columns["MaThucDon"] };
                for (int i = 0; i < kq.Rows.Count; i++)
                {
                    int SoHD = int.Parse(kq.Rows[i][0].ToString());
                    if (_ds.Rows.Count == 0)
                    {
                        DataTable dtct = CT_HoaDonBUS.LayDSCTHD(SoHD);
                        for (int j = 0; j < dtct.Rows.Count; j++)
                        {
                            DataRow ct = _ds.NewRow();
                            ct[0] = int.Parse(dtct.Rows[j][0].ToString());
                            ct[1] = int.Parse(dtct.Rows[j][1].ToString());
                            ct[2] = int.Parse(dtct.Rows[j][2].ToString());
                            ct[3] = double.Parse(dtct.Rows[j][3].ToString());
                            _ds.Rows.Add(ct);
                        }
                    }
                    else
                    {
                        DataTable dtct = CT_HoaDonBUS.LayDSCTHD(SoHD);
                        for (int j = 0; j < dtct.Rows.Count; j++)
                        {
                            bool kt = false;
                            int dong = 0;
                            for (int k = 0; k < _ds.Rows.Count; k++)
                            {
                                if (dtct.Rows[j][1].ToString() == _ds.Rows[k][1].ToString())
                                {
                                    dong = k;
                                    kt = true;
                                }
                            }
                            if (kt == true)
                            {
                                _ds.Rows[dong][2] = int.Parse(_ds.Rows[dong][2].ToString()) + int.Parse(dtct.Rows[j][2].ToString());
                            }
                            else
                            {
                                DataRow ct = _ds.NewRow();
                                ct[0] = int.Parse(dtct.Rows[j][0].ToString());
                                ct[1] = int.Parse(dtct.Rows[j][1].ToString());
                                ct[2] = int.Parse(dtct.Rows[j][2].ToString());
                                ct[3] = double.Parse(dtct.Rows[j][3].ToString());
                                _ds.Rows.Add(ct);
                            }
                        }
                    }
                }

                DataTable _dstd = new DataTable();
                _dstd.Columns.Add("SoHD", typeof(int));
                _dstd.Columns.Add("MaThucDon", typeof(int));
                _dstd.Columns.Add("SoLuong", typeof(int));
                _dstd.Columns.Add("DonGia", typeof(double));
                _dstd.PrimaryKey = new DataColumn[] { _dstd.Columns["SoHD"], _dstd.Columns["MaThucDon"] };

                DataTable _dstu = new DataTable();
                _dstu.Columns.Add("SoHD", typeof(int));
                _dstu.Columns.Add("MaThucDon", typeof(int));
                _dstu.Columns.Add("SoLuong", typeof(int));
                _dstu.Columns.Add("DonGia", typeof(double));
                _dstu.PrimaryKey = new DataColumn[] { _dstu.Columns["SoHD"], _dstu.Columns["MaThucDon"] };

                for (int i = 0; i < _ds.Rows.Count; i++)
                {
                    if (ThucDonBUS.KiemTraThucAnNuocUong(int.Parse(_ds.Rows[i][1].ToString())))
                    {
                        DataRow ct = _dstd.NewRow();
                        ct[0] = int.Parse(_ds.Rows[i][0].ToString());
                        ct[1] = int.Parse(_ds.Rows[i][1].ToString());
                        ct[2] = int.Parse(_ds.Rows[i][2].ToString());
                        ct[3] = double.Parse(_ds.Rows[i][3].ToString());
                        _dstd.Rows.Add(ct);
                    }
                    else
                    {
                        DataRow ct = _dstu.NewRow();
                        ct[0] = int.Parse(_ds.Rows[i][0].ToString());
                        ct[1] = int.Parse(_ds.Rows[i][1].ToString());
                        ct[2] = int.Parse(_ds.Rows[i][2].ToString());
                        ct[3] = double.Parse(_ds.Rows[i][3].ToString());
                        _dstu.Rows.Add(ct);
                    }
                }

                if (_dstd.Rows.Count > 0)
                {
                    int MaxTD = int.Parse(_dstd.Rows[0][2].ToString());
                    for (int i = 0; i < _dstd.Rows.Count; i++)
                    {
                        int sl = int.Parse(_dstd.Rows[i][2].ToString());
                        if (MaxTD < sl)
                            MaxTD = int.Parse(_dstd.Rows[i][2].ToString());
                    }
                    int y = 0;
                    for (int i = 0; i < _dstd.Rows.Count; i++)
                    {
                        if (MaxTD == int.Parse(_dstd.Rows[i][2].ToString()))
                            y = i;
                    }

                    int MaTD = int.Parse(_dstd.Rows[y][1].ToString());
                    lbl_soluongbanTK.Text = MaxTD.ToString();
                    lbl_tdbcnTK.Text = ThucDonBUS.LayTenThucDonTuMaThucDon(MaTD);
                    lbl_dvtTDTK.Text = ThucDonBUS.LayDonViTinhTuMaTD(MaTD);
                }

                if (_dstu.Rows.Count > 0)
                {
                    int MaxTU = 0;
                    for (int i = 0; i < _dstu.Rows.Count; i++)
                    {
                        if (MaxTU < int.Parse(_dstu.Rows[i][2].ToString()))
                            MaxTU = int.Parse(_dstu.Rows[i][2].ToString());
                    }
                    int z = 0;
                    for (int i = 0; i < _dstu.Rows.Count; i++)
                    {
                        if (MaxTU == int.Parse(_dstu.Rows[i][2].ToString()))
                            z = i;
                    }

                    int MaTU = int.Parse(_dstu.Rows[z][1].ToString());
                    lbl_slbanTUTK.Text = MaxTU.ToString();
                    lbl_TUbcnTK.Text = ThucDonBUS.LayTenThucDonTuMaThucDon(MaTU);
                    lbt_dvtTUTK.Text = ThucDonBUS.LayDonViTinhTuMaTD(MaTU);
                }

            }
            else
            {
                lbl_tdbcnTK.Text = "Null";
                lbl_TUbcnTK.Text = "Null";
                lbl_dvtTDTK.Text = "Null";
                lbt_dvtTUTK.Text = "Null";
                lbl_soluongbanTK.Text = "0";
                lbl_slbanTUTK.Text = "0";
            }

        }

        private void btn_tkthangTK_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(cmB_thangTK.Text);
                int nam = int.Parse(tbx_namTK.Text);
                DataTable dt = HoaDonBUS.ThongKeHDTheoThang(thang, nam);
                dgv_TK.DataSource = dt;
                ThongKe(dt);
                if (dt.Rows.Count > 0)
                    flag = 2;
                else
                    flag = 0;
            }
            catch
            {
                MessageBox.Show("Mời chọn tháng cần thống kê!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_IntkngayTK_Click(object sender, EventArgs e)
        {
            if (dgv_TK.Rows.Count < 1 || flag == 0)
            {
                MessageBox.Show("Danh sách rỗng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (flag == 1)
                {
                    HoaDon.ThongKeTheoNgayForm frm = new HoaDon.ThongKeTheoNgayForm();
                    frm.TongDoanhThu = lbl_dtTK.Text;
                    frm.Ngay = dti_ngayTK.Value;
                    frm.ShowDialog();
                }
            }
        }

        private void Res_Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_IntkthangTK_Click(object sender, EventArgs e)
        {

        }

        private void cmB_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmB_Type.Text == "Tiếp Tân")
            {
                tbx_User.Text = "";
                tbx_Pass.Text = "";
                tbx_Repass.Text = "";
                tbx_User.ReadOnly = true;
                tbx_Pass.ReadOnly = true;
                tbx_Repass.ReadOnly = true;
            }
            else
            {
                tbx_User.ReadOnly = false;
                tbx_Pass.ReadOnly = false;
                tbx_Repass.ReadOnly = false;
            }
        }

        private void thempcBtn_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                try
                {
                    if (cmbNhanVienPC.Text != "")
                    {
                        if (cmbCa.Text != "")
                        {
                            if (cmbBanPC.Text != "")
                            {
                                PhanCongDTO pc = new PhanCongDTO();
                                pc.Ca = int.Parse(cmbCa.Text);
                                pc.MsNV = int.Parse(cmbNhanVienPC.SelectedValue.ToString());
                                pc.MsBan = int.Parse(cmbBanPC.Text);

                                bool kq = PhanCongBUS.ThemPhanCong(pc);
                                if (kq == true)
                                {
                                    MessageBox.Show("Phân công nhân viên thành công!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DuaDanhSachPhanCongLenDataGridView();
                                }
                                else
                                {
                                    MessageBox.Show("Phân công thất bại!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                MessageBox.Show("Chưa chọn bàn!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Chưa chọn ca!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Chưa chọn nhân viên!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Phân công này đã có rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void xoapcBtn_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                PhanCongDTO pc = new PhanCongDTO();
                int idx = dgvDSPhanCong.CurrentRow.Index;
                pc.Ca = int.Parse(dgvDSPhanCong.Rows[idx].Cells[0].Value.ToString());
                pc.MsNV = NhanVienBUS.LayMaNVTuTenNV(dgvDSPhanCong.Rows[idx].Cells[1].Value.ToString());
                pc.MsBan = int.Parse(dgvDSPhanCong.Rows[idx].Cells[2].Value.ToString());

                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    bool kq = PhanCongBUS.XoaPhanCong(pc);
                    if (kq == true)
                    {
                        MessageBox.Show("Xóa phân công thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DuaDanhSachPhanCongLenDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phân công thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///////////////////////// GỌI MÓN ////////////////////////////////////


        ///////////////////////////////// Phân Công ////////////////////////
        ///




    }
   
}
