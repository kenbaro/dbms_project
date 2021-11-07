using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DAO
{
    public class BanDAO
    {
        public static List<BanDTO> LayDSBan()
        {
            List<BanDTO> _ds = new List<BanDTO>();
            string sql = "select * from QLYQUANNHAU.[dbo].[BanAn]";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BanDTO b = new BanDTO();
                b.MaBan = int.Parse(dt.Rows[i][0].ToString());
                b.SoGhe = int.Parse(dt.Rows[i][1].ToString());
                _ds.Add(b);
            }
            return _ds;
        }
    }
}
