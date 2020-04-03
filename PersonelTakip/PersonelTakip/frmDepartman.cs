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

    public partial class frmDepartman : Form
    {
        DepartmanBLL departmanBLL;
     
        public frmDepartman()
        {
            departmanBLL = new DepartmanBLL();
            
            InitializeComponent();
        }

        //Departman EKLEME
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Departmans departmans = new Departmans();
            try
            {
                string departmanName = txtDepartman.Text.ToUpper();
                departmans.Departman = departmanName;
                departmans.Aciklama = txtAciklama.Text;
                foreach (var item in departmanBLL.GetDepartmans())
                {
                    if (item.Departman == departmanName)
                    {
                        MessageBox.Show("Departman İsmi Zaten Var");
                        ClearBox();
                        return;
                    }
                }
                departmanBLL.AddDepartman(departmans);
                MessageBox.Show("Departman Başarıyla Eklenmiştir");
                ClearBox();
                ListDepartman();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClearBox();
            }
        }

        void ListDepartman()
        {
            dgvDepartman.DataSource = departmanBLL.GetDepartmans();
            dgvDepartman.Columns["DepartmanID"].Visible = false;
        }
    
        private void frmDepartmanSayfası_Load(object sender, EventArgs e)
        {
            this.Text = "Departman";
            ListDepartman();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Departmans departmans = new Departmans();
                DataGridViewRow selected = dgvDepartman.SelectedRows[0];
                if (string.IsNullOrWhiteSpace(txtAciklama.Text) && string.IsNullOrWhiteSpace(txtDepartman.Text))
                {
                    MessageBox.Show("Lütfen Departman seçiniz");
                }
                else
                {
                    departmans.DepartmanID = (int)selected.Cells["DepartmanID"].Value;

                    DialogResult result = MessageBox.Show("Departmanı Silmek İstediğinize Emin Misiniz!!!", "Çıkış Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        departmanBLL.Delete(departmans);
                        ListDepartman();
                        ClearBox();
                    }
                    else
                    {
                        this.Show();
                        ClearBox();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClearBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)//Merte Sor Seçili iken başka cell seçiliyken hata veriyor 
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtAciklama.Text) && string.IsNullOrWhiteSpace(txtDepartman.Text))
                {
                    MessageBox.Show("Lütfen Departman seçiniz");
                }
                else
                {
                    Departmans departmans = new Departmans();
                    departmanBLL.CheckBox(txtDepartman.Text, txtAciklama.Text);
                    DataGridViewRow selected = dgvDepartman.SelectedRows[0];
                    departmans.Departman = txtDepartman.Text;
                    departmans.Aciklama = txtAciklama.Text;
                    //foreach (var item in departmanBLL.GetDepartmans())
                    //{
                    //    if (item.Departman == txtDepartman.Text)
                    //    {
                    //        MessageBox.Show("Departman İsmi Zaten Var");
                    //        ClearBox();
                    //        return;
                    //    }
                    //}
                    departmans.DepartmanID = (int)selected.Cells["DepartmanID"].Value;
                    departmanBLL.Update(departmans);
                    MessageBox.Show("Güncelleme başarılı");
                    ClearBox();
                    ListDepartman();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClearBox();

            }
        }
        private void dgvDepartman_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selected = dgvDepartman.SelectedRows[0];

            string departman = selected.Cells["Departman"].Value.ToString();
            string aciklama = selected.Cells["Aciklama"].Value.ToString();
            int departmanID = (int)selected.Cells["DepartmanID"].Value;
            txtDepartman.Text = departman;
            txtAciklama.Text = aciklama;
            txtDepartman.Enabled = false;
          

        }

        void ClearBox()
        {
            txtDepartman.Clear();
            txtAciklama.Clear();
        }

 

        private void frmDepartmanSayfası_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAdmin frmAdmin = new frmAdmin();
            frmAdmin.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClearBox();
        }
    }
}
