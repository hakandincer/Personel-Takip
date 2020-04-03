using Personel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel.DAL
{
    public class DepartmanDAL
    {
        DBHelper helper;
        public DepartmanDAL()
        {
            helper = new DBHelper();
        }
        public int Insert(Departmans departmans)
        {
            helper.CommandText = "Insert Into Departman (Departman,Aciklama) Values (@departman,@aciklama)";
            helper.Parameters.Clear();
            helper.Parameters.Add("@departman", departmans.Departman);
            helper.Parameters.Add("@aciklama", departmans.Aciklama);
            return helper.ExecuteQuery();
        }

        public int Update(Departmans departmans)
        {
            helper.CommandText = "Update Departman Set Departman=@departman,Aciklama=@aciklama where DepartmanID=@departmanID";
            helper.Parameters.Clear();
            helper.Parameters.Add("@departmanID", departmans.DepartmanID);
            helper.Parameters.Add("@departman", departmans.Departman);
            helper.Parameters.Add("@aciklama", departmans.Aciklama);
            return helper.ExecuteQuery();
        }

        public int Delete(Departmans departmans)
        {
            helper.CommandText = "Delete From Departman Where DepartmanID=@departmanID";
            helper.Parameters.Clear();
            helper.Parameters.Add("@departmanID", departmans.DepartmanID);
            return helper.ExecuteQuery();
        }

        public List<Departmans> GetDepartmans()
        {
            helper.CommandText = "Select * From Departman";
            helper.Parameters.Clear();
            List<Departmans> departmans = new List<Departmans>();
            Departmans departman = null;
            SqlDataReader reader = helper.SqlDataReader();
            while (reader.Read())
            {
                departman = MapDepartman(reader);
                departmans.Add(departman);
            }
            reader.Close();
            return departmans;
        }

        // Departman İsimlerini Getirir
        public List<Departmans> GetDepartmansName()
        {
            helper.CommandText = "Select Departman From Departman";
            helper.Parameters.Clear();
            List<Departmans> departmans = new List<Departmans>();
            Departmans departman = null;
            SqlDataReader reader = helper.SqlDataReader();
            while (reader.Read())
            {
                departman = MapDepartmanName(reader);
                departmans.Add(departman);
            }
            reader.Close();
            return departmans;
        }

        private Departmans MapDepartman(SqlDataReader reader)
        {
            Departmans departman = new Departmans();
            departman.DepartmanID = (int)reader["DepartmanID"];
            departman.Aciklama = reader["Aciklama"].ToString();
            departman.Departman = reader["Departman"].ToString();
            return departman;
        }
        private Departmans MapDepartmanName(SqlDataReader reader)
        {
            Departmans departman = new Departmans();
            //departman.DepartmanID = (int)reader["DepartmanID"];
            //departman.Aciklama = reader["Aciklama"].ToString();
            departman.Departman = reader["Departman"].ToString();
            return departman;
        }
    }
}
