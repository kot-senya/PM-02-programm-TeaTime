using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace teaTime
{
    /// <summary>
    /// Логика взаимодействия для wMemberUserPrifile.xaml
    /// </summary>
    internal class Things
    {
        private int num;
        private string name;
        private string date;
        private string time;
        private string theme;
        private string descript = "";
        public int Num { get { return num; } set { num = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Date { get { return date; } set { date = value; } }
        public string Time { get { return time; } set { time = value; } }
        public string Theme { get { return theme; } set { theme = value; } }
        public string Descript { get { return descript; } set { descript = value; } }

    }
    public partial class wMemberUserPrifile : Page
    {
        public wMemberUserPrifile()
        {
            InitializeComponent();
        }

        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberChangePrifile());
        }

        private void bHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberMain());
        }
        private BindingList<Things> db;
        private void tInfo_Loaded(object sender, RoutedEventArgs e)
        {
            db = new BindingList<Things>();
            for(int i = 0; i < 15; i++)
            {
                Things a = new Things()
                {
                    Num = 1,
                    Name = "парарарарар",
                    Date = "10.02.2025",
                    Time = "18:00",
                    Theme = "саоатрмолвм",
                    Descript = "ааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааааа",
                };
                db.Add(a);
            }          
            //tInfo.ItemsSource = db;
        }

        private void tInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
