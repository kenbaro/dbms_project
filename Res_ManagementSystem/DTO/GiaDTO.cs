using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DTO
{
    public class GiaDTO
    {
        private DateTime _ngayADGia;
        private int _maTD;
        private double _gia;

        //Phuong thuc khoi tao mac dinh
        public GiaDTO()
        {
            _ngayADGia = DateTime.Today;
            _maTD = 0;
            _gia = 0;
        }

        //Phuong thuc khoi tao co tham so
        public GiaDTO(DateTime ngayAD, int maTD, double gia)
        {
            _ngayADGia = ngayAD;
            _maTD = maTD;
            _gia = gia;
        }

        //Phuong thuc khoi tao sao chep
        public GiaDTO(GiaDTO gia)
        {
            _ngayADGia = gia._ngayADGia;
            _maTD = gia._maTD;
            _gia = gia._gia;
        }

        //Properties
        public DateTime NgayADGia
        {
            get { return _ngayADGia; }
            set { _ngayADGia = value; }
        }

        public int MaTD
        {
            get { return _maTD; }
            set { _maTD = value; }
        }

        public double Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }
    }
}
