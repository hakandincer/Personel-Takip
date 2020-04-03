using Personel.DAL;
using Personel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBLL
{
    public class DepartmanBLL
    {
        DepartmanDAL departmanDAL;

        public DepartmanBLL()
        {
            departmanDAL = new DepartmanDAL();
        }
        public bool AddDepartman(Departmans departmans)
        {
            try
            {
                CheckRequiredFields(departmans.Departman, departmans.Aciklama);
                CheckLength(departmans.Departman, departmans.Aciklama);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return departmanDAL.Insert(departmans) > 0;
        }

  

        public bool Update(Departmans departmans)
        {
            try
            {
                CheckRequiredFields(departmans.Departman, departmans.Aciklama);
                CheckLength(departmans.Departman, departmans.Aciklama);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return departmanDAL.Update(departmans) > 0;

        }

        public bool Delete(Departmans departmans)
        {
            return departmanDAL.Delete(departmans) > 0;
        }
        public List<Departmans> GetDepartmans()
        {
            return departmanDAL.GetDepartmans();
        }
        public List<Departmans> GetDepartmansName()
        {
            return departmanDAL.GetDepartmansName();
        }

        private void CheckLength(string departman, string aciklama)
        {
            if (departman.Length > 30)
            {
                throw new Exception("Departman alanı 30 karakterden fazla olamaz");
            }
            if (aciklama.Length > 500)
            {
                throw new Exception("Acıklama alanı 500 karakterden fazla olamaz");
            }
        }

        private void CheckRequiredFields(string departman, string aciklama)
        {
            if (string.IsNullOrWhiteSpace(departman))
            {
                throw new Exception("Departman Boş geçilemez");

            }
            if (string.IsNullOrWhiteSpace(aciklama))
            {
                throw new Exception("Acıklama Boş geçilemez");
            }
        }

        public void CheckBox(string departman, string aciklama)
        {
            if (string.IsNullOrWhiteSpace(departman))
            {
                throw new Exception("Departman alanı boş geçilemez...");
            }
            if (string.IsNullOrWhiteSpace(aciklama))
            {
                throw new Exception("Aciklama alanı boş geçilemez...");
            }

        }


    }
}
