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
        private int maSach;
        private string tenSach;
        private string ngayBaoCao;
        private string ngayBatDau;
        private string ngayKetThuc;
        private int tonDau;
        private int phatSinh;
        private int tonCuoi;

        public int Id { get => id; set => id = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string NgayBaoCao { get => ngayBaoCao; set => ngayBaoCao = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public int TonDau { get => tonDau; set => tonDau = value; }
        public int PhatSinh { get => phatSinh; set => phatSinh = value; }
        public int TonCuoi { get => tonCuoi; set => tonCuoi = value; }

        public BaoCaoTonSachDTO(int id, int maSach,string tenSach, string ngayBaoCao, string ngayBatDau, string ngayKetThuc, int tonDau, int phatSinh ,int tonCuoi)
        {
            this.id = id;
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.ngayBaoCao = ngayBaoCao;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.tonDau = tonDau;
            this.phatSinh = phatSinh;
            this.tonCuoi = tonCuoi;
        }
    }
}
