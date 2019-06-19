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
    public class LogSachDAO
    {
        private static SqlConnection con;
        public static bool insertToLog(LogSachDTO log)
        {
            string sCommand = string.Format(@"Insert into Log_Sach(MaSach,SoLuong,ThoiGian,HanhDong) values({0},{1},'{2}','{3}')", log.MaSach, log.SoLuong, log.ThoiGian, log.HanhDong);
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
