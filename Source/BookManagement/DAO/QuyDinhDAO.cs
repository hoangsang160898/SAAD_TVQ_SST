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
    public class QuyDinhDAO
    {
        private static SqlConnection con;
        public static QuyDinhDTO loadQuyDinh()
        {
            string sCommand = "select* from QuyDinh";
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            double noToiDa = double.Parse(dt.Rows[0]["NoToiDa"].ToString());
            int luongTonSauKhiBan = int.Parse(dt.Rows[0]["LuongTonSauKhiBan"].ToString());
            int luongNhapToiThieu = int.Parse(dt.Rows[0]["LuongNhapToiThieu"].ToString());
            int luongTonToiThieuKhiNhap = int.Parse(dt.Rows[0]["LuongTonToiThieuKhiNhap"].ToString());
            DataProvider.closeConnection(con);
            return new QuyDinhDTO(noToiDa, luongTonSauKhiBan, luongNhapToiThieu, luongTonToiThieuKhiNhap);
        }

        public static bool thayDoiQuyDinh(QuyDinhDTO quyDinhMoi)
        {
            string sCommand = string.Format("Update QuyDinh set NoToiDa = {0}, LuongTonSauKhiBan = {1}, LuongNhapToiThieu = {2}, LuongTonToiThieuKhiNhap = {3}", quyDinhMoi.NoToiDa, quyDinhMoi.LuongTonSauKhiBan, quyDinhMoi.LuongNhapToiThieu, quyDinhMoi.LuongTonToiThieuKhiNhap);
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
        public static bool thayDoiKiemTraQuyDinh(KiemTraQuyDinh kt)
        {
            string sCommand = string.Format("Update SetQuyDinh set NoToiDa = {0}, LuongTonSauKhiBan = {1}, LuongNhapToiThieu = {2}, LuongTonToiThieuKhiNhap = {3}", kt.NoToiDa, kt.LuongTonSauKhiBan, kt.LuongNhapToiThieu, kt.LuongTonToiThieuKhiNhap);
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
        public static KiemTraQuyDinh loadKiemTraQuyDinh()
        {
            string sCommand = "select* from SetQuyDinh";
            con = DataProvider.openConnection();
            DataTable dt = DataProvider.getDataTable(sCommand, con);
            int n = dt.Rows.Count;
            if (n <= 0)
            {
                DataProvider.closeConnection(con);
                return null;
            }
            KiemTraQuyDinh result = new KiemTraQuyDinh();
             result.NoToiDa = int.Parse(dt.Rows[0]["NoToiDa"].ToString());
            result.LuongTonSauKhiBan = int.Parse(dt.Rows[0]["LuongTonSauKhiBan"].ToString());
            result.LuongNhapToiThieu = int.Parse(dt.Rows[0]["LuongNhapToiThieu"].ToString());
            result.LuongTonToiThieuKhiNhap= int.Parse(dt.Rows[0]["LuongTonToiThieuKhiNhap"].ToString());
            DataProvider.closeConnection(con);
            return result;
        }
    }
}
