using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DAO
{
    public class NhanVienDAO
    {
        public static int MaTuTang()
        {
            string sql = "select * from QLYQUANNHAU.[dbo].[NhanVien]";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            int maTuTang = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count == maTuTang)
                    return maTuTang+1;
                maTuTang++;
            }
            return maTuTang;
        }

        public static DataTable LayDSNhanVien()
        {
            string sql = "select MaNV as 'Mã NV', HoTen as 'Họ Tên', NgaySinh as 'Ngày Sinh', TenDN as 'Tên ĐN', Quyen as 'Quyền' from QLYQUANNHAU.[dbo].[NhanVien]";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

        public static DataTable LayDSNhanVienTiepTan()
        {
            string sql = "select MaNV as 'Mã NV', HoTen as 'Họ Tên', NgaySinh as 'Ngày Sinh', TenDN as 'Tên ĐN', Quyen as 'Quyền' from QLYQUANNHAU.[dbo].[NhanVien] where Quyen = N'Tiếp Tân'";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

        public static DataTable LayDSNhanVienCoMK()
        {
            string sql = "select * from QLYQUANNHAU.[dbo].[NhanVien]";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

        public static string LayMatKhauTuTenDN(string TenDN)
        {
            string sql = "select * from QLYQUANNHAU.[dbo].[NhanVien] where TenDN = N'" + TenDN + "'";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            string MK = dt.Rows[0][4].ToString();
            return MK;
        }

        public static int LayMaNVTuTenNV(string tenNV)
        {
            int maNV;
            string sql = string.Format("select MaNV from QLYQUANNHAU.[dbo].[NhanVien] where HoTen = N'{0}'", tenNV);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                maNV = int.Parse(dt.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
            return maNV;
        }

        public static string LayTenNVTheoMaNV(int maNV)
        {
            string sql = string.Format("select HoTen from QLYQUANNHAU.[dbo].[NhanVien] where MaNV = {0}", maNV);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            string tenNV = dt.Rows[0]["HoTen"].ToString();
            return tenNV;
        }

        public static string LayQuyenNVTheoMaNV(int maNV)
        {
            string sql = "select Quyen from QLYQUANNHAU.[dbo].[NhanVien] where MaNV = " + maNV;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            string quyen = dt.Rows[0]["Quyen"].ToString();
            return quyen;
        }

        public static bool KiemTraTenDNTonTai(string tenDN, int MaNV)
        {
            bool kq;
            string sql = "select * from QLYQUANNHAU.[dbo].[NhanVien] where TenDN = '" + tenDN + "'" + "and TenDN <> '' and MaNV <> " + MaNV;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                kq = true;
            else
                kq = false;
            return kq;
        }

        public static bool ThemNhanVien(NhanVienDTO nv)
        {
            nv.MaNV = MaTuTang();
            bool kq;
            string sql = string.Format("set dateformat DMY insert into QLYQUANNHAU.[dbo].[NhanVien] values ({0}, N'{1}', convert(varchar(10),'{2}',103), N'{3}', N'{4}', N'{5}')", nv.MaNV, nv.HoTen, nv.NgaySinh, nv.TenDN, nv.MatKhau, nv.Quyen);
            kq = DataProvider.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool CapNhatNhanVien(NhanVienDTO nv)
        {
            bool kq;
            string sql = string.Format("set dateformat DMY update QLYQUANNHAU.[dbo].[NhanVien] set HoTen = N'{0}', NgaySinh = convert(varchar(10),'{1}',103), TenDN = '{2}', MatKhau = '{3}', Quyen = N'{4}' where MaNV = {5}", nv.HoTen, nv.NgaySinh, nv.TenDN, nv.MatKhau, nv.Quyen, nv.MaNV);
            kq = DataProvider.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool XoaNhanVien(int maNV)
        {
            bool kq;
            string sql = string.Format("delete from QLYQUANNHAU.[dbo].[NhanVien] where MaNV = {0}", maNV);
            kq = DataProvider.ExecuteNonQuery(sql);
            return kq;
        }

        public static DataTable TraCuuNhanVienTheoTen(string tenNV)
        {
            string sql = string.Format("select MaNV as 'Mã NV', HoTen as 'Họ Tên', NgaySinh as 'Ngày Sinh', TenDN as 'Tên ĐN', Quyen as 'Quyền' from QLYQUANNHAU.[dbo].[NhanVien] where HoTen like N'%{0}%'", tenNV);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

    }
}
