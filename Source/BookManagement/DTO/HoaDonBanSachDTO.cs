using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonBanSachDTO
    {
        private int maHoaDon;
        private double tongTien;
        private int maKH;
        private string ngayTaoHoaDon;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public string NgayTaoHoaDon { get => ngayTaoHoaDon; set => ngayTaoHoaDon = value; }
   
        public HoaDonBanSachDTO(int maHoaDon, double tongTien, int maKH, string ngayTaoHoaDon)
        {
            this.maHoaDon = maHoaDon;
            this.tongTien = tongTien;
            this.maKH = maKH;
            this.ngayTaoHoaDon = ngayTaoHoaDon;
        
        }
    }
}
