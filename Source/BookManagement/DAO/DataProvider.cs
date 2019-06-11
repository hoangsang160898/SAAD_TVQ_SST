using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        public static SqlConnection openConnection()
        {
            // Chú ý Data Source
            string sConection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BookManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(sConection);
            con.Open();
            return con;
        }

        public static void closeConnection(SqlConnection con)
        {
            con.Close();
        }

        public static DataTable getDataTable(string sCommand, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sCommand, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool executeNonQuery(string sCommand, SqlConnection con)
        {
            try
            {
                SqlCommand com = new SqlCommand(sCommand, con);
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
