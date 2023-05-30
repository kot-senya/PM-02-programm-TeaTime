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

namespace teaTime.page
{
    /// <summary>
    /// Логика взаимодействия для wEventAdd.xaml
    /// </summary>
    public class Tea
    {
        public string Num { get; set; }
        public List<string> value { get; set; }
    }
    public partial class wEventAdd : Page
    {
        List<Tea> items = new List<Tea>();
        List<string> teaList = new List<string>();
        int num = 1;
        public wEventAdd()
        {
            InitializeComponent();

            //выгрузка из бд
            teaList.Add("черный");
            teaList.Add("красный");
            teaList.Add("белый");
            nameTeaLoaded(items, teaList);
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
        private void nameTeaLoaded(List<Tea> items, List<string> teaList)
        {
            try
            {
                Tea tea = new Tea() { Num = (num++).ToString(), value = teaList };
                items.Add(tea);
                nameTea.Items.Add(items);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void nameTea_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            nameTeaLoaded(items, teaList);
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerMain());
        }

        private void bwrite_Click(object sender, RoutedEventArgs e)
        {
            //записьмероприятия в бд
            NavigationService.Navigate(new wWorkerMain());
        }
    }
}
