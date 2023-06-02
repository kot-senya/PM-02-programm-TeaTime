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
using TeaTime;

namespace teaTime
{
    /// <summary>
    /// Логика взаимодействия для wWorkerChangeProfile.xaml
    /// </summary>
    public partial class wWorkerChangeProfile : Page
    {
        Worker worker = new Worker();
        public wWorkerChangeProfile(Worker user)
        {
            InitializeComponent();
            worker = user;
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
        }
        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            //rjl
            NavigationService.Navigate(new wWorkerUserPrifile(worker));
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerUserPrifile(worker));
        }
    }
}
