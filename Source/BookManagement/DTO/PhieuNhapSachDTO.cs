using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class PhieuNhapSachDTO
    {
        private int maPhieuNhap;
        private string ngayNhap;
        private double tongTien;
       
        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }

        public PhieuNhapSachDTO(int maPhieuNhap, string ngayNhap, double tongTien)
        {
            this.maPhieuNhap = maPhieuNhap;
            this.ngayNhap = ngayNhap;
            this.tongTien = tongTien;
        }
    }
}
