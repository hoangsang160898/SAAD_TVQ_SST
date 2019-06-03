using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThuTienDTO
    {
        private int maPhieu;
        private string ngayThuTien;
        private double soTienThu;
        private double soTienHoaDonBanSach;
        private int maKH;
        private int soLuongSachKhac;
        private string tenKhachHang;
        private string tenSachBatKi; //Lấy bất kì tên 1 quyển sách trong tất cả các phiếu thu tiền sách DTO

        public int MaPhieu { get => maPhieu; set => maPhieu = value; }
        public string NgayThuTien { get => ngayThuTien; set => ngayThuTien = value; }
        public double SoTienThu { get => soTienThu; set => soTienThu = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public int SoLuongSachKhac { get => soLuongSachKhac; set => soLuongSachKhac = value; }
        public string TenSachBatKi { get => tenSachBatKi; set => tenSachBatKi = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public double SoTienHoaDonBanSach { get => soTienHoaDonBanSach; set => soTienHoaDonBanSach = value; }
        public PhieuThuTienDTO(int maPhieu, double soTienThu, int maKH, string ngayThuTien, int soLuongSachKhac, string tenSachBatKi, string tenKhachHang, double soTienHoaDonBanSach)
        {
            this.maPhieu = maPhieu;
            this.ngayThuTien = ngayThuTien;
            this.soTienThu = soTienThu;
            this.maKH = maKH;
            this.soLuongSachKhac = soLuongSachKhac;
            this.tenSachBatKi = tenSachBatKi;
            this.tenKhachHang = tenKhachHang;
            this.soTienHoaDonBanSach = soTienHoaDonBanSach;
        }
    }
}
