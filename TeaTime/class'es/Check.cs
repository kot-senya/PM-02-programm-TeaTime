using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using teaTime;

namespace TeaTime
{
    public class Checks
    {
        public static bool checkWorker(string login, string password, out Worker worker)
        {
            bool check = false;
            worker = new Worker();
            try
            {
                List<Worker> w = DataBaseConnect.DataBase.Worker.ToList();
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].login == login && w[i].password == password)
                    {
                        check = true;
                        worker = w[i];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return check;
        }
        public static bool checkMember(string login, string password, out Member member)
        {
            bool check = false;
            member = new Member();
            try
            {
                List<Member> m = DataBaseConnect.DataBase.Member.ToList();
                for (int i = 0; i < m.Count; i++)
                {
                    if (m[i].login == login && m[i].password == password)
                    {
                        check = true;
                        member = m[i];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }
        public static bool check(Regestration page)
        {
            Regex checkName = new Regex(@"^[А-я ,.'-]+$");
            Regex checkEmail = new Regex(@"^\S+@\S+\.\S+$");
            Regex checkNumberPhone = new Regex(@"^(8)\d{10}$");
            bool flag = true;

            if (checkName.IsMatch(page.aSurname.Text))
            {
                page.eSurname.Visibility = Visibility.Hidden;
            }
            else
            {
                page.eSurname.Visibility = Visibility.Visible;
                flag = false;
            }
            if (checkName.IsMatch(page.aName.Text))
            {
                page.eName.Visibility = Visibility.Hidden;
            }
            else
            {
                page.eName.Visibility = Visibility.Visible;
                flag = false;
            }
            if (checkName.IsMatch(page.aMiddleName.Text))
            {
                page.eMiddleName.Visibility = Visibility.Hidden;
            }
            else
            {
                page.eMiddleName.Visibility = Visibility.Visible;
                flag = false;
            }
            if (checkEmail.IsMatch(page.aEmail.Text))
            {
                page.eEmail.Visibility = Visibility.Hidden;
            }
            else
            {
                page.eEmail.Visibility = Visibility.Visible;
                flag = false;
            }
            if (checkNumberPhone.IsMatch(page.aPhoneNum.Text))
            {
                page.ePhoneNumber.Visibility = Visibility.Hidden;
            }
            else
            {
                page.ePhoneNumber.Visibility = Visibility.Visible;
                flag = false;
            }
            List<Member> m = DataBaseConnect.DataBase.Member.ToList().Where(tb => tb.login == page.aLogin.Text).ToList();
            List<Worker> w = DataBaseConnect.DataBase.Worker.ToList().Where(tb => tb.login == page.aLogin.Text).ToList();
            if (m.Count == 0 && w.Count == 0)
            {
                page.eLogin.Visibility = Visibility.Hidden;
            }
            else
            {
                page.eLogin.Visibility = Visibility.Visible;
                flag = false;
            }
            if (page.aPass.Password == page.arePass.Password && page.aPass.Password != "" && page.aPass.Password.Length > 1)
            {
                page.ePass.Visibility = Visibility.Hidden;
            }
            else
            {
                page.ePass.Visibility = Visibility.Visible;
                flag = false;
            }
            return flag;
        }
        public static bool check(workerAddWorker page)
        {
            Regex checkName = new Regex(@"^[А-я ,.'-]+$");
            Regex checkEmail = new Regex(@"^\S+@\S+\.\S+$");
            Regex checkNumberPhone = new Regex(@"^(8)\d{10}$");
            bool flag = true;

            if (!checkName.IsMatch(page.aSurname.Text))
            { 
                flag = false;
            }
            if (!checkName.IsMatch(page.aName.Text))
            {
                flag = false;
            }
            if (!checkName.IsMatch(page.aMiddleName.Text))
            {
                flag = false;
            }
            if (!checkEmail.IsMatch(page.aEmail.Text))
            {
                flag = false;
            }
            if (!checkNumberPhone.IsMatch(page.aPhoneNum.Text))
            {
                flag = false;
            }
            List<Member> m = DataBaseConnect.DataBase.Member.ToList().Where(tb => tb.login == page.aLogin.Text).ToList();
            List<Worker> w = DataBaseConnect.DataBase.Worker.ToList().Where(tb => tb.login == page.aLogin.Text).ToList();
            if (m.Count != 0 && w.Count != 0)
            {
                 flag = false;
            }
            if (page.aPass.Password == "" || page.aPass.Password.Length <= 1)
            {
               flag = false;
            }
            return flag;
        }
        public static bool check(wEventAdd page)
        {
            try
            {
                Regex checkTime = new Regex(@"^\d\d(:)\d{1,2}$");
                int tea = 0;
                foreach (TeaTimes a in page.nameTea.ItemsSource)//какой чай
                {
                    if (a.endTea != "")
                    {
                        tea++;
                    }
                }
                bool flag = true;
                if (!checkTime.IsMatch(page.aTime.Text) || page.aName.Text == "" || page.aTheme.Text == "" || page.aDescript.Text == "" || tea < 1)
                {
                    flag = false;
                }
                return flag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }

}
