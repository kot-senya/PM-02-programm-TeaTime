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
    public class DataSee
    {
        public int num { get; set; }
        public string value { get; set; }
    }
    public partial class wEventSee : Page
    {
        Worker worker = new Worker();
        Event ev;
        public wEventSee(Worker user, Event e)
        {
            worker = user;
            InitializeComponent();
            ev = e;
            init(e);
            loadData();
            if (DateTime.Parse(aDate.Text) <= DateTime.Now)
            {
                bDel.Visibility = Visibility.Hidden;
            }
        }

        private void init(Event events)
        {
            aDate.Text = Convert.ToString(events.date).Split(' ')[0];
            string time = Convert.ToString(events.time);
            aTime.Text = time.Split(':')[0] + ":" + time.Split(':')[1];
            aDescript.Text = events.description;
            aName.Text = events.name;
            aTheme.Text = events.theme;
        }
        private void loadData()
        {
            List<PertyTea> l = DataBaseConnect.DataBase.PertyTea.ToList().Where(tb => tb.Date == ev.date).ToList();
            List<string> teas = l.OrderBy(tb => tb.Name).Select(tb => tb.Name).ToList();
            List<string> guest = DataBaseConnect.DataBase.goPhoto.ToList().Where(tb => tb.Date == ev.date).OrderBy(tb => tb.surname).Select(tb => tb.surname + " " + tb.name + " " + tb.middleName).ToList();
            teaProgramm.ItemsSource = Converts(teas);
            guestsList.ItemsSource = Converts(guest);
        }
        public List<DataSee> Converts(List<string> List)
        {
            List<DataSee> val = new List<DataSee>();
            int j = 1;
            for (int i = 0; i < List.Count; i++)
            {
               val.Add(new DataSee{num = j++,value = List[i]});
            }
            return val;
        }
        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerMain(worker));
        }

        private void bDel_Click(object sender, RoutedEventArgs e)
        {
            //удадение из таблицы записи
            List<Record> r = DataBaseConnect.DataBase.Record.ToList().Where(tb => tb.idEvent == ev.idEvent).ToList();
            foreach (Record tb in r)
            {
                DataBaseConnect.DataBase.Record.Remove(tb);
            }
            //удадение из таблицы программы
            List<ProgrammEvent> t = DataBaseConnect.DataBase.ProgrammEvent.ToList().Where(tb => tb.idEvent == ev.idEvent).ToList();
            foreach (ProgrammEvent tb in t)
            {
                DataBaseConnect.DataBase.ProgrammEvent.Remove(tb);
            }
            DataBaseConnect.DataBase.Event.Remove(ev);
            DataBaseConnect.DataBase.SaveChanges();
            DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
            NavigationService.Navigate(new wWorkerMain(worker));
        }
    }
}
