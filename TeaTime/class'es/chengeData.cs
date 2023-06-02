using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTime
{
    internal class chengeData
    {
        public static bool checkSurname(string Surname, string newSurname)
        {
            bool flag = false;
            if(Surname == newSurname)
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkName(string Name, string newName)
        {
            bool flag = false;
            if (Name == newName)
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkMiddleName(string MiddleName, string newMiddleName)
        {
            bool flag = false;
            if (MiddleName == newMiddleName)
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkEmail(string Email, string newEmail)
        {
            bool flag = false;
            if (Email == newEmail)
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkPhoneNumber(string PhoneNumber, string newPhoneNumber)
        {
            bool flag = false;
            if (PhoneNumber == newPhoneNumber)
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkLogin(string Login, string newLogin)
        {
            bool flag = false;
            if (Login == newLogin)
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkPassword(string Password, string newPassword, string newRePassword)
        {
            bool flag = false;
            if (Password == newPassword && newPassword == newRePassword)
            {
                flag = true;
            }
            return flag;
        }
    }
}
