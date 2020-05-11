using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Website_BuyFood.Models
{
    public class DatabaseAccess
    {
        string strConn = "Data Source=DESKTOP-UE7MK69;Database=BanDoAnNhanh;Integrated Security=True";
        protected SqlConnection conn = null;
        public void OpenConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConn);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}