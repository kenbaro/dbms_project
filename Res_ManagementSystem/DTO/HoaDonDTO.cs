using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DTO
{
    public class HoaDonDTO
    {
        private int _soHD;
        private DateTime _timeLapHD;
        private int _msBan;
        private int _soKhach;
        private int _msNVLap;
        private int _msNVTT;
        private double _tongTien;

        //Phương thức khởi tạo mặc định
        public HoaDonDTO()
        {
            _soHD = 0;
            _timeLapHD = DateTime.Today;
            _msBan = 0;
            _soKhach = 0;
            _msNVLap = 0;
            _msNVTT = 0;
            _tongTien = 0;
        }

        //Phương thức khởi tạo có tham số
        public HoaDonDTO(int soHD, DateTime ngayLap, int msBan, int soKhach, int msNVLap, int msNVTT, double tongTien)
        {
            _soHD = soHD;
            _timeLapHD = ngayLap;
            _msBan = msBan;
            _soKhach = soKhach;
            _msNVLap = msNVLap;
            _msNVTT = msNVTT;
            _tongTien = tongTien;
        }

        //Phương thức khởi tạo sao chép.
        public HoaDonDTO(HoaDonDTO HoaDon)
        {
            _soHD = HoaDon._soHD;
            _timeLapHD = HoaDon._timeLapHD;
            _msBan = HoaDon._msBan;
            _soKhach = HoaDon._soKhach;
            _msNVLap = HoaDon._msNVLap;
            _msNVTT = HoaDon._msNVTT;
            _tongTien = HoaDon._tongTien;
        }

        //Properties
        public int SoHD
        {
            get { return _soHD; }
            set { _soHD = value; }
        }
        public DateTime TimeLapHD
        {
            get { return _timeLapHD; }
            set { _timeLapHD = value; }
        }

        public int MsBan
        {
            get { return _msBan; }
            set { _msBan = value; }
        }

        public int SoKhach
        {
            get { return _soKhach; }
            set { _soKhach = value; }
        }

        public int MsNVLap
        {
            get { return _msNVLap; }
            set { _msNVLap = value; }
        }

        public int MsNVTT
        {
            get { return _msNVTT; }
            set { _msNVTT = value; }
        }

        public double TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
    }
}
