using Personel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel.DAL
{
    public class EmployeeDAL
    {
        DBHelper helper;
        public EmployeeDAL()
        {
            helper = new DBHelper();
        }
        public int Insert(Employees employees)
        {
            helper.CommandText = "Insert Into Employees (DepartmanID,FirstName,LastName,Phone,Address,Email,StartDate,Description,Salary) Values(@departmanID,@firstName,@lastName,@phone,@address,@email,@startDate,@description,@salary)";
            helper.Parameters.Clear();
            helper.Parameters.Add("@departmanID", employees.DepartmanID);
            helper.Parameters.Add("@firstName", employees.FirstName);
            helper.Parameters.Add("@lastName", employees.LastName);
            helper.Parameters.Add("@phone", employees.Phone);
            helper.Parameters.Add("@address", employees.Address);
            helper.Parameters.Add("@email", employees.Email);
            helper.Parameters.Add("@startDate", employees.StartDate);
            helper.Parameters.Add("@description", employees.Description);
            helper.Parameters.Add("@salary", employees.Salary);
            return helper.ExecuteQuery();
        }
        public int Update(Employees employees)
        {
            helper.CommandText = "Update Employees Set DepartmanID=@departmanID,FirstName=@firstName,LastName=@lastName,Phone=@phone,Address=@address,Email=@email,Description=@description,Salary=@salary Where EmployeeID=@employeeID";
            helper.Parameters.Clear();
            helper.Parameters.Add("@employeeID", employees.EmployeeID);
            helper.Parameters.Add("@departmanID", employees.DepartmanID);
            helper.Parameters.Add("@firstName", employees.FirstName);
            helper.Parameters.Add("@lastName", employees.LastName);
            helper.Parameters.Add("@phone", employees.Phone);
            helper.Parameters.Add("@address", employees.Address);
            helper.Parameters.Add("@email", employees.Email);
            //helper.Parameters.Add("@startDate", employees.StartDate);
            helper.Parameters.Add("@description", employees.Description);
            helper.Parameters.Add("@salary", employees.Salary);
            return helper.ExecuteQuery();
        }

        public int Delete(Employees employees)
        {
            helper.CommandText = "Delete From Employees Where EmployeeID=@employeeID";
            helper.Parameters.Clear();
            helper.Parameters.Add("@EmployeeID", employees.EmployeeID);
            return helper.ExecuteQuery();
        }

        public List<Employees> GetEmployees()
        {
            helper.CommandText = "Select * From Employees";
            helper.Parameters.Clear();
            List<Employees> employees = new List<Employees>();
            Employees employee = null;
            SqlDataReader reader = helper.SqlDataReader();
            while (reader.Read())
            {
                employee = MapEmployee(reader);
                employees.Add(employee);
            }
            reader.Close();
            return employees;
        }
        public List<Employees> GetEmployeesDepartmentName()
        {
            helper.CommandText = "select d.Departman,* from Employees e join Departman d on e.DepartmanID = d.DepartmanID";
            helper.Parameters.Clear();
            List<Employees> employees = new List<Employees>();
            Employees employee = null;
            SqlDataReader reader = helper.SqlDataReader();
            while (reader.Read())
            {
                employee = MapEmployee(reader);
                employees.Add(employee);
            }
            reader.Close();
            return employees;
        }
        public List<Employees> GetEmployeesNameSearch(string lastname)
        {
            helper.CommandText = "select d.Departman,* from Employees e join Departman d on e.DepartmanID = d.DepartmanID where e.LastName Like '%"+@lastname+ "%'";
            helper.Parameters.Clear();
            helper.Parameters.Add("@lastname",lastname);
         
            List<Employees> employees = new List<Employees>();
            Employees employee = null;
            SqlDataReader reader = helper.SqlDataReader();
            while (reader.Read())
            {
                employee = MapEmployee(reader);
                employees.Add(employee);
            }
            reader.Close();
            return employees;
        }
        public List<Employees> GetEmployeesLiveSearch(string lastname, string departman)
        {
            helper.CommandText = "select d.Departman,* from Employees e join Departman d on e.DepartmanID = d.DepartmanID where e.LastName Like '%" + @lastname + "%' and d.Departman Like '%" + @departman + "%'";
            helper.Parameters.Clear();
            helper.Parameters.Add("@lastname", lastname);
            helper.Parameters.Add("@departman", departman);
            List<Employees> employees = new List<Employees>();
            Employees employee = null;
            SqlDataReader reader = helper.SqlDataReader();
            while (reader.Read())
            {
                employee = MapEmployee(reader);
                employees.Add(employee);
            }
            reader.Close();
            return employees;
        }

        public int GetAllEmployeeCount()
        {
            
            helper.CommandText = "select COUNT(*) from Employees";
            helper.Parameters.Clear();  
            int employees = helper.Scalar();
            return employees;
        }
        public decimal GetAllEmployeeSumSalary()
        {
            helper.CommandText = "select SUM(Salary) from Employees";
            helper.Parameters.Clear();
            decimal employee = helper.ScalarSalary();
            return employee;
        }
        private Employees MapEmployee(SqlDataReader reader)
        {
            Employees employees = new Employees();
            employees.EmployeeID = (int)reader["EmployeeID"];
            employees.DepartmanID = (int)reader["DepartmanID"];
          
            employees.FirstName = reader["FirstName"].ToString();
            employees.LastName = reader["LastName"].ToString();
            employees.Phone = reader["Phone"].ToString();
            employees.Address = reader["Address"].ToString();
            employees.Email = reader["Email"].ToString();
            employees.StartDate = (DateTime)reader["StartDate"];
            employees.Description = reader["Description"].ToString();
            employees.Salary = (decimal)reader["Salary"];
            //booklist.book = new Book() { BookID = booklist.BookID, BookName = reader["BookName"].ToString() };
            employees.Departmans = new Departmans() { DepartmanID = employees.DepartmanID, Departman = reader["Departman"].ToString()};
            return employees;
        }
   
    }
}
