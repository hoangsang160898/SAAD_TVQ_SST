using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class KhachHangBUS
    {
        public static List<KhachHangDTO> loadAll()
        {
            return KhachHangDAO.loadAll();
        }
        public static bool changeDebt(int idCustomer, double debt)
        {
            return KhachHangDAO.changeDebt(idCustomer, debt);
        }
        public static List<KhachHangDTO> searchCustomer(string textToSearch)
        {
            if (textToSearch != "")
                return KhachHangDAO.searchCustomer(textToSearch);
            return KhachHangDAO.loadAll();
        }
        public static KhachHangDTO searchByPhone(string phone)
        {
            return KhachHangDAO.searchByPhone(phone);
        }
        public static bool checkNoToiDa(string idCustomer)
        {
            double tienNo = KhachHangDAO.searchById(idCustomer).TienNo;
            if (Global.ControlRules[0] == 1)
            {
                if (tienNo > Global.quyDinh.NoToiDa)
                    return false;
            }
            return true;
        }
        public static KhachHangDTO searchById(string id)
        {
            return KhachHangDAO.searchById(id);
        }
    }
}
