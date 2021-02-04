using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ChiTietPhieuNhapDTO
    {
        private int maPhieuNhap;
        private int maSach;
        private int soLuong;

        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTietPhieuNhapDTO(int maPhieuNhap, int maSach, int soLuong)
        {
            this.maPhieuNhap = maPhieuNhap;
            this.maSach = maSach;
            this.soLuong = soLuong;
        }
    }
}
