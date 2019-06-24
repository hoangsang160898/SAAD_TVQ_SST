using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaoCaoCongNoDTO
    {
        private int id;
        private KhachHangDTO khachHang;
        private string ngayBaoCao;
        private string ngayBatDau;
        private string ngayKetThuc;
        private double noDau;
        private double phatSinh;
        private double noCuoi;

        public int Id { get => id; set => id = value; }
        public string NgayBaoCao { get => ngayBaoCao; set => ngayBaoCao = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public double NoDau { get => noDau; set => noDau = value; }
        public double PhatSinh { get => phatSinh; set => phatSinh = value; }
        public double NoCuoi { get => noCuoi; set => noCuoi = value; }
        public KhachHangDTO KhachHang { get => khachHang; set => khachHang = value; }

        public BaoCaoCongNoDTO()
        {
            khachHang = new KhachHangDTO();
        }
    }

}
