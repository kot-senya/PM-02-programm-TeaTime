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
        Color Green = (Color)ColorConverter.ConvertFromString("#D3DB94");
        Color Red = (Color)ColorConverter.ConvertFromString("#F1736F");
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
                    eSurname.Fill = new SolidColorBrush(Green);
                }
                else
                {
                    eSurname.Fill = new SolidColorBrush(Red);
                    flag = false;
                }

                if (checkName.IsMatch(aName.Text))
                {
                    eName.Fill = new SolidColorBrush(Green);
                }
                else
                {
                    eName.Fill = new SolidColorBrush(Red);
                    flag = false;
                }
                if (checkName.IsMatch(aMiddleName.Text))
                {
                    eMiddleName.Fill = new SolidColorBrush(Green);
                }
                else
                {
                    eMiddleName.Fill = new SolidColorBrush(Red);
                    flag = false;
                }
                if (checkEmail.IsMatch(aEmail.Text))
                {
                    eEmail.Fill = new SolidColorBrush(Green);
                }
                else
                {
                    eEmail.Fill = new SolidColorBrush(Red);
                    flag = false;
                }
                if (checkNumberPhone.IsMatch(aPhoneNum.Text))
                {
                    ePhoneNumber.Fill = new SolidColorBrush(Green);
                }
                else
                {
                    ePhoneNumber.Fill = new SolidColorBrush(Red);
                    flag = false;
                }
                if (aPass.Password == arePass.Password && aPass.Password != "")
                {
                    ePass.Fill = new SolidColorBrush(Green);
                }
                else
                {
                    ePass.Fill = new SolidColorBrush(Red);
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
                NavigationService.Navigate(new Authorization());
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
