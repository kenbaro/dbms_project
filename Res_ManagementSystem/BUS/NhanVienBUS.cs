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
    public class NhanVienBUS
    {
        public static DataTable LayDSNhanVien()
        {
            DataTable _ds = NhanVienDAO.LayDSNhanVien();
            return _ds;
        }

        public static DataTable LayDSNhanVienTiepTan()
        {
            DataTable dt = NhanVienDAO.LayDSNhanVienTiepTan();
            return dt;
        }

        public static DataTable LayDSNhanVienCoMK()
        {
            DataTable dt = NhanVienDAO.LayDSNhanVienCoMK();
            return dt;
        }
        public static string LayMatKhauTuTenDN(string TenDN)
        {
            string MK = NhanVienDAO.LayMatKhauTuTenDN(TenDN);
            return MK;
        }

        public static int LayMaNVTuTenNV(string tenNV)
        {
            int maNV = NhanVienDAO.LayMaNVTuTenNV(tenNV);
            return maNV;
        }

        public static string LayTenNVTheoMaNV(int maNV)
        {
            string tenNV = NhanVienDAO.LayTenNVTheoMaNV(maNV);
            return tenNV;
        }

        public static string LayQuyenNVTheoMaNV(int maNV)
        {
            string quyen = NhanVienDAO.LayQuyenNVTheoMaNV(maNV);
            return quyen;
        }

        //Thêm: insert 
        public static bool ThemNhanVien(NhanVienDTO nd)
        {
            bool kq = NhanVienDAO.ThemNhanVien(nd);
            return kq;
        }

        //Cập nhật thông tin người dùng
        public static bool CapNhatNhanVien(NhanVienDTO nv)
        {
            bool kq = NhanVienDAO.CapNhatNhanVien(nv);
            return kq;
        }

        //Xóa người dùng
        public static bool XoaNhanVien(int maNV)
        {
            bool kq = NhanVienDAO.XoaNhanVien(maNV);
            return kq;
        }

        public static bool KiemTraTenDNTonTai(string tenDN, int MaNV)
        {
            bool kq = NhanVienDAO.KiemTraTenDNTonTai(tenDN, MaNV);
            return kq;
        }

        public static DataTable TraCuuNhanVienTheoTen(string tenNV)
        {
            DataTable dt = NhanVienDAO.TraCuuNhanVienTheoTen(tenNV);
            return dt;
        }
    }
}
