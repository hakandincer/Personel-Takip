using Personel.Entities;
using PersonelBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class frmEmployee : Form
    {
        int flag = 0;
        EmployeeBLL employeeBLL;
    
       
        public frmEmployee()
        {
            employeeBLL = new EmployeeBLL();
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeAdd employeeAdd = new frmEmployeeAdd(flag);
            employeeAdd.Show();
            this.Hide();
        }

    
        void ListEmployee()
        {
            dgvEmployee.DataSource = employeeBLL.GetEmployeeList();
            dgvEmployee.Columns["EmployeeID"].Visible = false;
            dgvEmployee.Columns["DepartmanID"].Visible = false;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Employees employees = new Employees();
                DataGridViewRow selected = dgvEmployee.SelectedRows[0];
                employees.EmployeeID = (int)selected.Cells["EmployeeID"].Value;
                

                DialogResult result = MessageBox.Show("Departmanı Silmek İstediğinize Emin Misiniz!!!", "Çıkış Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    employeeBLL.Delete(employees);
                    ListEmployee();
                
                }
                else
                {
                    this.Show();
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            flag = 1;
            frmEmployeeAdd employeeAdd = new frmEmployeeAdd(flag);
            employeeAdd.Show();
            this.Hide();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmEmployeSearch search = new frmEmployeSearch();
            search.Show();
            this.Hide();
        }

    

        private void frmEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAdmin admin = new frmAdmin();
            admin.Show();
            this.Hide();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
           
            ListEmployee();
        }

    }
}
