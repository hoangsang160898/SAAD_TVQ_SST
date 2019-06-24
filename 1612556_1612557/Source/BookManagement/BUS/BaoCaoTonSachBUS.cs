using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class BaoCaoTonSachBUS
    {
        public static List<BaoCaoTonSachDTO> loadReportBook(List<SachDTO> listBook, string startDate, string endDate)
        {
            return BaoCaoTonSachDAO.loadReportBook(listBook, startDate, endDate);
        }
    }
}
