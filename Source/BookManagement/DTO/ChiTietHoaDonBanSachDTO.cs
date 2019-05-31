using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DTO
{
    public class ChiTietHoaDonBanSachDTO
    {
        private int maHoaDon;
        private int maSach;
        private string tenSach;
        private string tacGia;
        private int soLuong;
        private double donGiaBan;
        private double tongDonGia;
        private BitmapImage hinhAnh;

        public string sourceHinh;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGiaBan { get => donGiaBan; set => donGiaBan = value; }
        public double TongDonGia { get => tongDonGia; set => tongDonGia = value; }
        public string sourceHinhAnh { get => sourceHinh; set => sourceHinh = value; }
        //public BitmapImage HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        //public ChiTietHoaDonBanSachDTO(int maHoaDon, int maSach, string tenSach, int soLuong, BitmapImage hinhAnh)
        public ChiTietHoaDonBanSachDTO(int maHoaDon, int maSach, string tenSach, string tacGia, int soLuong, double donGiaBan, string sourceHinh)
        {
            this.maHoaDon = maHoaDon;
            this.maSach = maSach;
            this.soLuong = soLuong;
            this.tacGia = tacGia;
            //this.hinhAnh = hinhAnh;
            this.sourceHinh = sourceHinh;
            this.tenSach = tenSach;
            this.donGiaBan = donGiaBan;
            this.tongDonGia = soLuong * donGiaBan;
        }
    }
}
