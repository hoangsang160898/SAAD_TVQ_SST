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

        public static List<ChiTietHoaDonBanSachDTO> loadAll()
        {
            string sCommand = "select MaHoaDon, MaSach, SoLuong from ChiTietHoaDonBanSach";
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            List<ChiTietHoaDonBanSachDTO> listChiTiet = new List<ChiTietHoaDonBanSachDTO>();
            for (int i = 0;i<n;i++)
            {
                ChiTietHoaDonBanSachDTO chiTiet = new ChiTietHoaDonBanSachDTO();
                chiTiet.MaHoaDon = int.Parse(dt.Rows[i]["MaHoaDon"].ToString());
                chiTiet.Sach.MaSach = int.Parse(dt.Rows[i]["MaSach"].ToString());
                chiTiet.SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                listChiTiet.Add(chiTiet);
            }
            DataProvider.closeConnection(con);
            return listChiTiet;
        }
        public static int countByMaHoaDon(string maHoaDon)
        {
            string sCommand = "Select count(MaHoaDon) from ChiTietHoaDonBanSach where MaHoaDon = " + maHoaDon;
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return 0;
            }
            DataProvider.closeConnection(con);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public static ChiTietHoaDonBanSachDTO loadOneDetail(string MaHoaDon)
        {
            string sCommand = "select top 1 * from ChiTietHoaDonBanSach where MaHoaDon = " + MaHoaDon;
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            ChiTietHoaDonBanSachDTO chiTiet = new ChiTietHoaDonBanSachDTO();
            chiTiet.MaHoaDon = int.Parse(dt.Rows[0]["MaHoaDon"].ToString());
            chiTiet.Sach.MaSach = int.Parse(dt.Rows[0]["MaSach"].ToString());
            chiTiet.SoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
            DataProvider.closeConnection(con);
            return chiTiet;
        }
        public static List<ChiTietHoaDonBanSachDTO> loadByMaHoaDon(string MaHoaDon)
        {
            string sCommand = "Select* from ChiTietHoaDonBanSach where MaHoaDon = " + MaHoaDon;
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            List<ChiTietHoaDonBanSachDTO> listChiTiet = new List<ChiTietHoaDonBanSachDTO>();
            for (int i = 0; i < n; i++)
            {
                ChiTietHoaDonBanSachDTO chiTiet = new ChiTietHoaDonBanSachDTO();
                chiTiet.MaHoaDon = int.Parse(dt.Rows[i]["MaHoaDon"].ToString());
                chiTiet.Sach.MaSach = int.Parse(dt.Rows[i]["MaSach"].ToString());
                chiTiet.SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                listChiTiet.Add(chiTiet);
            }
            DataProvider.closeConnection(con);
            return listChiTiet;
        }
    }
}
