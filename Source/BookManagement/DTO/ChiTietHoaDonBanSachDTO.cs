using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ChiTietHoaDonBanSachDTO
    {
        private int maHoaDon;
        private int maSach;
        private int soLuong;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTietHoaDonBanSachDTO(int maHoaDon, int maSach, int soLuong)
        {
            this.maHoaDon = maHoaDon;
            this.maSach = maSach;
            this.soLuong = soLuong;
        }
    }
}
