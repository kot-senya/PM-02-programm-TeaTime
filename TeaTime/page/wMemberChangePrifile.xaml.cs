using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeaTime;

namespace teaTime
{
    public partial class wMemberChangePrifile : Page
    {
        Member member = new Member();
        Member newMember = new Member();
        string lastRename = "";
        public wMemberChangePrifile(Member user)
        {
            InitializeComponent();
            member = user;
            newMember = user;
            loadData();
        }
        private void loadData()
        {
            aSurname.Text = member.surname;
            aName.Text = member.name;
            aMiddleName.Text = member.middleName;
            aPhoneNum.Text = member.phone;
            aEmail.Text = member.email;
            aLogin.Text = member.login;
            aPass.Password = member.password;
            aPass.Visibility = Visibility.Hidden;
            arePass.Visibility = Visibility.Hidden;
            pLine.Visibility = Visibility.Hidden;
            pText.Visibility = Visibility.Hidden;
        }
        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            if (lastRename != "")
            {
                check(lastRename);
            }
            DataBaseConnect.DataBase.Member.AddOrUpdate(newMember);
            DataBaseConnect.DataBase.SaveChanges();
            DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
            NavigationService.Navigate(new wMemberUserPrifile(newMember));
        }
        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberUserPrifile(member));
        }
        private void b_Click(object sender, RoutedEventArgs e)
        {
            if (lastRename != "")
            {
                check(lastRename);
            }
            string name = "a" + (sender as Button).Name.Remove(0, 1);
            lastRename = name;
            if (name == "aPass")
            {
                aPass.Password = "";
                arePass.Password = "";
                aPass.Visibility = Visibility.Visible;
                arePass.Visibility = Visibility.Visible;
                aPassw.Visibility = Visibility.Hidden;
                pLine.Visibility = Visibility.Visible;
                pText.Visibility = Visibility.Visible;
            }
            else
            {
                changeBlock((TextBox)FindName(name));
            }
        }
        private void changeBlock(TextBox a)
        {
            a.IsReadOnly = false;
            a.Text = "";
        }
        private void check(string name)
        {
            switch (name)
            {
                case ("aLogin"):
                    {
                        if (aLogin.Text == "")
                        {
                            MessageBox.Show("Логин не был изменен");
                            aLogin.Text = member.login;
                        }

                        else if (chengeData.checkLogin(member.login, aLogin.Text))
                        {
                            newMember.login = aLogin.Text;
                            MessageBox.Show("Логин был изменен");
                        }
                        else
                        {
                            MessageBox.Show("Такой логин уже существует");
                            aLogin.Text = member.login;
                        }
                        aLogin.IsReadOnly = true;
                    }
                    break;
                case ("aPass"):
                    {
                        if (aPass.Password != arePass.Password)
                        {
                            MessageBox.Show("Пароли не совпадают. Повторите ввод!");
                        }
                        else if (aPass.Password == "")
                        {
                            MessageBox.Show("Пароль не был изменен");
                            aPass.Password = member.password;
                        }
                        else if (chengeData.checkPassword(member.password, aPass.Password, arePass.Password))
                        {
                            newMember.password = aPass.Password;
                            MessageBox.Show("Пароль был изменен");
                        }
                        aPass.Visibility = Visibility.Hidden;
                        arePass.Visibility = Visibility.Hidden;
                        aPassw.Visibility = Visibility.Visible;
                        pLine.Visibility = Visibility.Hidden;
                        pText.Visibility = Visibility.Hidden;
                    }
                    break;
                case ("aMiddleName"):
                    {
                        if (aMiddleName.Text == "")
                        {
                            MessageBox.Show("Отчество не было изменено");
                            aMiddleName.Text = member.middleName;
                        }
                        else if (chengeData.checkMiddleName(member.middleName, aMiddleName.Text))
                        {
                            newMember.middleName = aMiddleName.Text;
                            MessageBox.Show("Отчество было изменено");
                        }
                        else
                        {
                            MessageBox.Show("Отчество не было изменено. Введенны некоректные данные");
                            aMiddleName.Text = member.middleName;
                        }
                        aMiddleName.IsReadOnly = true;
                    }
                    break;
                case ("aName"):
                    {
                        if (aName.Text == "")
                        {
                            MessageBox.Show("Имя не было изменено");
                            aName.Text = member.name;
                        }
                        else if (chengeData.checkName(member.name, aName.Text))
                        {
                            newMember.name = aName.Text;
                            MessageBox.Show("Имя было изменено");
                        }
                        else
                        {
                            MessageBox.Show("Имя не было изменено. Введенны некоректные данные");
                            aName.Text = member.name;
                        }
                        aName.IsReadOnly = true;
                    }
                    break;
                case ("aSurname"):
                    {
                        if (aSurname.Text == "")
                        {
                            MessageBox.Show("Фамилия не была изменена");
                            aSurname.Text = member.surname;
                        }
                        else if (chengeData.checkSurname(member.surname, aSurname.Text))
                        {
                            newMember.surname = aSurname.Text;
                            MessageBox.Show("Фамилия была изменена");
                        }
                        else
                        {
                            MessageBox.Show("Фамилия не была изменена. Введенны некоректные данные");
                            aSurname.Text = member.surname;
                        }
                        aSurname.IsReadOnly = true;
                    }
                    break;
                case ("aPhoneNum"):
                    {
                        if (aPhoneNum.Text == "")
                        {
                            MessageBox.Show("Телефон не был изменен");
                            aPhoneNum.Text = member.phone;
                        }
                        else if (chengeData.checkPhoneNumber(member.phone, aPhoneNum.Text))
                        {
                            newMember.phone = aPhoneNum.Text;
                            MessageBox.Show("Телефон не был изменен");
                        }
                        else
                        {
                            MessageBox.Show("Телефон не был изменен. Введенны некоректные данные");
                            aPhoneNum.Text = member.phone;
                        }
                        aPhoneNum.IsReadOnly = true;
                    }
                    break;
                case ("aEmail"):
                    {
                        if (aEmail.Text == "")
                        {
                            MessageBox.Show("Почта не была изменена");
                            aEmail.Text = member.email;
                        }
                        else if (chengeData.checkEmail(member.email, aEmail.Text))
                        {
                            newMember.email = aEmail.Text;
                            MessageBox.Show("Почта не была изменена");
                        }
                        else
                        {
                            MessageBox.Show("Почта не была изменена. Введенны некоректные данные");
                            aEmail.Text = member.email;
                        }
                        aEmail.IsReadOnly = true;
                    }
                    break;

            }
        }
    }
}
