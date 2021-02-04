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
        public static List<ChiTietHoaDonBanSachDTO> loadAll()
        {
            var listChiTiet = ChiTietHoaDonBanSachDAO.loadAll();
            listChiTiet.ForEach(i =>
            {
                i.Sach = SachBUS.loadByID(i.Sach.MaSach.ToString());
            });
            return listChiTiet;
        }
        public static int countByMaHoaDon(string maHoaDon)
        {
            return ChiTietHoaDonBanSachDAO.countByMaHoaDon(maHoaDon);
        }
        public static ChiTietHoaDonBanSachDTO loadOneDetail(string MaHoaDon)
        {
            return ChiTietHoaDonBanSachDAO.loadOneDetail(MaHoaDon);
        }
        public static List<ChiTietHoaDonBanSachDTO> loadByMaHoaDon(string MaHoaDon)
        {
            var listChiTiet = ChiTietHoaDonBanSachDAO.loadByMaHoaDon(MaHoaDon);
            listChiTiet.ForEach(i =>
            {
                i.Sach = SachBUS.loadByID(i.Sach.MaSach.ToString());
                i.TongDonGia = i.SoLuong * i.Sach.DonGiaBan;
            });
            return listChiTiet;
        }
    }
}
