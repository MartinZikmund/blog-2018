using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace MySqlUwp.Dal
{
    public static class Database
    {
        public static string TestDb()
        {
            string connStr = "server=localhost;user=root;database=uwpconnect;port=3306;password=";

            StringBuilder sb = new StringBuilder();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                sb.AppendLine("Connecting to MySQL...");
                conn.Open();
                sb.AppendLine("Connected!");
                string sql = "SELECT Name FROM world";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    sb.AppendLine(rdr[0].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                sb.AppendLine(ex.Message);
            }
            conn.Close();
            return sb.ToString();
        }
    }
}
