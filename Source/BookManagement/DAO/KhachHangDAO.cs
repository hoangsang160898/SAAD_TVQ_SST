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
    public class KhachHangDAO
    {
        private static SqlConnection con;
        public static List<KhachHangDTO> loadAll()
        {
            string sCommand = "Select* from KhachHang";
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            List<KhachHangDTO> result =  new List<KhachHangDTO>();
            for (int i=0;i<n;i++)
            {
                int maKh = int.Parse(dt.Rows[i]["MaKH"].ToString());
                string hoTen = dt.Rows[i]["HoTen"].ToString();
                string diaChi = dt.Rows[i]["DiaChi"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                string sdt = dt.Rows[i]["sdt"].ToString();
                double tienNo = double.Parse(dt.Rows[i]["tienNo"].ToString());
                KhachHangDTO khachHang = new KhachHangDTO(maKh,hoTen,diaChi,email,sdt,tienNo);
                result.Add(khachHang);
            }
            DataProvider.closeConnection(con);
            return result;
        }

        public static bool changeDebt(int idCustomer, double debt)
        {
            string sCommand = string.Format(@"Update KhachHang set tienNo = {0} where MaKH = {1}", debt, idCustomer);
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

        public static List<KhachHangDTO> searchCustomer(string textToSearch)
        {
            string sCommand = string.Format(@"Select* from KhachHang where hoten like '%{0}%'or email like '%{0}%' or diachi like '%{0}%' or sdt like '%{0}%'", textToSearch);
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            List<KhachHangDTO> result = new List<KhachHangDTO>();
            for (int i = 0; i < n; i++)
            {
                int maKh = int.Parse(dt.Rows[i]["MaKH"].ToString());
                string hoTen = dt.Rows[i]["HoTen"].ToString();
                string diaChi = dt.Rows[i]["DiaChi"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                string sdt = dt.Rows[i]["sdt"].ToString();
                double tienNo = double.Parse(dt.Rows[i]["tienNo"].ToString());
                KhachHangDTO khachHang = new KhachHangDTO(maKh, hoTen, diaChi, email, sdt, tienNo);
                result.Add(khachHang);
            }
            DataProvider.closeConnection(con);
            return result;
        }

        public static KhachHangDTO searchByPhone(string phone)
        {
            string sCommand = string.Format(@"select* from KhachHang where sdt = '{0}'", phone);
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            int maKh = int.Parse(dt.Rows[0]["MaKH"].ToString());
            string hoTen = dt.Rows[0]["HoTen"].ToString();
            string diaChi = dt.Rows[0]["DiaChi"].ToString();
            string email = dt.Rows[0]["email"].ToString();
            string sdt = dt.Rows[0]["sdt"].ToString();
            double tienNo = double.Parse(dt.Rows[0]["tienNo"].ToString());
            DataProvider.closeConnection(con);
            return new KhachHangDTO(maKh, hoTen, diaChi, email, sdt, tienNo);
        }

        public static KhachHangDTO searchById(string id)
        {
            string sCommand = string.Format(@"select* from KhachHang where MaKH = {0}", id);
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            int maKh = int.Parse(dt.Rows[0]["MaKH"].ToString());
            string hoTen = dt.Rows[0]["HoTen"].ToString();
            string diaChi = dt.Rows[0]["DiaChi"].ToString();
            string email = dt.Rows[0]["email"].ToString();
            string sdt = dt.Rows[0]["sdt"].ToString();
            double tienNo = double.Parse(dt.Rows[0]["tienNo"].ToString());
            DataProvider.closeConnection(con);
            return new KhachHangDTO(maKh, hoTen, diaChi, email, sdt, tienNo);
        }

       
    }
}
