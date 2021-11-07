//using QLNHFORM;
using Res_ManagementSystem.BUS;
using Res_ManagementSystem.GUI;
using System;
using System.Data;
using System.Windows.Forms;

namespace Res_ManagementSystem
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     
        private void Login()
        {
            if (txbUser.Text == "" || txbPass.Text == "")
            {
                MessageBox.Show("UserName or PassWord Mustn't Be Empty", "Login ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable _ds = NhanVienBUS.LayDSNhanVienCoMK();
                bool flag = false;
                for (int i = 0; i < _ds.Rows.Count; i++)
                {
                    if (txbUser.Text == _ds.Rows[i]["TenDN"].ToString() && txbPass.Text == _ds.Rows[i]["MatKhau"].ToString())
                    {
                        Res_Management mnFrm = new Res_Management();
                        mnFrm.Nv = new DTO.NhanVienDTO(int.Parse(_ds.Rows[i]["MaNV"].ToString()), _ds.Rows[i]["HoTen"].ToString(), DateTime.Parse(_ds.Rows[i]["NgaySinh"].ToString()), _ds.Rows[i]["TenDN"].ToString(), _ds.Rows[i]["MatKhau"].ToString(), _ds.Rows[i]["Quyen"].ToString());
                        mnFrm.Show();
                        flag = true;
                        //txbUser.Text = "";
                        //txbPass.Text = "";
                        //radManager.Checked = false;
                        this.Hide();
                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Đúng", "Lỗi Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbPass.Text = "";
                    txbPass.Focus();
                }
            }
        }
        private void logButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += loginFrom_KeyDown;
        }
        private void loginFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
}
