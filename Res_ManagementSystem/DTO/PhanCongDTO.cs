using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_ManagementSystem.DTO
{
    public class PhanCongDTO
    {
        private int _msNV;
        private int _msBan;
        private int _ca;

        //Phuong thuc khoi tao mac dinh
        public PhanCongDTO()
        {
            _msNV = 0;
            _msBan = 0;
            _ca = 0;
        }

        //Phuong thuc khoi tao co tham so
        public PhanCongDTO(int msNV, int msBan, int ca)
        {
            _msNV = msNV;
            _msBan = msBan;
            _ca = ca;
        }

        //Phuong thuc khoi tao sao chep
        public PhanCongDTO(PhanCongDTO pc)
        {
            _msNV = pc._msNV;
            _msBan = pc._msBan;
            _ca = pc._ca;
        }

        //Properties
        public int MsNV
        {
            get { return _msNV; }
            set { _msNV = value; }
        }

        public int Ca
        {
            get { return _ca; }
            set { _ca = value; }
        }

        public int MsBan
        {
            get { return _msBan; }
            set { _msBan = value; }
        }
    }
}
