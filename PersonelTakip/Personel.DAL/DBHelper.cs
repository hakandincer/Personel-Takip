using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel.DAL
{
    public class DBHelper
    {
        public string CommandText { get; set; }
        public Dictionary<string,object> Parameters { get; set; }
        SqlConnection conn;
        SqlCommand cmd;

        public DBHelper()
        {
            conn = new SqlConnection(Properties.Settings.Default.PRS);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            Parameters = new Dictionary<string, object>();
        }
        internal int ExecuteQuery()
        {
            cmd.CommandText = this.CommandText;
            cmd.Parameters.Clear();
            foreach (KeyValuePair<string,object> item in this.Parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            if (conn.State!=System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal SqlDataReader SqlDataReader()
        {
            cmd.CommandText = this.CommandText;
            cmd.Parameters.Clear();
            foreach (KeyValuePair<string,object> item in this.Parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return reader;
        }
        public int Scalar()
        {
            cmd.CommandText = this.CommandText;
            cmd.Parameters.Clear();
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count;
        }
        public decimal ScalarSalary()
        {
            cmd.CommandText = this.CommandText;
            cmd.Parameters.Clear();
            conn.Open();
            decimal count = (decimal)cmd.ExecuteScalar();
            conn.Close();
            return count;
        }
    }
}
