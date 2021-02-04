using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class PhieuThuTienSachBUS
    {
        public static bool insert(PhieuThuTienSachDTO phieuThu)
        {
            return PhieuThuTienSachDAO.insert(phieuThu);
        }

        public static List<PhieuThuTienSachDTO> loadAll()
        {
            var list =  PhieuThuTienSachDAO.loadAll();
            list.ForEach(i =>
            {
                i.HoaDonBanSach = HoaDonBanSachBUS.loadByMaHoaDon(i.HoaDonBanSach.MaHoaDon.ToString());
                i.TenKH = KhachHangBUS.searchById(i.HoaDonBanSach.MaKH.ToString()).HoTen;
            });
            return list;
        }
       
    }
}
