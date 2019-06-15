using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class LogKhachHangDTO
    {
        private int idLog;
        private int maKH;
        private string thoiGian;
        private double tienNo;

        public int IdLog { get => idLog; set => idLog = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public string ThoiGian { get => thoiGian; set => thoiGian = value; }
        public double TienNo { get => tienNo; set => tienNo = value; }

        public LogKhachHangDTO(int idLog, int maKH, string thoiGian, double tienNo)
        {
            this.idLog = idLog;
            this.maKH = maKH;
            this.thoiGian = thoiGian;
            this.tienNo = tienNo;
        }
        public LogKhachHangDTO()
        {

        }
    }
}
