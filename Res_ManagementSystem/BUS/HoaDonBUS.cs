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
    public class HoaDonBUS
    {
        //Rút trích dữ liệu: select 
        public static DataTable LayDSHoaDon()
        {
            DataTable _ds = HoaDonDAO.LayDSHoaDon();
            return _ds;
        }
        public static int LaySoHDTuMaBan(int maBan)
        {
            int soHD = HoaDonDAO.LaySoHoaDonTuMaBan(maBan);
            return soHD;
        }
        public static int LaySoKhachTuSoHD(int soHD)
        {
            int soKhach = HoaDonDAO.LaySoKhachTuSoHD(soHD);
            return soKhach;
        }
        public static List<int> LayDSBanChuaThanhToan()
        {
            List<int> _ds = HoaDonDAO.LayDSBanChuaThanhToan();
            return _ds;
        }

        public static int LayGioLapHDChuaThanhToanTheoMaBan(int maBan)
        {
            int gio = HoaDonDAO.LayGioLapHDChuaThanhToanTheoMaBan(maBan);
            return gio;
        }

        public static bool LapHoaDon(HoaDonDTO hd)
        {
            bool kq = HoaDonDAO.LapHoaDon(hd);
            return kq;
        }
        public static bool CapNhatLapHoaDon(HoaDonDTO hd)
        {
            bool kq = HoaDonDAO.CapNhatLapHoaDon(hd);
            return kq;
        }

        public static bool CapNhatSoKhach(int SoKhach, int SoHD)
        {
            bool kq = HoaDonDAO.CapNhatSoKhach(SoKhach, SoHD);
            return kq;
        }

        public static int LayMaHoaDonCanLap()
        {
            int maHD = HoaDonDAO.MaTuTang();
            return maHD;
        }

        public static bool XoaHDTheoSoHD(int SoHD)
        {
            bool kq = HoaDonDAO.XoaHDTheoSoHD(SoHD);
            return kq;
        }

        public static DataTable ThongKeHDTheoNgay(DateTime ngay)
        {
            DataTable kq = HoaDonDAO.ThongKeHDTheoNgay(ngay);
            return kq;
        }

        public static DataTable ThongKeHDTheoThang(int thang, int nam)
        {
            DataTable dt = HoaDonDAO.ThongKeHDTheoThang(thang, nam);
            return dt;
        }

        public static DataTable ThongKeHDTheoKhoangNgay(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = HoaDonDAO.ThongKeHDTheoKhoangNgay(tuNgay, denNgay);
            return dt;
        }
    }
}
