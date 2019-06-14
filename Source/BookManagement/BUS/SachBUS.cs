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
            if (Global.ControlRules[2] == 1)
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
            return SachDAO.updateSoLuong(id, soLuong);
        }
    } 
}
