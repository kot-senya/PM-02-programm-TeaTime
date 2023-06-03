using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeaTime
{
    internal class chengeData
    {

        public static bool checkSurname(string Surname, string newSurname)
        {
            Regex checkNames = new Regex(@"^[А-я ,.'-]+$");
            bool flag = false;
            if (Surname != newSurname && checkNames.IsMatch(newSurname))
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkName(string Name, string newName)
        {
            Regex checkNames = new Regex(@"^[А-я ,.'-]+$");
            bool flag = false;
            if (Name != newName & checkNames.IsMatch(newName))
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkMiddleName(string MiddleName, string newMiddleName)
        {
            Regex checkNames = new Regex(@"^[А-я ,.'-]+$");
            bool flag = false;
            if (MiddleName != newMiddleName & checkNames.IsMatch(newMiddleName))
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkEmail(string Email, string newEmail)
        {
            Regex checkEmail = new Regex(@"^\S+@\S+\.\S+$");
            bool flag = false;
            if (Email != newEmail && checkEmail.IsMatch(newEmail))
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkPhoneNumber(string PhoneNumber, string newPhoneNumber)
        {

            Regex checkNumberPhone = new Regex(@"^(8)\d{10}$");
            bool flag = false;
            if (PhoneNumber != newPhoneNumber && checkNumberPhone.IsMatch(newPhoneNumber))
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkLogin(string Login, string newLogin)
        {
            List<Member> m = DataBaseConnect.DataBase.Member.ToList().Where(tb => tb.login == newLogin).ToList();
            List<Worker> w = DataBaseConnect.DataBase.Worker.ToList().Where(tb => tb.login == newLogin).ToList();
            bool flag = false;
            if (Login != newLogin && m.Count == 0 && w.Count == 0)
            {
                flag = true;
            }
            return flag;
        }
        public static bool checkPassword(string Password, string newPassword, string newRePassword)
        {
            bool flag = false;
            if (Password != newPassword && newPassword == newRePassword)
            {
                flag = true;
            }
            return flag;
        }
    }
}
