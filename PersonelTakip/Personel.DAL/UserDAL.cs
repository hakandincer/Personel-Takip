
using Personel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel.DAL
{
    public class UserDAL
    {
        DBHelper dBHelper;
        public UserDAL()
        {
            dBHelper = new DBHelper();
        }
       public int Insert(Users users)
       {
            dBHelper.CommandText = "INSERT INTO Users(Name,Surname,Mail,,Status,Password,Phone,Question,Date,Description,Answer) VALUES(@name,@surname,@mail,@status,@password,@phone,@question,,@date,@description,@answer)";
            dBHelper.Parameters.Clear();
            dBHelper.Parameters.Add("@name", users.Name);
            dBHelper.Parameters.Add("@surname",users.Surname);
            dBHelper.Parameters.Add("@mail", users.Mail);
            dBHelper.Parameters.Add("@status",users.Status);
            dBHelper.Parameters.Add("@phone", users.Phone);
            dBHelper.Parameters.Add("@password",users.Password);
            dBHelper.Parameters.Add("@question",users.Question);
            dBHelper.Parameters.Add("@date", users.Date);
            dBHelper.Parameters.Add("@description",users.Description);
            dBHelper.Parameters.Add("@answer",users.Answer);
            return dBHelper.ExecuteQuery();

        }

        public int Update(Users users)
        {
            dBHelper.CommandText = "UPDATE Admin SET Surname=@surname, Mail=@mail,Password=@password,Status=@status,Question=@question,Phone,@phone,Date=@date,Description=@description, Answer=@answer WHERE UserID=@userID";
            dBHelper.Parameters.Clear();
            dBHelper.Parameters.Add("@phone", users.Phone);
            dBHelper.Parameters.Add("@userID", users.UserID);
            dBHelper.Parameters.Add("@surname", users.Surname);
            dBHelper.Parameters.Add("@mail", users.Mail);
            dBHelper.Parameters.Add("@status", users.Status);
            dBHelper.Parameters.Add("@password", users.Password);
            dBHelper.Parameters.Add("@question", users.Question);
            dBHelper.Parameters.Add("@date", users.Date);
            dBHelper.Parameters.Add("@description", users.Description);
            dBHelper.Parameters.Add("@answer", users.Answer);
            return dBHelper.ExecuteQuery();
        }
        public int Delete(int userID)
        {
            dBHelper.CommandText = "DELETE FROM Admins WHERE UserID=@@userID";
            dBHelper.Parameters.Clear();
            dBHelper.Parameters.Add("@userID",userID);
            return dBHelper.ExecuteQuery();
        }
        public Users GetUserByMail(string mail)
        {
            dBHelper.CommandText = "SELECT * FROM Users WHERE Mail = @mail";
            dBHelper.Parameters.Clear();
            dBHelper.Parameters.Add("@mail", mail);
            Users users = null;
            SqlDataReader reader = dBHelper.SqlDataReader();
           
            if (reader.HasRows)
            {
                reader.Read();
                users = MapUser(reader);
            }
            reader.Close();
            return users;
        }
        public Users GetUserByPassword(string password)
        {
            dBHelper.CommandText = "SELECT * FROM Users WHERE Password = @password";
            dBHelper.Parameters.Clear();
            dBHelper.Parameters.Add("@password",password);
            Users users = null;
            SqlDataReader reader = dBHelper.SqlDataReader();
            //return reader.HasRows;
            if (reader.HasRows)
            {
                reader.Read();
                users = MapUser(reader);
            }
            reader.Close();
            return users;
        }
        public Users GetUserByPhone(string phone)
        {
            dBHelper.CommandText = "SELECT * FROM Users WHERE Phone = @phone";
            dBHelper.Parameters.Clear();
            dBHelper.Parameters.Add("@phone",phone);
            Users users = null;
            SqlDataReader reader = dBHelper.SqlDataReader();
            //return reader.HasRows;
            if (reader.HasRows)
            {
                reader.Read();
                users = MapUser(reader);
            }
            reader.Close();
            return users;
        }

        public List<Users> GetAllUsers() // butun adminleri getirir.
        {
            dBHelper.CommandText = "SELECT * FROM Users";
            dBHelper.Parameters.Clear();

            List<Users> users = new List<Users>();
            Users user = null;

            SqlDataReader reader = dBHelper.SqlDataReader();
            while (reader.Read())
            {
                user = MapUser(reader);
                users.Add(user);
            }
            reader.Close();
            return users;
        }

        private Users MapUser(SqlDataReader reader)
        {
            Users users = new Users();
            users.UserID = (int)reader["UserID"];
            users.Name = reader["Name"].ToString();
            users.Surname = reader["Surname"].ToString();
            users.Mail = reader["Mail"].ToString();
            users.Password = reader["Password"].ToString();
            users.Answer = reader["Answer"].ToString();
            users.Date = (DateTime)reader["Date"];
            users.Description = reader["Description"].ToString();
            users.Question = reader["Question"].ToString();
            users.Status = (bool)reader["Status"];
            return users;
        }
        private Users MapUsers(SqlDataReader reader)
        {
            Users users = new Users();
       
            users.Name= reader["Name"].ToString();
          
            return users;
        }
    }
}
