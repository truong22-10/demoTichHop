using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoTichHop
{
    public class mysql_chung
    {
        public mysql_chung()
        {

        }

        public MySqlConnection mysql_ketNoi()
        {
            String connString = "Server=127.0.0.1;Database=payroll;port=3306;User Id=root;password='22102000'";
            //String connString = "server = 127.0.0.1; user id = root; persistsecurityinfo = True; database = payroll";
            MySqlConnection con = new MySqlConnection(connString);       
            try
            {
                con.Open();
            }
            catch (MySqlException)
            {
                return null;
            }
            return con;
        }

        public int mysql_xuLy(string query)
        {
            MySqlCommand com = new MySqlCommand(query, mysql_ketNoi());
            try
            {
                return com.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                return 0;
            }
        }

        public object mysql_docDuyNhat(string query)
        {
            MySqlCommand com = new MySqlCommand(query, mysql_ketNoi());
            try
            {
                return com.ExecuteScalar();
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        public MySqlDataReader mysql_docNhieuDuLieu(string query)
        {
            MySqlCommand com = new MySqlCommand(query, mysql_ketNoi());
            try
            {
                return com.ExecuteReader();
            }
            catch (MySqlException)
            {
                return null;
            }
        }
        public object mysql_motDong(string query)
        {
            MySqlCommand com = new MySqlCommand(query, mysql_ketNoi());
            try
            {
                return com.ExecuteScalar();
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        public MySqlDataReader mysql_nhieuDong(string query)
        {
            MySqlCommand com = new MySqlCommand(query, mysql_ketNoi());
            try
            {
                return com.ExecuteReader();
            }
            catch (MySqlException)
            {
                return null;
            }
        }
    }

}