using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DTO
{
    public class ThucDonDTO
    {
        private int _maTD;
        private int _maLoai;
        private string _tenTD;
        private string _donViTinh;

        //Phương thức khởi tạo mặc định
        public ThucDonDTO()
        {
            _maTD = 0;
            _maLoai = 0;
            _tenTD = "";
            _donViTinh = "";
        }

        //Phương thức khởi tạo có tham số
        public ThucDonDTO(int maNV, int maLoai, string tenTD, string donViTinh)
        {
            _maTD = maNV;
            _maLoai = maLoai;
            _tenTD = tenTD;
            _donViTinh = donViTinh;
        }

        //Phương thức khởi tạo sao chép.
        public ThucDonDTO(ThucDonDTO thucDon)
        {
            _maTD = thucDon._maTD;
            _maLoai = thucDon._maLoai;
            _tenTD = thucDon._tenTD;
            _donViTinh = thucDon._donViTinh;
        }

        //Properties
        public int MaTD
        {
            get { return _maTD; }
            set { _maTD = value; }
        }
        public int MaLoai
        {
            get { return _maLoai; }
            set { _maLoai = value; }
        }
        public string TenTD
        {
            get { return _tenTD; }
            set { _tenTD = value; }
        }
        public string DonViTinh
        {
            get { return _donViTinh; }
            set { _donViTinh = value; }
        }
    }
}
