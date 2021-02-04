using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class LogSachBUS
    {
        public static bool insertToLog(LogSachDTO log)
        {
            return LogSachDAO.insertToLog(log);
        }
    }
}
