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
   
        private int soLuong;
      
        private double tongDonGia;
      

        private SachDTO sach;

     

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }

      
        public int SoLuong { get => soLuong; set => soLuong = value; }
      
        public double TongDonGia { get => tongDonGia; set => tongDonGia = value; }

     
        public SachDTO Sach { get => sach; set => sach = value; }

       

        public ChiTietHoaDonBanSachDTO()
        {

        }
        public ChiTietHoaDonBanSachDTO(ChiTietHoaDonBanSachDTO src)
        {
            Sach = new SachDTO(src.Sach);
            maHoaDon = src.maHoaDon;
            soLuong = src.soLuong;
            tongDonGia = src.tongDonGia;
        }
    }
}
