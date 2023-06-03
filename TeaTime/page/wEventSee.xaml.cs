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
        public wEventSee(DataTimeEvent events, Worker user, Event e)
        {
            worker = user;
            InitializeComponent();
            ev = e;
            init(events);
            loadData();
        }

        private void init(DataTimeEvent events)
        {
            aDate.Text = events.Data;
            aTime.Text = events.Time;
            aDescript.Text = events.Description;
            aName.Text = events.Name;
            aTheme.Text = events.Theme;
        }
        private void loadData()
        {
            using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
            {
                teaProgramm.ItemsSource = ConvertTea(DB.PertyTea.ToList());
                guestsList.ItemsSource = ConvertGuest(DB.goPhoto.ToList());
            }
        }
        public List<DataSee> ConvertGuest(List<goPhoto> List)
        {
            List<DataSee> val = new List<DataSee>();
            int j = 1;
            for (int i = 0; i < List.Count; i++)
            {
                if (DateTime.Parse(aDate.Text) == List[i].Date)
                {
                    val.Add(new DataSee
                    {
                        num = j++,
                        value = List[i].surname + " " + List[i].name + " " + List[i].middleName
                    });
                }

            }
            return val;
        }
        public List<DataSee> ConvertTea(List<PertyTea> List)
        {
            List<DataSee> val = new List<DataSee>();
            int j = 1;
            for (int i = 0; i < List.Count; i++)
            {
                if (DateTime.Parse(aDate.Text) == List[i].Date)
                {
                    val.Add(new DataSee
                    {
                        num = j++,
                        value = List[i].Name.ToString()
                    });
                }
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
            foreach(Record tb in r)
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
