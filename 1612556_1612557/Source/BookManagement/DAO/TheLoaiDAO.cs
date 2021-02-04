using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
   public class TheLoaiDAO
    {
        private static SqlConnection con;
        public static List<TheLoaiDTO> loadAll()
        {
            string sCommand = "Select MaLoai, TenLoai from TheLoai";
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            List<TheLoaiDTO> result = new List<TheLoaiDTO>();
            for (int i = 0; i < n; i++)
            {
                int maLoai = int.Parse(dt.Rows[i]["MaLoai"].ToString());
                string tenLoai = dt.Rows[i]["tenLoai"].ToString();
                TheLoaiDTO theLoai = new TheLoaiDTO(maLoai, tenLoai);
                result.Add(theLoai);
            }
            DataProvider.closeConnection(con);
            return result;
        }
    }
}
