using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaoCaoTonSachDTO
    {
        private int id;
        private SachDTO sach;
        private string ngayBaoCao;
        private string ngayBatDau;
        private string ngayKetThuc;
        private int tonDau;
        private int phatSinh;
        private int tonCuoi;

        public int Id { get => id; set => id = value; }
        public SachDTO Sach { get => sach; set => sach = value; }
        public string NgayBaoCao { get => ngayBaoCao; set => ngayBaoCao = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public int TonDau { get => tonDau; set => tonDau = value; }
        public int PhatSinh { get => phatSinh; set => phatSinh = value; }
        public int TonCuoi { get => tonCuoi; set => tonCuoi = value; }

        public BaoCaoTonSachDTO()
        {
            sach = new SachDTO();
        }
    }
}
