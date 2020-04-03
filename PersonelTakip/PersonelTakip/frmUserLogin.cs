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
    public partial class frmUserLogin : Form
    {
        Users users;
        UserBLL userBLL;
        public frmUserLogin()
        {
            users = new Users();
            userBLL = new UserBLL();
            InitializeComponent();
        }

     

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                users = userBLL.GetUsersMail(txtMail.Text);
                users = userBLL.GetUserPass(txtpass.Text);
                userBLL.CheckBox(txtMail.Text, txtpass.Text);
                if (users != null)
                {
                    if (users.Mail == txtMail.Text && users.Password == txtpass.Text)
                    {
                        int UserID = users.UserID;
                        frmAdmin FormAdmin = new frmAdmin();
                        FormAdmin.Owner = this;
                        FormAdmin.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Giriş Bilgilerinizi Kontrol Ediniz");
                    ClearTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClearTextBox();
            }
        }
        void ClearTextBox()
        {
            txtMail.Clear();
            txtpass.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmUserRegistration registration = new frmUserRegistration();
            registration.ShowDialog();
        }

        private void frmUserLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkmak istediğinize Emin Misiniz", "Çıkış Onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;

                return;
            }

            Environment.Exit(0);
        }

        private void lnkPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRestPass restPass = new frmRestPass();
            restPass.Show();
            this.Hide();
       

        }
    }
}
