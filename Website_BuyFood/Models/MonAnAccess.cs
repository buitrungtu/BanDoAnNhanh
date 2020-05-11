using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace Website_BuyFood.Models
{
    public class MonAnAccess:DatabaseAccess
    {
        public List<MonAn> DanhSachMonAn()
        {
            List<MonAn> kq = new List<MonAn>();
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from MonAn";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MonAn temp = new MonAn();
                temp.MaMon = reader.GetInt32(0);
                temp.TenMon = reader.GetString(1);
                temp.DonGia = reader.GetInt32(2);
                temp.LinkAnh = reader.GetString(3);
                
                kq.Add(temp);
            }
            reader.Close();
            return kq;
        }
    }
}