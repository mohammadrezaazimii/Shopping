using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Shopping.DAL
{
    public class DBManager
    {


        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-2780RIB\\SQLSERVER2019;Initial Catalog= shopping ;Integrated Security=true");
        SqlConnection con = new SqlConnection("Data Source=.\\MSSQLSERVER2019;Initial Catalog= mohama39_shopping ;User ID=mohama39_mmd;Password=@Reza79mo@;");

        public DataTable ExecuteDatatable(string query)
        {

            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            con.Close();
            return dt;
        } 
        public void ExecuteNoneQuery(string query)
        {
            con.Open();
            SqlCommand com = new SqlCommand(query ,con);
            com.ExecuteNonQuery();
            con.Close();
        } 
        public bool ExecuteScalar(string query)
        {
            DataTable dt = new DataTable();
            dt= ExecuteDatatable(query);  
            if (dt.Rows.Count == 1 && dt.Columns.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}