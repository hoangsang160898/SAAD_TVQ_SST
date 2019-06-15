using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LogSachDTO
    {
        private int idLog;
        private int maSach;
        private int soLuong;
        private string thoiGian;
        private string hanhDong;

        public int IdLog { get => idLog; set => idLog = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string HanhDong { get => hanhDong; set => hanhDong = value; }

        public LogSachDTO(int idLog, int maSach, int soLuong, string thoiGian, string hanhDong)
        {
            this.idLog = idLog;
            this.maSach = maSach;
            this.soLuong = soLuong;
            this.thoiGian = thoiGian;
            this.hanhDong = hanhDong;
        }
        public LogSachDTO()
        {

        }
    }
}
