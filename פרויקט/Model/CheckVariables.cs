using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace פרויקט.Model
{
    internal class CheckVariables
    {
        public User User;

        public CheckVariables() { }
        public bool AreFieldsNotEmpty()
        {
            return !string.IsNullOrWhiteSpace(User.UserName) &&
                   !string.IsNullOrWhiteSpace(User.FirstName) &&
                   !string.IsNullOrWhiteSpace(User.LastName) &&
                   !string.IsNullOrWhiteSpace(User.Email) &&
                   !string.IsNullOrWhiteSpace(User.Password);
        }
        public bool IsPasswordValid(string password)
        {
            // בדיקת אורך סיסמה
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }

            // בדיקת ייחודיות אותות גדולות וספרות
            bool hasUpperCase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            return hasUpperCase && hasDigit;
        }
       
        public  bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
