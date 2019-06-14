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
    public class ChiTietHoaDonBanSachDAO
    {
        private static SqlConnection con;
        public static bool insertChiTietHoaDon(ChiTietHoaDonBanSachDTO chiTiet)
        {
            string sCommand = string.Format(@"insert into ChiTietHoaDonBanSach(MaHoaDon,MaSach,SoLuong) values({0},{1},{2})", chiTiet.MaHoaDon, chiTiet.Sach.MaSach, chiTiet.SoLuong);
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
