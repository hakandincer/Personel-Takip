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
    public partial class frmAdmin : Form
    {
        UserBLL userBLL;
        
        public frmAdmin()
        {
            userBLL = new UserBLL();
        
            InitializeComponent();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {             
        }
        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmUserLogin login = new frmUserLogin();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDepartman departmanSayfası = new frmDepartman();
            departmanSayfası.Show();
            this.Hide();
        }

   

        private void btnPerson_Click(object sender, EventArgs e)
        {
            frmEmployee employee = new frmEmployee();
            employee.Show();
            this.Hide();
        }
    }
}
