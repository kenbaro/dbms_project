using Res_ManagementSystem.DAO;
using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.BUS
{
    public class BanBUS
    {
        public static List<BanDTO> LayDSBan()
        {
            List<BanDTO> _ds;
            _ds = BanDAO.LayDSBan();
            return _ds;
        }
    }
}
