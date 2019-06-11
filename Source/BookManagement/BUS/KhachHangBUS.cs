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
            if (debt > 1 || debt < 0)
            {
                return false;
            }
            return KhachHangDAO.changeDebt(idCustomer, debt);
        }
        public static List<KhachHangDTO> searchCustomer(string textToSearch)
        {
            if (textToSearch != "")
                return KhachHangDAO.searchCustomer(textToSearch);
            return KhachHangDAO.loadAll();
        }
    }
}
