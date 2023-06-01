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
    public class TeaTime : INotifyPropertyChanged
    {
        private string _endTea = "";
        private int _num;
        public int num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
                OnPropertyChanged("num");
            }
        }
        public string endTea
        {
            get
            {
                return _endTea;
            }
            set
            {
                _endTea = value;
            }
        }
        public List<string> value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public partial class wEventAdd : Page
    {
        ObservableCollection<TeaTime> items = new ObservableCollection<TeaTime>();
        List<string> teaList = new List<string>();
        public wEventAdd(DateTime data)
        {
            InitializeComponent();
            dp.Text = data.ToString();
            //выгрузка из бд
            nameTeaLoaded(teaList);
        }

        private void nMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string hour = nHour.Text;
            string min = nMin.SelectedItem.ToString();
            if (hour == "")
            {
                hour = "00";
            }
            aTime.Text = hour + ":" + min;
        }
        private void nHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string hour = nHour.SelectedItem.ToString();
            string min = nMin.Text;
            if (min == "")
            {
                min = "00";
            }
            aTime.Text = hour + ":" + min;
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
                using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
                {
                    teaList = Converter(DB.Tea.ToList());
                    items.Add(new TeaTime() { num = items.Count + 1, value = teaList });
                    nameTea.ItemsSource = items;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public List<string> Converter(List<Tea> teas)
        {
            List<string> teaListNew = new List<string>();
            for (int i = 0; i < teas.Count; i++)
            {
                teaListNew.Add(teas[i].name); ;
            }
            return teaListNew;
        }

        private void nameTea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var name = (listbox.SelectedItem as nameTea).Name;
            //string t = (nameTea.SelectedItem as ComboBoxItem).SelectedItem.ToString();
            //MessageBox.Show((nameTea.SelectedItem as TextBlock).Text);


            nameTeaLoaded(teaList);
            nameTea.ItemsSource = items;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new wWorkerMain());
        }

        private void bwrite_Click(object sender, RoutedEventArgs e)
        {
            //записьмероприятия в бд            

            foreach (TeaTime a in nameTea.ItemsSource)//какой чай
            {
                if (a.endTea != "")
                {
                    string b = a.endTea;
                }
            }
            //NavigationService.Navigate(new wWorkerMain());
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

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
