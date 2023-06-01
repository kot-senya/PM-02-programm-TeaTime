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
    /// Логика взаимодействия для wWorkerUserPrifile.xaml
    /// </summary>
    public partial class wWorkerUserPrifile : Page
    {
        Worker worker = new Worker();
        public wWorkerUserPrifile(Worker user)
        {
            InitializeComponent();
            worker = user;
            aFio.Text = worker.surname + " " + worker.name[0] + "." + worker.middleName[0] + ".";
        }

        private void btMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerMain(worker));
        }

        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerChangeProfile(worker));
        }

        private void loadData()
        {

        }
    }
}
