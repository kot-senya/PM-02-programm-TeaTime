using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            btUser.Header = worker.surname + " " + worker.name[0] + "." + worker.middleName[0] + ".";
            loadData();
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
            aFIO.Text = worker.surname + " " + worker.name + " " + worker.middleName;
            aPhoneNumber.Text = worker.phone;
            aEmail.Text = worker.email;
        }

        private void eventClose_Initialized(object sender, EventArgs e)
        {
            try
            {
                List<Event> ev = DataBaseConnect.DataBase.Event.ToList();
                List<Event> allEvent = ev.Where(tb => tb.date > DateTime.Now).OrderBy(tb => tb.date).ToList();
                ObservableCollection<DataTimeEvent> needEvent = new ObservableCollection<DataTimeEvent>();
                for (int i = 0; i < allEvent.Count; i++)
                {
                    DataTimeEvent a = new DataTimeEvent()
                    {
                        Data = Convert.ToString(allEvent[i].date).Split(' ')[0],
                        Name = allEvent[i].name,
                        Theme = allEvent[i].theme,
                        Description = allEvent[i].description
                    };
                    needEvent.Add(a);

                }
                eventClose.ItemsSource = needEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
