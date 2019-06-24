using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private int maKH;
        private string hoTen;
        private string diaChi;
        private string email;
        private string sdt;
        private double tienNo;

        public int MaKH { get => maKH; set => maKH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public double TienNo { get => tienNo; set => tienNo = value; }

        public KhachHangDTO(int maKH, string hoTen, string diaChi, string email, string sdt, double tienNo)
        {
            this.maKH = maKH;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.email = email;
            this.sdt = sdt;
            this.tienNo = tienNo;
        }
        public KhachHangDTO()
        {

        }
    }
}
