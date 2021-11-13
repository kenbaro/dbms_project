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
    public class ThucDonDAO
    {
        public static bool ThemThucDon(ThucDonDTO td)
        {
            /*string sql = string.Format("insert into QLYQUANNHAU.[dbo].[ThucDon] values ({0}, {1}, '{2}', '{3}')", td.MaTD, td.MaLoai, td.TenTD, td.DonViTinh);
            bool kq = DataProvider.ExecuteNonQuery(sql);
            return kq;*/
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[ThemThucDon]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaTD", td.MaTD);
            command.Parameters.AddWithValue("@MaLoai", td.MaLoai);
            command.Parameters.AddWithValue("@TenTD", td.TenTD);
            command.Parameters.AddWithValue("@DVT", td.DonViTinh);
            command.CommandType = CommandType.StoredProcedure;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                kq = true;
            }
            else
            {
                kq = false;
            }
            return kq;
        }
        public static bool XoaThucDonTheoMaTD(int maTD)
        {
            /*string sql = "delete QLYQUANNHAU.[dbo].[ThucDon] where MaThucDon = " + maTD;
            bool kq = DataProvider.ExecuteNonQuery(sql);
            return kq;*/
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[XoaThucDonTheoMaTD]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaTD", maTD);
            command.CommandType = CommandType.StoredProcedure;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                kq = true;
            }
            else
            {
                kq = false;
            }
            return kq;
        }

        public static bool CapNhatThucDon(ThucDonDTO td)
        {
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[CapNhatThucDon]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaTD", td.MaTD);
            command.Parameters.AddWithValue("@MaLoai", td.MaLoai);
            command.Parameters.AddWithValue("@TenTD", td.TenTD);
            command.Parameters.AddWithValue("@DVT", td.DonViTinh);
            command.CommandType = CommandType.StoredProcedure;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                kq = true;
            }
            else
            {
                kq = false;
            }
            return kq;
        }

        //Rút trích dữ liêu: select 
        public static List<ThucDonDTO> LayDSThucDon()
        {
            List<ThucDonDTO> _ds = new List<ThucDonDTO>();
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = "QLYQUANNHAU.[dbo].[LayDSThucDon]";
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connect.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucDonDTO td = new ThucDonDTO();
                td.MaTD = int.Parse(dt.Rows[i]["MaThucDon"].ToString());
                td.MaLoai = int.Parse(dt.Rows[i]["MaLoai"].ToString());
                td.TenTD = dt.Rows[i]["TenThucDon"].ToString();
                td.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                _ds.Add(td);
            }
            return _ds;
        }

        public static List<ThucDonDTO> LayDSThucDonTheoMaLoai(int maLoai)
        {
            List<ThucDonDTO> _ds = new List<ThucDonDTO>();
            string sql = "select * from QLYQUANNHAU.[dbo].[ThucDon] where MaLoai = " + maLoai;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucDonDTO td = new ThucDonDTO();
                td.MaTD = int.Parse(dt.Rows[i]["MaThucDon"].ToString());
                td.MaLoai = int.Parse(dt.Rows[i]["MaLoai"].ToString());
                td.TenTD = dt.Rows[i]["TenThucDon"].ToString();
                td.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                _ds.Add(td);
            }
            return _ds;
        }

        public static List<ThucDonDTO> LayDSMaTDVaTenTDTheoMaLoai(int maLoai)
        {
            List<ThucDonDTO> ds = new List<ThucDonDTO>();
            string sql = "select * from QLYQUANNHAU.[dbo].[ThucDon] where MaLoai = " + maLoai;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucDonDTO td = new ThucDonDTO();
                td.MaTD = int.Parse(dt.Rows[i]["MaThucDon"].ToString());
                td.TenTD = dt.Rows[i]["TenThucDon"].ToString();
                ds.Add(td);
            }
            return ds;
        }

        public static DataTable LayDanhSachTDTheoMaLoai(int maLoai)
        {
            string sql = "select td.MaThucDon as 'Mã TĐ', td.TenThucDon as 'Tên Thực Đơn', g.Gia as 'Đơn Giá', g.NgayADGia as 'Ngày AD', td.DonViTinh as 'Đơn Vị Tính', l.TenLoai as 'Loại TĐ' from QLYQUANNHAU.[dbo].[ThucDon] td, QLYQUANNHAU.[dbo].[Gia] g, QLYQUANNHAU.[dbo].[LoaiThucDon] l where td.MaLoai = l.MaLoai and td.MaThucDon = g.MaThucDon and td.MaLoai =" + maLoai;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;
        }

        public static string LayTenThucDonTuMaThucDon(int maTD)
        {
            string tenTD;
            string sql = "select TenThucDon from QLYQUANNHAU.[dbo].[ThucDon] where MaThucDon = " + maTD;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                tenTD = dt.Rows[0]["TenThucDon"].ToString();
            else
                return "";
            return tenTD;
        }

        public static int LayMaThucDonTuTenTD(string tenTD)
        {
            int maTD;
            string sql = "select MaThucDon from QLYQUANNHAU.[dbo].[ThucDon] where TenThucDon = N'" + tenTD + "'";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                maTD = int.Parse(dt.Rows[0]["MaThucDon"].ToString());
            else
                return 0;
            return maTD;
        }

        public static string LayDonViTinhTheoMaTD(int maTD)
        {
            string dvt;
            string sql = "select DonViTinh from QLYQUANNHAU.[dbo].[ThucDon] where MaThucDon = " + maTD;
            DataTable dt = DataProvider.ExecuteQuery(sql);
            dvt = dt.Rows[0][0].ToString();
            return dvt;
        }

        public static bool KiemTraThucDonNuocUong(int maTD)
        {
            bool kq;
            string sql = string.Format("select l.Nhom from QLYQUANNHAU.[dbo].[LoaiThucDon] l, QLYQUANNHAU.[dbo].[ThucDon] td where l.MaLoai = td.MaLoai and td.MaThucDon = {0}", maTD);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows[0][0].ToString() == "Thức Ăn")
                kq = true;
            else
                kq = false;
            return kq;
        }

        public static bool KiemTraTrungTenThucDon(string tenTD)
        {
            bool kq;
            string sql = "select * from QLYQUANNHAU.[dbo].[ThucDon] where TenThucDon = N'" + tenTD + "'";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                kq = false;
            else
                kq = true;
            return kq;
        }

        public static bool KiemTraTenTDCapNhat(string tenTD, int maTD)
        {
            bool kq;
            string sql = string.Format("select * from QLYQUANNHAU.[dbo].[ThucDon] where TenThucDon = N'{0}' and MaThucDon = {1}", tenTD, maTD);
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                kq = false;
            else
                kq = true;
            return kq;
        }

        public static DataTable TraCuuThucDonTheoTen(string tenTD)
        {
            string sql = string.Format("select td.MaThucDon as 'Mã TĐ', td.TenThucDon as 'Tên Thực Đơn', g.Gia as 'Đơn Giá', g.NgayADGia as 'Ngày AD', td.DonViTinh as 'Đơn Vị Tính', l.TenLoai as 'Loại TĐ' from QLYQUANNHAU.[dbo].[ThucDon] td, QLYQUANNHAU.[dbo].[Gia] g, QLYQUANNHAU.[dbo].[LoaiThucDon] l where td.TenThucDon like N'%{0}%' and td.MaThucDon = g.MaThucDon and td.MaLoai = l.MaLoai", tenTD);
            DataTable kq = DataProvider.ExecuteQuery(sql);
            return kq;
        }

        public static int MaTuTang()
        {
            string sql = "select * from QLYQUANNHAU.[dbo].[ThucDon]";
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
