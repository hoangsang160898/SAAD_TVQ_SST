using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class QuyDinhDTO
    {
        private double noToiDa;
        private int luongTonSauKhiBan;
        private int luongNhapToiThieu;
        private int luongTonToiThieuKhiNhap;

        public double NoToiDa { get => noToiDa; set => noToiDa = value; }
        public int LuongTonSauKhiBan { get => luongTonSauKhiBan; set => luongTonSauKhiBan = value; }
        public int LuongNhapToiThieu { get => luongNhapToiThieu; set => luongNhapToiThieu = value; }
        public int LuongTonToiThieuKhiNhap { get => luongTonToiThieuKhiNhap; set => luongTonToiThieuKhiNhap = value; }

        public QuyDinhDTO()
        {

        }

        public QuyDinhDTO(double noToiDa, int luongTonSauKhiBan, int luongNhapToiThieu, int luongTonToiThieuKhiNhap)
        {
            this.noToiDa = noToiDa;
            this.luongTonSauKhiBan = luongTonSauKhiBan;
            this.luongNhapToiThieu = luongNhapToiThieu;
            this.luongTonToiThieuKhiNhap = luongTonToiThieuKhiNhap;
        }
    }
}
