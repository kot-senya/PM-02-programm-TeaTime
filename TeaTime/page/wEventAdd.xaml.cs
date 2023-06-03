using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для wEventAdd.xaml
    /// </summary>

    public partial class wEventAdd : Page
    {
        ObservableCollection<TeaTimes> items = new ObservableCollection<TeaTimes>();
        List<string> teaList = new List<string>();
        Worker worker = new Worker();
        public wEventAdd(DateTime data, Worker user)
        {
            InitializeComponent();
            dp.Text = data.ToString();
            worker = user;
            nameTeaLoaded(teaList);
        }
        private void nMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //bнициализация времение
            string hour = nHour.Text;
            string min = nMin.SelectedItem.ToString();
            if (hour == "")//bнициализация времение
            {
                hour = "09";
            }
            aTime.Text = hour + ":" + min;
        }
        private void nHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //bнициализация времение
                string hour = nHour.SelectedItem.ToString();
                string min = nMin.Text;
                if (min == "")//если не задано, то пустое
                {
                    min = "00";
                }
                aTime.Text = hour + ":" + min;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void nMin_Initialized(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                nMin.Items.Add(i.ToString());
            }
        }
        private void nHour_Initialized(object sender, EventArgs e)
        {
            for (int i = 9; i < 23; i++)
            {
                nHour.Items.Add(i.ToString());
            }
        }
        private void nameTeaLoaded(List<string> teaList)
        {
            try
            {
                List<Tea> t = DataBaseConnect.DataBase.Tea.ToList();
                teaList = t.Select(tb => tb.name).ToList();
                items.Add(new TeaTimes() { num = items.Count + 1, value = teaList });
                nameTea.ItemsSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void nameTea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool flag = true;
            foreach (TeaTimes a in nameTea.ItemsSource)//какой чай
            {
                if (a.endTea == "")
                {
                    flag = false;
                    break;
                }
                else
                {
                    teaList.Remove(a.endTea);
                }
            }
            if (flag)
            {
                nameTeaLoaded(teaList);
                nameTea.ItemsSource = items;
            }

        }
        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerMain(worker));
        }
        private void bwrite_Click(object sender, RoutedEventArgs e)
        {
            if (Checks.check(this))
            {
               Event newEvent = new Event()//запись нового эвента
                {
                    idEvent = 1,
                    date = DateTime.Parse(dp.Text),
                    name = aName.Text,
                    theme = aTheme.Text,
                    time = TimeSpan.Parse(aTime.Text),
                    idWorker = worker.idWorker,
                    description = aDescript.Text
                };
                DataBaseConnect.DataBase.Event.Add(newEvent);
                foreach (TeaTimes a in nameTea.ItemsSource)//какой чай
                {
                    if (a.endTea != "")
                    {
                        ProgrammEvent newTea = new ProgrammEvent()//запись нового чая
                        {
                            idPogrammEvent = 1,
                            idEvent = newEvent.idEvent,
                            idTea = new ConverterBase().Converter(DataBaseConnect.DataBase.Tea.ToList(), a.endTea)
                        };
                        DataBaseConnect.DataBase.ProgrammEvent.Add(newTea);
                        DataBaseConnect.DataBase.SaveChanges();
                    }
                }
                DataBaseConnect.DataBase.SaveChanges();
                DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
                NavigationService.Navigate(new wWorkerMain(worker));
            }
            else
            {
                MessageBox.Show("Не все поля были заполнены. Аерепроверьте введенные данные и повторите ввод.");
            }
        }
        private void DatePicker_Initialized(object sender, EventArgs e)
        {
            dp.BlackoutDates.AddDatesInPast();
            dp.BlackoutDates.Add(new CalendarDateRange(DateTime.Now));

            using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
            {
                List<Event> List = DB.Event.ToList();
                for (int i = 0; i < List.Count; i++)
                {
                    dp.BlackoutDates.Add(new CalendarDateRange(List[i].date));
                }
            }
        }
    }
}
