using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DAO
{
   public class DataProvider
    {
        private static String _connectionString = @"Data Source=DESKTOP-M75TIM6\NPTKEII;
                                                    Integrated Security=True;
                                                    Connect Timeout=30;Encrypt=False;
                                                    TrustServerCertificate=False;
                                                    ApplicationIntent=ReadWrite;
                                                    MultiSubnetFailover=False";
                                                    
        public SqlConnection getConnection
        {
            get { return con; }
        }                                       

        public static DataTable ExecuteQuery(String sql)
        {
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connect.Close();
            return dt;
        }

        //ExecuteNonQuery: Insert, Update, Delete
        public static bool ExecuteNonQuery(String sql)
        {
            bool kq;
            SqlConnection connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                kq = true;
            }
            else
            {
                kq = false;
            }
            connect.Close();
            return kq;
        }

        //View Stored Procedure
        //public static DataTable ViewStoredProc(string procName, int SoHD)
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection connect = new SqlConnection(_connectionString);
        //    SqlCommand command = connect.CreateCommand();
        //    command.CommandText = procName;
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.AddWithValue("@SoHD", SoHD);
        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    adapter.SelectCommand = command;
        //    adapter.Fill(dt);
        //    connect.Close();
        //    return dt;
        //}
     public static int[,] Assignment()
     {
            // Tạo mảng chia ca
            //DataTable _ds = Res_ManagementSystem.BUS.StaffBUS.LayDSNhanVien();
            // int[,] IntArray = new int[i, j];
            int[,] IntArray =
            {
                //Ca 1,3
                {1,0,1},

                //Ca 1,2
                {1,1,0},

                //Ca 2,3
                {0,1,1},

                //Ca 1,2,3
                {1,1,1},
                // Duoc Nghi
                {0,0,0}

            };
            return IntArray;

     }
   }
}
