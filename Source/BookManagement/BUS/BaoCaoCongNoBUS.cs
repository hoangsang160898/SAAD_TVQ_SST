using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class BaoCaoCongNoBUS
    {
        public static List<BaoCaoCongNoDTO> loadReport(List<KhachHangDTO> listCustomer, string startDate, string endDate)
        {
            return BaoCaoCongNoDAO.loadReport(listCustomer, startDate, endDate);
        }
    }
}
