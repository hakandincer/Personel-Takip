using Personel.DAL;
using Personel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBLL
{
    public class EmployeeBLL
    {
        EmployeeDAL employeeDAL;
        public EmployeeBLL()
        {
            employeeDAL = new EmployeeDAL();
        }
        public bool AddEmployee(Employees employees)
        {
            try
            {
                CheckRequiredFields(employees.FirstName, employees.LastName);
                CheckLength(employees.FirstName,employees.LastName);
                CheckMail(employees.Email);
                CheckSalary(employees.Salary);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return employeeDAL.Insert(employees) > 0;

        }
        public bool Delete(Employees employees)
        {
            return employeeDAL.Delete(employees) > 0;
        }
        public bool Update(Employees employees)
        {
            try
            {
                CheckRequiredFields(employees.FirstName, employees.LastName);
                CheckLength(employees.FirstName, employees.LastName);
                CheckMail(employees.Email);
                CheckSalary(employees.Salary);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return employeeDAL.Update(employees) > 0;
        }

        private void CheckSalary(decimal salary)
        {
            if (salary == 0)
            {
                throw new Exception("Maaş 0 Olamaz...");

            }
        }

        public List<Employees> GetEmployeeList()
        {
            return employeeDAL.GetEmployeesDepartmentName();
        }
        public List<Employees> GetEmployeeSearch(string lastname,string departman)
        {
            return employeeDAL.GetEmployeesLiveSearch(lastname,departman);
        }
        public List<Employees> GetEmployeeSearch(string lastname)
        {
            return employeeDAL.GetEmployeesNameSearch(lastname);
        }

        public int GetEmployeeCount()
        {
            return employeeDAL.GetAllEmployeeCount();
        }
        public decimal GetEmployeeSumSalary()
        {
            return employeeDAL.GetAllEmployeeSumSalary();
        }
        private void CheckMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Mail boş geçilemez");
            }
            try
            {
                MailAddress address = new MailAddress(email);
            }
            catch
            {
                throw new Exception("Mail düzgün formatta değil");
            } 
        }

        private void CheckLength(string firstName, string lastName)
        {
            if (firstName.Length > 20)
            {
                throw new Exception("İsim 20 karakterden fazla olamaz");
            }
            if (lastName.Length > 20)
            {
                throw new Exception("Soyad 20 karakterden fazla olamaz");
            }
        }

        private void CheckRequiredFields(string firstName,string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("İsim Boş geçilemez");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("İsim Boş geçilemez");
            }
        }
       public void CheckBoxed(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new Exception("Tüm Alanları Doldurunuz");
            }
        }
    }
}
