using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DTO
{
    public class CT_HoaDonDTO
    {
        private int _soHD;
        private int _maTD;
        private int _soLuong;
        private double _donGia;

        //Phuong thuc khoi tao mac dinh
        public CT_HoaDonDTO()
        {
            _soHD = 0;
            _maTD = 0;
            _soLuong = 0;
            _donGia = 0;
        }

        //Phuong thuc khoi tao co tham so
        public CT_HoaDonDTO(int soHD, int maTD, int soLuong, double donGia)
        {
            _soHD = soHD;
            _maTD = maTD;
            _soLuong = soLuong;
            _donGia = donGia;
        }

        //Phuong thuc khoi tao sao chep
        public CT_HoaDonDTO(CT_HoaDonDTO cthd)
        {
            _soHD = cthd._soHD;
            _maTD = cthd._maTD;
            _soLuong = cthd._soLuong;
            _donGia = cthd._donGia;
        }

        //Properties
        public int SoHD
        {
            get { return _soHD; }
            set { _soHD = value; }
        }

        public int MaTD
        {
            get { return _maTD; }
            set { _maTD = value; }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        public double DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
    }

}
