using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class LogKhachHangDAO
    {
        private static SqlConnection con;
        public static bool insertToLog(LogKhachHangDTO log)
        {
            string sCommand = string.Format(@"Insert into Log_KhachHang(MaKH,ThoiGian,TienNo) values({0},'{1}',{2})", log.MaKH, log.ThoiGian, log.TienNo);
            con = DataProvider.openConnection();
            bool result;
            try
            {
                result = DataProvider.executeNonQuery(sCommand, con);
                DataProvider.closeConnection(con);
            }
            catch
            {
                result = false;
                DataProvider.closeConnection(con);
            }
            return result;
        }
    }
}
