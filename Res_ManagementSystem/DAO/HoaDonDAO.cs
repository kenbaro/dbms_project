using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DAO
{
    public class HoaDonDAO
    {
        //Rút trích dữ liêu: select 
        public static DataTable LayDSHoaDon()
        {
            string sql = "select hd.SoHD as 'Số HĐ', hd.ThoiGianLap as 'TG Lập', hd.MaSoBan as 'MS Bàn', hd.SoKhach as 'Số Khách', nv1.HoTen as 'Người Lập', nv2.HoTen as 'Tiếp Tân', hd.TongTien as 'Tổng Tiền' from QLYQUANNHAU.[dbo].[HoaDon] hd, QLYQUANNHAU.[dbo].[NhanVien] nv1, QLYQUANNHAU.[dbo].[NhanVien] nv2 where nv1.MaNV = hd.MaNVLap and nv2.MaNV = hd.MaNVTT";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

        public static int LaySoHoaDonTuMaBan(int maBan)
        {
            int soHD = 0;
            string sql = "select * from QLYQUANNHAU.[dbo].[HoaDon] where MaSoBan = " + maBan + " and TongTien = 0";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                soHD = int.Parse(dt.Rows[0]["SoHD"].ToString());
            }
            return soHD;
        }
        public static int LaySoKhachTuSoHD(int soHD)
        {
            int soKhach = 0;
            string sql = "select * from QLYQUANNHAU.[dbo].[HoaDon] where SoHD = " + soHD;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                soKhach = int.Parse(dt.Rows[0]["SoKhach"].ToString());
            }
            return soKhach;
        }

        public static List<int> LayDSBanChuaThanhToan()
        {
            List<int> _ds = new List<int>();
            string sql = "select * from QLYQUANNHAU.[dbo].[HoaDon] where TongTien = 0";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int maBan = int.Parse(dt.Rows[i]["MaSoBan"].ToString());
                _ds.Add(maBan);
            }
            return _ds;
        }

        public static int LayGioLapHDChuaThanhToanTheoMaBan(int maBan)
        {
            string sql = string.Format("select convert(varchar(2), ThoiGianLap, 108)as 'GioLap' from QLYQUANNHAU.[dbo].[HoaDon] where MaSoban = {0} and TongTien = 0", maBan);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            int gio = int.Parse(dt.Rows[0]["GioLap"].ToString());
            return gio;
        }

        public static bool LapHoaDon(HoaDonDTO hd)
        {
            hd.SoHD = MaTuTang();
            string sql = string.Format("set dateformat DMY insert into QLYQUANNHAU.[dbo].[HoaDon] values ({0}, '{1}', {2}, {3}, {4}, {5}, {6})", hd.SoHD, DateTime.Now, hd.MsBan, hd.SoKhach, hd.MsNVLap, hd.MsNVTT, hd.TongTien);
            bool kq;
            kq = DataProvider.ExecuteNonQuery(sql);
            return kq;
        }
        public static bool CapNhatLapHoaDon(HoaDonDTO hd)
        {
            string sql = string.Format("set dateformat DMY update QLYQUANNHAU.[dbo].[HoaDon] set ThoiGianLap = '{0}', MaNVTT = {1}, TongTien = {2} where SoHD = {3}", DateTime.Now, hd.MsNVTT, hd.TongTien, hd.SoHD);
            bool kq;
            kq = DataProvider.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool CapNhatSoKhach(int SoKhach, int SoHD)
        {
            string sql = string.Format("update QLYQUANNHAU.[dbo].[HoaDon] set SoKhach = {0} where SoHD = {1}", SoKhach, SoHD);
            bool kq = DataProvider.ExecuteNonQuery(sql);
            return kq;
        }

        public static DataTable ThongKeHDTheoNgay(DateTime ngay)
        {
            string sql = "set dateformat DMY select SoHD as 'Số HĐ', ThoiGianLap as 'Thời Gian Lập', MaSoBan as 'Mã Bàn', SoKhach as 'Số Khách', nv1.HoTen as 'Người Lập', nv2.HoTen as 'Tiếp Tân', TongTien as 'Tổng Tiền' from QLYQUANNHAU.[dbo].[HoaDon], QLYQUANNHAU.[dbo].[NhanVien] nv1, QLYQUANNHAU.[dbo].[NhanVien] nv2 where HoaDon.MaNVLap = nv1.MaNV and HoaDon.MaNVTT = nv2.MaNV and convert(varchar(10), ThoiGianLap,103) = convert(varchar(10), convert(datetime, '" + ngay + "'), 103)";
            DataTable kq = DataProvider.ExecuteQuery(sql);
            return kq;
        }

        public static DataTable ThongKeHDTheoThang(int thang, int nam)
        {
            string sql = string.Format("select hd.SoHD as 'Số HĐ', hd.ThoiGianLap as 'Thời Gian Lập', hd.MaSoBan as 'Mã Bàn', hd.SoKhach as 'Số Khách', nv1.HoTen as 'Người Lập', nv2.HoTen as 'Tiếp Tân', hd.TongTien as 'Tổng Tiền' from QLYQUANNHAU.[dbo].[HoaDon] hd, QLYQUANNHAU.[dbo].[NhanVien] nv1, QLYQUANNHAU.[dbo].[NhanVien] nv2 where hd.MaNVLap = nv1.MaNV and hd.MaNVTT = nv2.MaNV and convert(nvarchar(10), ThoiGianLap, 103) like '%{0}/{1}'", thang, nam);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

        public static DataTable ThongKeHDTheoKhoangNgay(DateTime tuNgay, DateTime denNgay)
        {
            string sql = string.Format("set dateformat DMY select SoHD as 'Số HĐ', ThoiGianLap as 'Thời Gian Lập', MaSoBan as 'Mã Bàn', SoKhach as 'Số Khách', nv1.HoTen as 'Người Lập', nv2.HoTen as 'Tiếp Tân', TongTien as 'Tổng Tiền' from QLYQUANNHAU.[dbo].[HoaDon], QLYQUANNHAU.[dbo].[NhanVien] nv1, QLYQUANNHAU.[dbo].[NhanVien] nv2 where QLYQUANNHAU.[dbo].[HoaDon].MaNVLap = nv1.MaNV and QLYQUANNHAU.[dbo].[HoaDon].MaNVTT = nv2.MaNV and convert(varchar(10), ThoiGianLap,103) >= convert(varchar(10),convert(datetime,'{0}'), 103) and convert(varchar(10), ThoiGianLap,103) <= convert(varchar(10),convert(datetime,'{1}'), 103)", tuNgay, denNgay);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

        public static bool XoaHDTheoSoHD(int SoHD)
        {
            bool kq;
            string sql = string.Format("delete QLYQUANNHAU.[dbo].[HoaDon] where SoHD = {0}", SoHD);
            kq = DataProvider.ExecuteNonQuery(sql);
            return kq;
        }

        public static int MaTuTang()
        {
            string sql = "select * from QLYQUANNHAU.[dbo].[HoaDon]";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            int maTuTang = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i][0].ToString()) != maTuTang)
                {
                    return maTuTang;
                }
                maTuTang++;
            }
            return maTuTang;
        }
    }
}
