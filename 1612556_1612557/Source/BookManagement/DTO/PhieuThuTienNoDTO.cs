using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class PhieuThuTienNoDTO
    {
        private int maPhieu;

        public int MaPhieu { get => maPhieu; set => maPhieu = value; }

        public PhieuThuTienNoDTO(int maPhieu)
        {
            this.maPhieu = maPhieu;
        }
    }
}
