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
    public partial class frmUserRegistration : Form
    {
        Users users;
        UserBLL userBLL;
   
        public frmUserRegistration()
        {
            
            users = new Users();
            userBLL = new UserBLL();
            InitializeComponent();
        }

      
        void CheckBoxForm()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    userBLL.CheckBoxed(item.Text);
                }
                if (item is ComboBox)
                {
                    userBLL.CheckBoxed(item.Text);
                }
             
                if (item is MaskedTextBox)
                {
                    userBLL.CheckBoxed(item.Text);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBoxForm();
                users.Name = txtName.Text;
                users.Surname = txtSurname.Text;
                users.Answer = txtAnswer.Text;
                users.Date = DateTime.Now;
                users.Description = txtDescription.Text;
                users.Mail = txtMail.Text;
                users.Password = txtPassword.Text;
                users.Phone = txtPhone.Text;
                users.Question = cbQuestions.SelectedItem.ToString();
                users.Status = false;
                MessageBox.Show("KAYIT BAŞARILI");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void frmUserRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmUserLogin userLogin = new frmUserLogin();
            userLogin.Show();
            this.Hide();
        }

      
    }
}
