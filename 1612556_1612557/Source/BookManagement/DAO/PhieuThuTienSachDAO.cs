using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class PhieuThuTienSachDAO
    {
        private static SqlConnection con;
        public static bool insert(PhieuThuTienSachDTO phieuThu)
        {
            string sCommand = string.Format(@"Insert into PhieuThuTienSach values('{0}',{1},{2},{3})", phieuThu.HoaDonBanSach.NgayTaoHoaDon, phieuThu.SoTienThu, phieuThu.HoaDonBanSach.MaKH, phieuThu.HoaDonBanSach.MaHoaDon);
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

        public static List<PhieuThuTienSachDTO> loadAll()
        {
            string sCommand = "Select* from PhieuThuTienSach";
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            List < PhieuThuTienSachDTO > result = new List<PhieuThuTienSachDTO>();
            for (int i=0;i < n;i++)
            {
                PhieuThuTienSachDTO phieuThu = new PhieuThuTienSachDTO();
                phieuThu.MaPhieu = int.Parse(dt.Rows[i]["MaPhieu"].ToString());
                phieuThu.HoaDonBanSach.NgayTaoHoaDon = dt.Rows[i]["NgayThuTien"].ToString();
                phieuThu.SoTienThu = double.Parse(dt.Rows[i]["SoTienThu"].ToString());
                phieuThu.HoaDonBanSach.MaKH = int.Parse(dt.Rows[i]["MaKH"].ToString());
                phieuThu.HoaDonBanSach.MaHoaDon = int.Parse(dt.Rows[i]["MaHoaDon"].ToString());
                result.Add(phieuThu);
            }
            DataProvider.closeConnection(con);
            return result;
        }

        
    }

}
