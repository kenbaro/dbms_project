using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Res_ManagementSystem.DAO
{
    public class GiaDAO
    {
        public static bool ThemGia(GiaDTO g)
        {
            /*string sql = string.Format("set dateformat DMY insert into QLYQUANNHAU.[dbo].[Gia] values (convert(varchar(10),'{0}', 103), {1}, {2})", g.NgayADGia, g.MaTD, g.Gia);
            bool kq = DataProvider.ExecuteNonQuery(sql);
            return kq;*/
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[ThemGia]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@NgayADGia", g.NgayADGia);
            command.Parameters.AddWithValue("@MaTD", g.MaTD);
            command.Parameters.AddWithValue("@Gia", g.Gia);
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

        public static bool XoaGiaTheoMaTDVaNgayAD(int maTD, DateTime ngayAD)
        {
            /*string sql = string.Format("set dateformat DMY delete QLYQUANNHAU.[dbo].[Gia] where MaThucDon = {0} and convert(varchar(10),NgayADGia, 103) = convert(varchar(10), convert(datetime,'{1}'), 103)", maTD, ngayAD);
            bool kq = DataProvider.ExecuteNonQuery(sql);
            return kq;*/
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[XoaGiaTheoMaTDVaNgayAD]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@NgayADGia", ngayAD);
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

        public static bool CapNhatGia(GiaDTO g)
        {
            /*string sql = string.Format("set dateformat DMY update QLYQUANNHAU.[dbo].[Gia] set NgayADGia = '{0}', Gia = {1} where MaThucDon = {2}", g.NgayADGia, g.Gia, g.MaTD);
            bool kq = DataProvider.ExecuteNonQuery(sql);
            return kq;*/
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[CapNhatGia]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@NgayADGia", g.NgayADGia);
            command.Parameters.AddWithValue("@MaTD", g.MaTD);
            command.Parameters.AddWithValue("@Gia", g.Gia);
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

        public static double LayGiaTheoMaThucDon(int maTD)
        {
            double gia;
            /* string sql = string.Format("select Gia from QLYQUANNHAU.[dbo].[Gia] where MaThucDon = {0}", maTD);
             DataTable dt = new DataTable();
             dt = DataProvider.ExecuteQuery(sql);*/
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = "QLYQUANNHAU.[dbo].[LayGiaTheoMaThucDon]";
            command.Parameters.AddWithValue("@MaTD", maTD);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connect.Close();
            if (dt.Rows.Count > 0)
                gia = double.Parse(dt.Rows[0]["Gia"].ToString());
            else
                gia = 0;
            return gia;
        }

        public static int MaTuTang()
        {
            string sql = "select * from QLYQUANNHAU.[dbo].[Gia]";
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
