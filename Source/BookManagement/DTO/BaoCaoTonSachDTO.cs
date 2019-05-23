using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class BaoCaoTonSachDTO
    {
        private int id;
        private int maSach;
        private string ngayBaoCao;
        private string ngayBatDau;
        private string ngayKetThuc;
        private string tonDau;
        private string tonCuoi;

        public int Id { get => id; set => id = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public string NgayBaoCao { get => ngayBaoCao; set => ngayBaoCao = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string TonDau { get => tonDau; set => tonDau = value; }
        public string TonCuoi { get => tonCuoi; set => tonCuoi = value; }

        public BaoCaoTonSachDTO(int id, int maSach, string ngayBaoCao, string ngayBatDau, string ngayKetThuc, string tonDau, string tonCuoi)
        {
            this.id = id;
            this.maSach = maSach;
            this.ngayBaoCao = ngayBaoCao;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.tonDau = tonDau;
            this.tonCuoi = tonCuoi;
        }
    }
}
