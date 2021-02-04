using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThuTienSachDTO
    {
        private int maPhieu;
        private double soTienThu;
        private HoaDonBanSachDTO hoaDonBanSach;
        private int soLuongSachKhac;
        private string tenSachDaiDien;
        private string tenKH;
        public int MaPhieu { get => maPhieu; set => maPhieu = value; }
        public double SoTienThu { get => soTienThu; set => soTienThu = value; }
        public HoaDonBanSachDTO HoaDonBanSach { get => hoaDonBanSach; set => hoaDonBanSach = value; }
        public int SoLuongSachKhac { get => soLuongSachKhac; set => soLuongSachKhac = value; }
        public string TenSachDaiDien { get => tenSachDaiDien; set => tenSachDaiDien = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }

        public PhieuThuTienSachDTO()
        {
            HoaDonBanSach = new HoaDonBanSachDTO();
        }
    }
}
