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
using teaTime.class_es;
using TeaTime;

namespace teaTime
{
    public class DataSee
    {
        public int num { get; set; }
        public string value { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для wEventSee.xaml
    /// </summary>
    public partial class wEventSee : Page
    {
        public wEventSee(DataTimeEvent events)
        {
            InitializeComponent();
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
            using (KotkovaISazonovaEntities1 DB = new KotkovaISazonovaEntities1())
            {
                List<DataSee> dataSees = from idEvent in 
            }
        }
        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerMain());
        }
    }
}
