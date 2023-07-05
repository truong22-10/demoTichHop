using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoTichHop
{
    public class sqlserver_chung
    {
        public sqlserver_chung()
        {

        }

        public SqlConnection sqlsv_ketNoi()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=ADMIN-PC;Initial Catalog=HR;Integrated Security=True;";
            try
            {
                con.Open();
            }
            catch (SqlException)
            {
                return null;
            }
            return con;
        }
        public int sqlsv_xuLy(string query)
        {
            SqlCommand com = new SqlCommand(query, sqlsv_ketNoi());
            try
            {
                return com.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        public object sqlsv_docDuyNhat(string query)
        {
            SqlCommand com = new SqlCommand(query, sqlsv_ketNoi());
            try
            {
                return com.ExecuteScalar();
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public SqlDataReader sqlsv_docNhieuDuLieu(string query)
        {
            SqlCommand com = new SqlCommand(query, sqlsv_ketNoi());
            try
            {
                return com.ExecuteReader();
            }
            catch (SqlException)
            {
                return null;
            }
        }
        public object sqlsv_motDong(string query)
        {
            SqlCommand com = new SqlCommand(query, sqlsv_ketNoi());
            try
            {
                return com.ExecuteScalar();
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public SqlDataReader sqlsv_nhieuDong(string query)
        {
            SqlCommand com = new SqlCommand(query, sqlsv_ketNoi());
            try
            {
                return com.ExecuteReader();
            }
            catch (SqlException)
            {
                return null;
            }
        }
    }
}