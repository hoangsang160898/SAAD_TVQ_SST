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
    public class BaoCaoTonSachDAO
    {
        private static SqlConnection con;
        public static List<BaoCaoTonSachDTO> loadReportBook(List<SachDTO> listBook,string startDate, string endDate)
        {
            int n = listBook.Count;
            string sCommand;
            List<BaoCaoTonSachDTO> result = new List<BaoCaoTonSachDTO>(); 
            for (int i =0;i<n;i++)
            {
                BaoCaoTonSachDTO report = new BaoCaoTonSachDTO();
                sCommand = string.Format(@"Select * from Log_Sach where MaSach = {0} and  ThoiGian >= '{1}' and ThoiGian <= '{2}' order by THOIGIAN ", listBook[i].MaSach, startDate, endDate);
                con = DataProvider.openConnection();
                DataTable dt = DataProvider.getDataTable(sCommand, con);
                report.Sach.MaSach = listBook[i].MaSach;
                report.Sach.TenSach = listBook[i].TenSach;
                report.NgayBaoCao = DateTime.Now.ToString();
                report.NgayBatDau = startDate;
                report.NgayKetThuc = endDate;
                int m = dt.Rows.Count;
                if (m > 0)
                {
                    report.TonDau = int.Parse(dt.Rows[0]["SoLuong"].ToString());
                    report.TonCuoi = listBook[i].SoLuong;
                    report.PhatSinh = int.Parse(dt.Rows[m - 1]["SoLuong"].ToString()) - report.TonDau;
                }
                else
                {
                     report.TonDau = report.PhatSinh = 0;
                    report.TonCuoi = listBook[i].SoLuong;

                }
                result.Add(report);
                DataProvider.closeConnection(con);
            }
            return result;
        }
    }
}
