using Res_ManagementSystem.DAO;
using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.BUS
{
    public class ThucDonBUS
    {
        public static bool ThemThucDon(ThucDonDTO td)
        {
            bool kq = ThucDonDAO.ThemThucDon(td);
            return kq;
        }

        public static bool XoaThucDonTheoMaTD(int maTD)
        {
            bool kq = ThucDonDAO.XoaThucDonTheoMaTD(maTD);
            return kq;
        }

        public static bool CapNhatThucDon(ThucDonDTO td)
        {
            bool kq = ThucDonDAO.CapNhatThucDon(td);
            return kq;
        }

        //Rút trích dữ liệu: select 
        public static List<ThucDonDTO> LayDSThucDon()
        {
            List<ThucDonDTO> _ds;
            _ds = ThucDonDAO.LayDSThucDon();
            return _ds;
        }

        public static List<ThucDonDTO> LayDSThucDonTheoMaLoai(int maLoai)
        {
            List<ThucDonDTO> _ds;
            _ds = ThucDonDAO.LayDSThucDonTheoMaLoai(maLoai);
            return _ds;
        }

        public static List<ThucDonDTO> LayDSMaTDVaTenTDTheoMaLoai(int maLoai)
        {
            List<ThucDonDTO> dsTD = ThucDonDAO.LayDSMaTDVaTenTDTheoMaLoai(maLoai);
            return dsTD;
        }

        public static string LayTenThucDonTuMaThucDon(int maTD)
        {
            string tenTD;
            tenTD = ThucDonDAO.LayTenThucDonTuMaThucDon(maTD);
            return tenTD;
        }
        public static int LayMaThucDonTuTenThucDon(string tenTD)
        {
            int maTD;
            maTD = ThucDonDAO.LayMaThucDonTuTenTD(tenTD);
            return maTD;
        }

        public static DataTable LayDanhSachTDTheoMaLoai(int maLoai)
        {
            DataTable dt = ThucDonDAO.LayDanhSachTDTheoMaLoai(maLoai);
            return dt;
        }

        public static string LayDonViTinhTuMaTD(int maTD)
        {
            string dvt = ThucDonDAO.LayDonViTinhTheoMaTD(maTD);
            return dvt;
        }

        public static bool KiemTraThucAnNuocUong(int maTD)
        {
            bool kq = ThucDonDAO.KiemTraThucDonNuocUong(maTD);
            return kq;
        }

        public static bool KiemTraTrungTenThucDon(string tenTD)
        {
            bool kq = ThucDonDAO.KiemTraTrungTenThucDon(tenTD);
            return kq;
        }

        public static bool KiemTraTenTDCapNhat(string tenTD, int maTD)
        {
            bool kq = ThucDonDAO.KiemTraTenTDCapNhat(tenTD, maTD);
            return kq;
        }

        public static DataTable TraCuuThucDonTheoTen(string tenTD)
        {
            DataTable kq = ThucDonDAO.TraCuuThucDonTheoTen(tenTD);
            return kq;
        }

        public static int MaTuTang()
        {
            int ma = ThucDonDAO.MaTuTang();
            return ma;
        }
    }
}
