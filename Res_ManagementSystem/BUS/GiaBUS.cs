using Res_ManagementSystem.DAO;
using Res_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.BUS
{
    public class GiaBUS
    {
        public static bool ThemGia(GiaDTO g)
        {
            bool kq = GiaDAO.ThemGia(g);
            return kq;
        }

        public static bool XoaGiaTheoMaTDVaNgayAD(int maTD, DateTime ngayAD)
        {
            bool kq = GiaDAO.XoaGiaTheoMaTDVaNgayAD(maTD, ngayAD);
            return kq;
        }

        public static bool CapNhatGia(GiaDTO g)
        {
            bool kq = GiaDAO.CapNhatGia(g);
            return kq;
        }

        public static double LayGiaTheoMaThucDon(int maTD)
        {
            double gia = GiaDAO.LayGiaTheoMaThucDon(maTD);
            return gia;
        }
    }
}
