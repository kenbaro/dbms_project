using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DTO
{
    public class LoaiThucDonDTO
    {
        private int _maLoai;
        private string _nhom;
        private string _tenLoai;

        //Phương thức khởi tạo mặc định
        public LoaiThucDonDTO()
        {
            _maLoai = 0;
            _nhom = "";
            _tenLoai = "";
        }

        //Phương thức khởi tạo có tham số
        public LoaiThucDonDTO(int maLoai, string nhom, string tenLoai)
        {
            _maLoai = maLoai;
            _nhom = nhom;
            _tenLoai = tenLoai;
        }

        //Phương thức khởi tạo sao chép.
        public LoaiThucDonDTO(LoaiThucDonDTO loai)
        {
            _maLoai = loai._maLoai;
            _nhom = loai._nhom;
            _tenLoai = loai._tenLoai;
        }

        //Properties
        public int MaLoai
        {
            get { return _maLoai; }
            set { _maLoai = value; }
        }
        public string Nhom
        {
            get { return _nhom; }
            set { _nhom = value; }
        }
        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }
    }
}
