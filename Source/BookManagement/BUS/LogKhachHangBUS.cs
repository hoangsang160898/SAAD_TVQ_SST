using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class LogKhachHangBUS
    {
        public static bool insertToLog(LogKhachHangDTO log)
        {
            return LogKhachHangDAO.insertToLog(log);
        }
    }
}
