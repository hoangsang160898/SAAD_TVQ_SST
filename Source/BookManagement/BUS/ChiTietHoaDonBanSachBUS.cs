using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class ChiTietHoaDonBanSachBUS
    {
        public static List<ChiTietHoaDonBanSachDTO> copyList(List<ChiTietHoaDonBanSachDTO> listChiTietHoaDon)
        {
            var newList = new List<ChiTietHoaDonBanSachDTO>();
            for (int i = 0; i < listChiTietHoaDon.Count; i++)
            {
                ChiTietHoaDonBanSachDTO chiTiet = new ChiTietHoaDonBanSachDTO();
                chiTiet.MaHoaDon = listChiTietHoaDon[i].MaHoaDon;
                chiTiet.Sach = new SachDTO(listChiTietHoaDon[i].Sach);
                chiTiet.SoLuong = listChiTietHoaDon[i].SoLuong;
                chiTiet.TongDonGia = listChiTietHoaDon[i].TongDonGia;
                newList.Add(chiTiet);
            }
            return newList;
        }
        public static bool insertChiTietHoaDon(ChiTietHoaDonBanSachDTO chiTiet)
        {
            return ChiTietHoaDonBanSachDAO.insertChiTietHoaDon(chiTiet);
        }
    }
}
