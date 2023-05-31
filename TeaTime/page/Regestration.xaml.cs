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
        public bool check()
        {
            try
            {
                Regex checkName = new Regex(@"^[А-я ,.'-]+$");
                Regex checkEmail = new Regex(@"^\\S+@\\S+\\.\\S+$");
                Regex checkNumberPhone = new Regex("^((\\+?7|8))\\d{10}$");

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
            NavigationService.Navigate(new Authorization());
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
