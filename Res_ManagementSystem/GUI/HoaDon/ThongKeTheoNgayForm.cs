using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res_ManagementSystem.GUI.HoaDon
{
    public partial class ThongKeTheoNgayForm : Form
    {
        public ThongKeTheoNgayForm()
        {
            InitializeComponent();
        }
        private string tongDoanhThu;

        public string TongDoanhThu
        {
            get { return tongDoanhThu; }
            set { tongDoanhThu = value; }
        }

        private DateTime ngay;

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }


        private void ThongKeTheoNgayForm_Load(object sender, EventArgs e)
        {
            Reports.ThongKeTheoNgay rpt = new Reports.ThongKeTheoNgay();
            crystalTKtheoNgay.Refresh();
            rpt.SetParameterValue(0, ngay);
            rpt.SetParameterValue(1, tongDoanhThu);
            crystalTKtheoNgay.ReportSource = rpt;
        }
    }
}
