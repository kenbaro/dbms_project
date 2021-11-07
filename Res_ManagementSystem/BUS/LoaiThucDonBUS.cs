using Res_ManagementSystem.DAO;
using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.BUS
{
    public class LoaiThucDonBUS
    {
        //Rút trích dữ liệu: select
        public static List<LoaiThucDonDTO> LayDSLoaiThucDon()
        {
            List<LoaiThucDonDTO> _ds;
            _ds = LoaiThucDonDAO.LayDSLoaiThucDon();
            return _ds;
        }

        public static int LayMaLoaiTuTenLoai(string tenLoai)
        {
            int maLoai = LoaiThucDonDAO.LayMaLoaiTuTenLoai(tenLoai);
            return maLoai;
        }
    }
}
