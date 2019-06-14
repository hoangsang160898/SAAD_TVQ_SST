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
   public class HoaDonBanSachDAO
    {
        private static SqlConnection con;
        public static bool insertHoaDon(HoaDonBanSachDTO hoaDon)
        {
            string sCommand = string.Format(@"Insert into HOADONBANSACH values({0},{1},'{2}')", hoaDon.TongTien, hoaDon.MaKH, hoaDon.NgayTaoHoaDon);
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
