using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel.Entities
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public int DepartmanID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }

        public Departmans Departmans { get; set; }

 
    }
}
