using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class PhieuThuTienDTO
    {
        private int maPhieu;
        private string ngayThuTien;
        private double soTienThu;
        private int maKH;

        public int MaPhieu { get => maPhieu; set => maPhieu = value; }
        public string NgayThuTien { get => ngayThuTien; set => ngayThuTien = value; }
        public double SoTienThu { get => soTienThu; set => soTienThu = value; }
        public int MaKH { get => maKH; set => maKH = value; }

        public PhieuThuTienDTO(int maPhieu, string ngayThuTien, double soTienThu, int maKH)
        {
            this.maPhieu = maPhieu;
            this.ngayThuTien = ngayThuTien;
            this.soTienThu = soTienThu;
            this.maKH = maKH;
        }
    }
}
