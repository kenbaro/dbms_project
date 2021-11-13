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
    public class PhanCongDAO
    {
        public static DataTable LayDSPhanCong()
        {
            /*string sql = "select Ca as 'Ca', HoTen as 'Tên Nhân Viên', MaSoBan as 'Mã Số Bàn' from QLYQUANNHAU.[dbo].[PhanCong], QLYQUANNHAU.[dbo].[NhanVien] where QLYQUANNHAU.[dbo].[PhanCong].MaNV = QLYQUANNHAU.[dbo].[NhanVien].MaNV";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            return dt;*/
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = "QLYQUANNHAU.[dbo].[LayDSPhanCong]";
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connect.Close();
            return dt;

        }

        public static bool ThemPhanCong(PhanCongDTO pc)
        {
            /* bool kq;
             string sql = string.Format("insert into QLYQUANNHAU.[dbo].[PhanCong] values({0}, {1}, {2})", pc.Ca, pc.MsNV, pc.MsBan);
             kq = DataProvider.ExecuteNonQuery(sql);
             return kq;*/
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[ThemPhanCong]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@Ca", pc.Ca);
            command.Parameters.AddWithValue("@MsNV", pc.MsNV);
            command.Parameters.AddWithValue("@MsBan", pc.MsBan);

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

        public static bool XoaPhanCong(PhanCongDTO pc)
        {
            /* bool kq;
             string sql = string.Format("delete QLYQUANNHAU.[dbo].[PhanCong] where Ca = {0} and MaNV = {1} and MaSoBan = {2}", pc.Ca, pc.MsNV, pc.MsBan);
             kq = DataProvider.ExecuteNonQuery(sql);
             return kq;*/
            bool kq;
            string sql = string.Format("QLYQUANNHAU.[dbo].[XoaPhanCong]");
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@Ca", pc.Ca);
            command.Parameters.AddWithValue("@MsNV", pc.MsNV);
            command.Parameters.AddWithValue("@MsBan", pc.MsBan);

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

        public static int LayMaNVTheoMaBanVaCa(int maBan, int ca)
        {
            /*string sql = string.Format("select MaNV from QLYQUANNHAU.[dbo].[PhanCong] where MaSoBan = {0} and Ca = {1}", maBan, ca);
            DataTable dt = DataProvider.ExecuteQuery(sql);*/
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(DataProvider.connectionString());
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = "QLYQUANNHAU.[dbo].[LayMaNVTheoMaBanVaCa]";
            command.Parameters.AddWithValue("@MsBan", maBan);
            command.Parameters.AddWithValue("@Ca", ca);

            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connect.Close();
            int maNV = int.Parse(dt.Rows[0]["MaNV"].ToString());
            return maNV;
        }

        public static int LayCaTheoGio(int gio)
        {
            int ca;
            if (gio >= 7 && gio < 11)
                ca = 1;
            else
            {
                if (gio >= 11 && gio < 18)
                    ca = 2;
                else
                    ca = 3;
            }
            return ca;
        }
    }
}
