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
    public partial class frmRestPass : Form
    {
        Users users;
        UserBLL userBLL;
        public frmRestPass()
        {
            users = new Users();
            userBLL = new UserBLL();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                users = userBLL.GetUsersMail(txtMail.Text);
                users = userBLL.GetUsersPhone(txtPhone.Text);
                userBLL.CheckBox(txtMail.Text, txtPhone.Text);
                if (users != null)
                {
                    if (users.Mail == txtMail.Text && users.Phone == txtPhone.Text)
                    {
                        if (txtpass1.Text == txtPass.Text)
                        {
                            users.Password = txtPass.Text;
                            userBLL.Update(users);
                            MessageBox.Show("Şifre Güncellenmiştir");
                        }
                      
                    }

                }
                else
                {
                    MessageBox.Show("Giriş Bilgilerinizi Kontrol Ediniz");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
    }
}
