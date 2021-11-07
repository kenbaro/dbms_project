using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Res_ManagementSystem.Reports;

namespace Res_ManagementSystem.GUI.HoaDon
{
    public partial class XemHoaDon : Form
    {
        public XemHoaDon()
        {
            InitializeComponent();
        }
        private int soHD;

        public int SoHD
        {
            get { return soHD; }
            set { soHD = value; }
        }
        private void XemHoaDon_Load(object sender, EventArgs e)
        {
           // string procName = "QLYNhaHang.[dbo].[sp_LayCTHDTuSoHD]";
           // DataTable ds = DAO.DataProvider.ViewStoredProc(procName, SoHD);
            crysterviewHD.Refresh();
            Reports.HoaDon rpt = new Reports.HoaDon();
            //rpt.SetDataSource(ds);
            rpt.SetParameterValue(0, soHD);
            crysterviewHD.ReportSource = rpt;
        }
    }
}
