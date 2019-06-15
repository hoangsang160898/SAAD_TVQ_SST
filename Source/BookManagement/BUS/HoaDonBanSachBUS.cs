using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class HoaDonBanSachBUS
    {
        public static bool insertHoaDon(HoaDonBanSachDTO hoaDon)
        {
            return HoaDonBanSachDAO.insertHoaDon(hoaDon);
        }
        public static HoaDonBanSachDTO getLastHoaDon()
        {
            return HoaDonBanSachDAO.getLastHoaDon();
        }
        public static HoaDonBanSachDTO loadByMaHoaDon(string MaHoaDon)
        {
            return HoaDonBanSachDAO.loadByMaHoaDon(MaHoaDon);
        }
    }
}
