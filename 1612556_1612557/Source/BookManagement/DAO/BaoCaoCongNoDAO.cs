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
   public class BaoCaoCongNoDAO
    {
        private static SqlConnection con;
        public static List<BaoCaoCongNoDTO> loadReport(List<KhachHangDTO> listCustomer, string startDate, string endDate)
        {
            int n = listCustomer.Count;
            string sCommand;
            List<BaoCaoCongNoDTO> result = new List<BaoCaoCongNoDTO>();
            for (int i = 0; i < n; i++)
            {
                BaoCaoCongNoDTO report = new BaoCaoCongNoDTO();
                sCommand = string.Format(@"Select * from Log_KhachHang where MaKH = {0} and  ThoiGian >= '{1}' and ThoiGian <= '{2}' order by THOIGIAN ", listCustomer[i].MaKH, startDate, endDate);
                con = DataProvider.openConnection();
                DataTable dt = DataProvider.getDataTable(sCommand, con);
                report.KhachHang.MaKH = listCustomer[i].MaKH;
                report.KhachHang.HoTen = listCustomer[i].HoTen;
                report.NgayBaoCao = DateTime.Now.ToString();
                report.NgayBatDau = startDate;
                report.NgayKetThuc = endDate;
                int m = dt.Rows.Count;
                if (m > 0)
                {
                    report.NoDau = double.Parse(dt.Rows[0]["TienNo"].ToString());
                    report.NoCuoi = listCustomer[i].TienNo;
                    report.PhatSinh = Math.Round((double.Parse(dt.Rows[0]["TienNo"].ToString()) - double.Parse(dt.Rows[m - 1]["TienNo"].ToString())),1);
                }
                else
                {
                    report.NoDau = report.PhatSinh = 0;
                    report.NoCuoi = listCustomer[i].TienNo;
                }
                result.Add(report);
                DataProvider.closeConnection(con);
            }
            return result;
        }
    }
}
