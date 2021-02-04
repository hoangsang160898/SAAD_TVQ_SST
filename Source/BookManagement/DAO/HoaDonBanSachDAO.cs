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
            string sCommand = string.Format(@"Insert into HOADONBANSACH(TongTien,MaKH,NgayTao) values({0},{1},'{2}')", hoaDon.TongTien, hoaDon.MaKH, hoaDon.NgayTaoHoaDon);
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

        public static HoaDonBanSachDTO getLastHoaDon()
        {
            string sCommand = "Select top 1 * from HoaDonBanSach order by MaHoaDon desc";
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            HoaDonBanSachDTO hoaDon = new HoaDonBanSachDTO();
            hoaDon.MaHoaDon = int.Parse(dt.Rows[0]["MaHoaDon"].ToString());
            hoaDon.MaKH = int.Parse(dt.Rows[0]["MaKH"].ToString());
            hoaDon.NgayTaoHoaDon = dt.Rows[0]["NgayTao"].ToString();
            hoaDon.TongTien = double.Parse(dt.Rows[0]["TongTien"].ToString());
            DataProvider.closeConnection(con);
            return hoaDon;
        }

        public static HoaDonBanSachDTO loadByMaHoaDon(string MaHoaDon)
        {
            string sCommand = "select* from HoaDonBanSach where MaHoaDon = " + MaHoaDon;
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            HoaDonBanSachDTO hoaDon = new HoaDonBanSachDTO();
            hoaDon.MaHoaDon = int.Parse(dt.Rows[0]["MaHoaDon"].ToString());
            hoaDon.MaKH = int.Parse(dt.Rows[0]["MaKH"].ToString());
            hoaDon.NgayTaoHoaDon = dt.Rows[0]["NgayTao"].ToString();
            hoaDon.TongTien = double.Parse(dt.Rows[0]["TongTien"].ToString());
            DataProvider.closeConnection(con);
            return hoaDon;
        }
    }
}
