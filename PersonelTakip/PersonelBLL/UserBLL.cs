using Personel.DAL;
using Personel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBLL
{
    public class UserBLL
    {
        UserDAL userDAL;
        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        public bool AddUser(Users users)
        {
            try
            {
                CheckRequiredFields(users.Name,users.Surname);
                CheckLength(users.Name,users.Surname);
                CheckMail(users.Mail);
            }
            catch (Exception ex)
            {
            

                throw ex;
            }
            return userDAL.Insert(users) > 0;
        }

        public bool Update(Users users, bool checkMaiFlag = true)
        {
            try
            {
                CheckRequiredFields(users.Name, users.Surname);
                CheckLength(users.Name, users.Surname);
                if (checkMaiFlag)
                {
                    CheckMail(users.Mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userDAL.Update(users) > 0;
        }

        public bool Delete(int userID)
        {
            return userDAL.Delete(userID) > 0;
        }

     
        public Users GetUsersMail(string mail)
        {
            return userDAL.GetUserByMail(mail);
        }
  
        public Users GetUserPass(string passworrd)
        {
            return userDAL.GetUserByPassword(passworrd);
        }
        public Users GetUsersPhone(string phone)
        {
            return userDAL.GetUserByPhone(phone);
        }

        public List<Users> GetuserList()
        {
            return userDAL.GetAllUsers();
        }


        void CheckRequiredFields(string name, string surname)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("İsim hatalı");
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new Exception("Soyisim hatalı");
            }
        }
        void CheckLength(string name, string surname)
        {
            if (name.Length > 20)
            {
                throw new Exception("İsim alanı 20 karakterden fazla olamaz");
            }
            if (surname.Length > 20)
            {
                throw new Exception("Soyisim alanı 30 karakterden fazla olamaz");
            }
        }

        void CheckMail(string mail, bool checkMailFlag = true)
        {
            if (string.IsNullOrWhiteSpace(mail))
            {
                throw new Exception("Mail boş geçilemez");
            }

            try
            {
                MailAddress address = new MailAddress(mail);
            }
            catch
            {
                throw new Exception("Mail düzgün formatta değil");
            }

            if (userDAL.GetUserByMail(mail) != null)
            {
                throw new Exception("Bu mail adresi sistemde kayıtlı");
            }
            if (mail.Length > 100)
            {
                throw new Exception("Bu Mail Adresi Çok Uzun");
            }
        }

        public void CheckBox(string mail, string pasworrd)
        {
            if (string.IsNullOrWhiteSpace(mail))
            {
                throw new Exception("Mail alanı boş geçilemez...");
            }
            if (string.IsNullOrWhiteSpace(pasworrd))
            {
                throw new Exception("Şifre alanı boş geçilemez...");
            }

        }
        public void CheckBoxed(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new Exception("Tüm Alanları Doldurunuz");
            }
        }

    }
}
