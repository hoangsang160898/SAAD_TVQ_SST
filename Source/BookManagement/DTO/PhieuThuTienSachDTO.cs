using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class PhieuThuTienSachDTO
    {
        private int maPhieu;
        private int maHoaDon;

        public int MaPhieu { get => maPhieu; set => maPhieu = value; }
        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }

        public PhieuThuTienSachDTO(int maPhieu, int maHoaDon)
        {
            this.maPhieu = maPhieu;
            this.maHoaDon = maHoaDon;
        }
    }
}
