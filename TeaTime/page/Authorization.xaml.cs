using System;
using System.Collections.Generic;
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
using teaTime;

namespace teaTime
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void bAuth_Click(object sender, RoutedEventArgs e)
        {
            if(aLogin.Text.ToLower() == "работник")
            {
                NavigationService.Navigate(new wWorkerMain());
            }
            else if (aLogin.Text.ToLower() == "член клуба")
            {
                NavigationService.Navigate(new wMemberMain());
            }
            else
            {
                MessageBox.Show("Не найдено");
            }
            
        }

        private void bReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Regestration());
        }
    }
}
