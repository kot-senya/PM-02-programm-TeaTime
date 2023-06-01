using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Regestration.xaml
    /// </summary>
    public partial class Regestration : Page
    {
        public Regestration()
        {
            InitializeComponent();
        }
        public bool check()
        {
            try
            {
                Regex checkName = new Regex(@"^[А-я ,.'-]+$");
                Regex checkEmail = new Regex(@"^\S+@\S+\.\S+$");
                Regex checkNumberPhone = new Regex("^((\\+?7|8))\\d{10}$");
                bool flag = true;

                if (checkName.IsMatch(aSurname.Text))
                {
                    eSurname.Visibility = Visibility.Hidden;
                }
                else
                {
                    eSurname.Visibility = Visibility.Visible;
                    flag = false;
                }

                if (checkName.IsMatch(aName.Text))
                {
                    eName.Visibility = Visibility.Hidden;
                }
                else
                {
                    eName.Visibility = Visibility.Visible;
                    flag = false;
                }
                if (checkName.IsMatch(aMiddleName.Text))
                {
                    eMiddleName.Visibility = Visibility.Hidden;
                }
                else
                {
                    eMiddleName.Visibility = Visibility.Visible;
                    flag = false;
                }
                if (checkEmail.IsMatch(aEmail.Text))
                {
                    eEmail.Visibility = Visibility.Hidden;
                }
                else
                {
                    eEmail.Visibility = Visibility.Visible;
                    flag = false;
                }
                if (checkNumberPhone.IsMatch(aPhoneNum.Text))
                {
                    ePhoneNumber.Visibility = Visibility.Hidden;
                }
                else
                {
                    ePhoneNumber.Visibility = Visibility.Visible;
                    flag = false;
                }
                if (aPass.Password == arePass.Password && aPass.Password != "")
                {
                    ePass.Visibility = Visibility.Hidden;
                }
                else
                {
                    ePass.Visibility = Visibility.Visible;
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
        private void bReg_Click(object sender, RoutedEventArgs e)
        {
            //код
            if (check())
            {
                try
                {
                    List<Member> List = DataBaseConnect.DataBase.Member.ToList();
                    var lastItem = List.Last();
                    Member newUser = new Member()
                    {
                        surname = aSurname.Text,
                        name = aName.Text,
                        middleName = aMiddleName.Text,
                        phone = aPhoneNum.Text,
                        email = aEmail.Text,
                        login = aLogin.Text,
                        password = aPass.Password
                    };
                    DataBaseConnect.DataBase.Member.Add(newUser);
                    DataBaseConnect.DataBase.SaveChanges();
                    DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
                    NavigationService.Navigate(new Authorization());
                }
                catch
                {
                    MessageBox.Show("При регистрации возникли технические неполадки попробуйте еще раз");
                }

            }
            else
            {
                MessageBox.Show("При регистрации возникли ошибки!\nПожалуйста перепроверьте введенные Вами данные или обратитесь к подсказкам справа.");
            }

        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
