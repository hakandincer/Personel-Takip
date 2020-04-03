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
    public partial class frmEmployeSearch : Form
    {
        EmployeeBLL _employeeBLL;
      
        
        public frmEmployeSearch()
        {
            
            _employeeBLL = new EmployeeBLL();
            InitializeComponent();
        }

        private void frmEmployeSearch_Load(object sender, EventArgs e)
        {
            
            dgvEmployee.DataSource = _employeeBLL.GetEmployeeList();
            VisibleIDs();
            Info();
            
        }
      
        private void txtDepertman_TextChanged(object sender, EventArgs e)
        {
           
            string lastname = txtLastName.Text;
            string departman = txtDepertman.Text;
            dgvEmployee.DataSource = _employeeBLL.GetEmployeeSearch(lastname, departman);
            VisibleIDs();
            Info();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            string lastname = txtLastName.Text;
            string departman = txtDepertman.Text;
            dgvEmployee.DataSource = _employeeBLL.GetEmployeeSearch(lastname,departman);
            VisibleIDs();
            Info();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtLastName.Text = "";
            txtDepertman.Text = "";
        }
        void ListEmployeeName()
        {
            string lastname = txtLastName.Text;
            dgvEmployee.DataSource = _employeeBLL.GetEmployeeSearch(lastname);
            VisibleIDs();

        }
        void VisibleIDs()
        {
            dgvEmployee.Columns["EmployeeID"].Visible = false;
            dgvEmployee.Columns["DepartmanID"].Visible = false;

        }
        void Info()
        {
            label3.Text = (dgvEmployee.Rows.Count).ToString();
            decimal SumSalary = 0;
            for (int i = 0; i < dgvEmployee.Rows.Count; i++)
            {
                SumSalary += decimal.Parse(dgvEmployee.Rows[i].Cells["Salary"].Value.ToString());
            }
            label6.Text ="Toplam Maas"+SumSalary.ToString("0,00")+"TL dir";
        }
        private void frmEmployeSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEmployee employee = new frmEmployee();
            employee.Show();
            this.Hide();
        }

    }
}
