using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class SachBUS
    {
        public static List<SachDTO> loadAll()
        {
            return SachDAO.loadAll();
        }
        public static List<SachDTO> loadByMaLoai(string MaLoai)
        {
            if (MaLoai == "0")
            {
                return SachDAO.loadAll();
            }
            return SachDAO.loadByMaLoai(MaLoai);
        }
        public static List<SachDTO> loadBySearch(string textToSearch, string MaLoai)
        {
            if (textToSearch == "")
            {
                return loadByMaLoai(MaLoai);
            }
            if (MaLoai == "0")
            {
                return SachDAO.loadBySearch(textToSearch);
            }
            return SachDAO.loadBySearch(textToSearch, MaLoai);
        }
        public static bool CheckUpdateSoLuong(string id, string soLuong)
        { 
            int luongTon = SachDAO.loadByID(id).SoLuong - int.Parse(soLuong);
            if (luongTon < 0)
                return false;
            if (Global.ControlRules.LuongTonSauKhiBan == 1)
            {
                if (luongTon < Global.quyDinh.LuongTonSauKhiBan)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool updateSoLuong(string id, string soLuong)
        {
            int luongTon = SachDAO.loadByID(id).SoLuong - int.Parse(soLuong);
            return SachDAO.updateSoLuong(id, luongTon.ToString());
        }
        public static SachDTO loadByID(string id)
        {
            return SachDAO.loadByID(id);
        }
        public static bool updateSach(SachDTO newSach)
        {
            int chenhLech = newSach.SoLuong - SachDAO.loadByID(newSach.MaSach.ToString()).SoLuong;
            if (Global.ControlRules.LuongNhapToiThieu == 1)
            {
                if (chenhLech <= Global.quyDinh.LuongNhapToiThieu && chenhLech !=0)
                {
                    return false;
                }
            }
            return SachDAO.updateSach(newSach);
        }
        public static bool updateImage(SachDTO newSach, string link)
        {
            return SachDAO.updateImage(newSach, link);
        }
        public static bool updateImageCover(SachDTO newSach, string link)
        {
            return SachDAO.updateImageCover(newSach, link);
        }
        public static bool addBook(SachDTO newSach, string link, string linkCover)
        {
            return SachDAO.addBook(newSach, link, linkCover);
        }
        public static List<SachDTO> loadLastedBook() => SachDAO.loadLastedBook();
        public static List<SachDTO> loadMostBuy()
        {
            var listID = SachDAO.loadIDMostBuy();
            var result = new List<SachDTO>();
            listID.ForEach(i =>
            {
                result.Add(loadByID(i.ToString()));
            });
            return result;
        }
    } 
}
