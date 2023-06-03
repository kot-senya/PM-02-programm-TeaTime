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
using System.Windows.Shapes;

namespace TeaTime
{   
    public partial class memberEvent : Window
    {
        Member member = new Member();
        List<Event> events = new List<Event>();
        public memberEvent(Member user)
        {
            member = user;
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            List<Event> ev = DataBaseConnect.DataBase.Event.ToList();
            List<Record> r = DataBaseConnect.DataBase.Record.ToList().Where(tb => tb.idMember == member.idMember).ToList();//мероприятия на которые записан
            List<Event> allEvent = ev.Where(tb => tb.date > DateTime.Now).OrderBy(tb => tb.date).ToList();
            ObservableCollection<DataTimeEvent> needEvent = new ObservableCollection<DataTimeEvent>();
            ObservableCollection<DataTimeEvent> needEventAll = new ObservableCollection<DataTimeEvent>();
            foreach (Event e in allEvent)
            {
                DataTimeEvent a = new DataTimeEvent()
                {
                    Data = Convert.ToString(e.date).Split(' ')[0],
                    Name = e.name,
                    Theme = e.theme,
                    Description = e.description
                };
                needEventAll.Add(a);
            }
            for (int i = 0; i < allEvent.Count; i++)
            {
                for (int j = 0; j < r.Count; j++)
                {
                    if (r[j].idEvent == allEvent[i].idEvent)
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
                }
            }
            memberEvents.ItemsSource = needEvent;
            allEvents.ItemsSource = needEventAll;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            List<Event> ev = DataBaseConnect.DataBase.Event.ToList();
            List<Record> r = DataBaseConnect.DataBase.Record.ToList().Where(tb => tb.idMember == member.idMember).ToList();//мероприятия на которые записан
            List<Event> allEvent = ev.OrderBy(tb => tb.date).ToList();
            ObservableCollection<DataTimeEvent> needEvent = new ObservableCollection<DataTimeEvent>();
            for (int i = 0; i < allEvent.Count; i++)
            {
                for (int j = 0; j < r.Count; j++)
                {
                    if (r[j].idEvent == allEvent[i].idEvent)
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
                }
            }
            memberEvents.ItemsSource = needEvent;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Event> ev = DataBaseConnect.DataBase.Event.ToList();
            List<Record> r = DataBaseConnect.DataBase.Record.ToList().Where(tb => tb.idMember == member.idMember).ToList();//мероприятия на которые записан
            List<Event> allEvent = ev.Where(tb => tb.date > DateTime.Now).OrderBy(tb => tb.date).ToList();
            ObservableCollection<DataTimeEvent> needEvent = new ObservableCollection<DataTimeEvent>();
            for (int i = 0; i < allEvent.Count; i++)
            {
                for (int j = 0; j < r.Count; j++)
                {
                    if (r[j].idEvent == allEvent[i].idEvent)
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
                }
            }
            memberEvents.ItemsSource = needEvent;
        }

        private void ch1_Checked(object sender, RoutedEventArgs e)
        {
            List<Event> eve = DataBaseConnect.DataBase.Event.ToList();
            List<Event> allEvent = eve.OrderBy(tb => tb.date).ToList();
            ObservableCollection<DataTimeEvent> needEventAll = new ObservableCollection<DataTimeEvent>();
            foreach (Event ev in allEvent)
            {
                DataTimeEvent a = new DataTimeEvent()
                {
                    Data = Convert.ToString(ev.date).Split(' ')[0],
                    Name = ev.name,
                    Theme = ev.theme,
                    Description = ev.description
                };
                needEventAll.Add(a);
            }
            allEvents.ItemsSource = needEventAll;
        }

        private void ch1_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Event> eve = DataBaseConnect.DataBase.Event.ToList();
            List<Event> allEvent = eve.Where(tb => tb.date > DateTime.Now).OrderBy(tb => tb.date).ToList();
            ObservableCollection<DataTimeEvent> needEventAll = new ObservableCollection<DataTimeEvent>();
            foreach (Event ev in allEvent)
            {
                DataTimeEvent a = new DataTimeEvent()
                {
                    Data = Convert.ToString(ev.date).Split(' ')[0],
                    Name = ev.name,
                    Theme = ev.theme,
                    Description = ev.description
                };
                needEventAll.Add(a);
            }
            allEvents.ItemsSource = needEventAll;
        }
    }
}
