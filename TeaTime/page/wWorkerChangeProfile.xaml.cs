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
    /// <summary>
    /// Логика взаимодействия для wWorkerChangeProfile.xaml
    /// </summary>
    public partial class wWorkerChangeProfile : Page
    {
        Worker worker = new Worker();
        Worker newWorker = new Worker();
        string lastRename = "";
        public wWorkerChangeProfile(Worker user)
        {
            InitializeComponent();
            worker = user;
            newWorker = user;
            loadData();
        }
        private void loadData()
        {
            aSurname.Text = worker.surname;
            aName.Text = worker.name;
            aMiddleName.Text = worker.middleName;
            aPhoneNum.Text = worker.phone;
            aEmail.Text = worker.email;
            aLogin.Text = worker.login;
            aPass.Password = worker.password;
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
            DataBaseConnect.DataBase.Worker.AddOrUpdate(newWorker);
            DataBaseConnect.DataBase.SaveChanges();
            DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
            NavigationService.Navigate(new wWorkerUserPrifile(newWorker));
        }
        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerUserPrifile(worker));
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
                            aLogin.Text = worker.login;
                        }

                        else if (chengeData.checkLogin(worker.login, aLogin.Text))
                        {
                            newWorker.login = aLogin.Text;
                            MessageBox.Show("Логин был изменен");
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
                            aPass.Password = worker.password;
                        }
                        else if (chengeData.checkPassword(worker.password, aPass.Password , arePass.Password))
                        {
                            newWorker.password = aPass.Password;
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
                            aMiddleName.Text = worker.middleName;
                        }
                        else if (chengeData.checkMiddleName(worker.middleName, aMiddleName.Text))
                        {
                            newWorker.middleName = aMiddleName.Text;
                            MessageBox.Show("Отчество было изменено");
                        }
                        else
                        {
                            MessageBox.Show("Отчество не было изменено. Введенны некоректные данные");
                            aMiddleName.Text = worker.middleName;
                        }
                        aMiddleName.IsReadOnly = true;
                    }
                    break;
                case ("aName"):
                    {
                        if (aName.Text == "")
                        {
                            MessageBox.Show("Имя не было изменено");
                            aName.Text = worker.name;
                        }
                        else if (chengeData.checkName(worker.name, aName.Text))
                        {
                            newWorker.name = aName.Text;
                            MessageBox.Show("Имя было изменено");
                        }
                        else
                        {
                            MessageBox.Show("Имя не было изменено. Введенны некоректные данные");
                            aName.Text = worker.name;
                        }
                        aName.IsReadOnly = true;
                    }
                    break;
                case ("aSurname"):
                    {
                        if (aSurname.Text == "")
                        {
                            MessageBox.Show("Фамилия не была изменена");
                            aSurname.Text = worker.surname;
                        }
                        else if (chengeData.checkSurname(worker.surname, aSurname.Text))
                        {
                            newWorker.surname = aSurname.Text;
                            MessageBox.Show("Фамилия была изменена");
                        }
                        else
                        {
                            MessageBox.Show("Фамилия не была изменена. Введенны некоректные данные");
                            aSurname.Text = worker.surname;
                        }
                        aSurname.IsReadOnly = true;
                    }
                    break;
                case ("aPhoneNum"):
                    {
                        if (aPhoneNum.Text == "")
                        {
                            MessageBox.Show("Телефон не был изменен");
                            aPhoneNum.Text = worker.phone;
                        }
                        else if (chengeData.checkPhoneNumber(worker.phone, aPhoneNum.Text))
                        {
                            newWorker.phone = aPhoneNum.Text;
                            MessageBox.Show("Телефон не был изменен");
                        }
                        else
                        {
                            MessageBox.Show("Телефон не был изменен. Введенны некоректные данные");
                            aPhoneNum.Text = worker.phone;
                        }
                        aPhoneNum.IsReadOnly = true;
                    }
                    break;
                case ("aEmail"):
                    {
                        if (aEmail.Text == "")
                        {
                            MessageBox.Show("Почта не была изменена");
                            aEmail.Text = worker.email;
                        }
                        else if (chengeData.checkEmail(worker.email, aEmail.Text))
                        {
                            newWorker.email = aEmail.Text;
                            MessageBox.Show("Почта не была изменена");
                        }
                        else
                        {
                            MessageBox.Show("Почта не была изменена. Введенны некоректные данные");
                            aEmail.Text = worker.email;
                        }
                        aEmail.IsReadOnly = true;
                    }
                    break;

            }
        }
    }
}
