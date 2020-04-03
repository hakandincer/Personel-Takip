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
    public partial class frmEmployeeAdd : Form
    {
        EmployeeBLL _employeeBLL;
        DepartmanBLL _departmanBLL;
        Employees employees;
        int flag1;
       
        public frmEmployeeAdd(int flag)
        {
            flag1 = flag;
            
            employees = new Employees();
            _employeeBLL = new EmployeeBLL();
            _departmanBLL = new DepartmanBLL();
            InitializeComponent();
        }
        private void frmEmployeeAdd_Load(object sender, EventArgs e)
        {
            
            ComboGetDepartment();
            ListEmployee();
            if (flag1 == 1)
            {
                btnAdd.Visible = false;
                btnClear1.Visible = false;
                
            }
            else
            {
                dgvEmployee1.Enabled = false;
                btnUpdate.Visible = false;
                btnClear2.Visible = false;
            }
        }

        void ComboGetDepartment()
        {
            cbDepartment.DisplayMember = "Departman";
            cbDepartment.ValueMember = "DepartmanID";
            cbDepartment.DataSource = _departmanBLL.GetDepartmans();
            //Dictionary<int, string> departments = new Dictionary<int, string>();
            //List<Departmans> lstdDepartments = _departmanBLL.GetDepartmans();
            //Dictionary<int, string> lstId = lstdDepartments.ToDictionary(m => m.DepartmanID, m => m.Departman);

        }
        
        void CheckBoxForm()
        {
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    _employeeBLL.CheckBoxed(item.Text);
                }
                if(item is ComboBox)
                {
                    _employeeBLL.CheckBoxed(item.Text);
                }
                if(item is NumericUpDown)
                {
                    _employeeBLL.CheckBoxed(item.Text);
                }
                if (item is MaskedTextBox)
                {
                    _employeeBLL.CheckBoxed(item.Text);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBoxForm();
                employees.FirstName = txtName.Text;
                employees.LastName = txtSurname.Text;
                employees.Phone = mtbPhone.Text;
                employees.Address= txtAddress.Text;
                employees.Email = txtMail.Text;
                employees.Salary = numUcret.Value;
                employees.StartDate = DateTime.Now;
                employees.Description = txtDescription.Text;
                employees.DepartmanID = Convert.ToInt32(cbDepartment.SelectedValue);
                _employeeBLL.AddEmployee(employees);
                MessageBox.Show("KAYIT BAŞARILI");
                ListEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBoxForm();
                employees.Address = txtDescription.Text;
                employees.DepartmanID = Convert.ToInt32(cbDepartment.SelectedValue);
                employees.Description = txtDescription.Text;
                employees.Email = txtMail.Text;
                employees.LastName = txtSurname.Text;
                employees.Phone = mtbPhone.Text;
                employees.Salary = numUcret.Value;
                employees.FirstName = txtName.Text;
                DataGridViewRow selected = dgvEmployee1.SelectedRows[0];
                employees.EmployeeID =(int)selected.Cells["EmployeeID"].Value;
                _employeeBLL.Update(employees);
                MessageBox.Show("Güncelleme Başarılı");
                ListEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ListEmployee()
        {
            dgvEmployee1.DataSource = _employeeBLL.GetEmployeeList();
            dgvEmployee1.Columns["EmployeeID"].Visible = false;
            dgvEmployee1.Columns["DepartmanID"].Visible = false;
        }

        private void dgvEmployee1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            employees = new Employees();
            DataGridViewRow selected = dgvEmployee1.SelectedRows[0];
            txtName.Text = selected.Cells["FirstName"].Value.ToString();
            txtAddress.Text = selected.Cells ["Address"].Value.ToString();
            txtDescription.Text = selected.Cells["Description"].Value.ToString();
            txtMail.Text = selected.Cells["Email"].Value.ToString();
            txtSurname.Text = selected.Cells["LastName"].Value.ToString();
            mtbPhone.Text = selected.Cells["Phone"].Value.ToString();
            txtName.Enabled = false;
            //numUcret.Value = (int)selected.Cells["Salary"].Value ;
            //cbDepartment.SelectedIndex = (int)selected.Cells["DepartmanID"].Value;
        }

        private void frmEmployeeAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEmployee employee = new frmEmployee();
            employee.Show();
            this.Hide();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void ClearBox()
        {
            txtAddress.Text = "";
            txtDescription.Text = "";
            txtMail.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            numUcret.Value = 0;
            mtbPhone.Text = null;
            cbDepartment.SelectedIndex = -1;

        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

   

        private void btnBack_Click(object sender, EventArgs e)
        {
            ListEmployee();
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string LastName = txtSearch.Text;
          
            dgvEmployee1.DataSource = _employeeBLL.GetEmployeeSearch(LastName);
        }
    }
}
