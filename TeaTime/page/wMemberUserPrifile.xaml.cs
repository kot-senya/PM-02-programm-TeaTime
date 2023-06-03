using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TeaTime;

namespace teaTime
{
    public partial class wMemberUserPrifile : Page
    {
        Member member = new Member();
        public wMemberUserPrifile(Member user)
        {
            this.member = user;
            InitializeComponent();

            loadData();
        }
        private void loadData()
        {
            aFIO.Text = member.surname + " " + member.name + " " + member.middleName;
            aPhoneNumber.Text = member.phone;
            aEmail.Text = member.email;
        }
        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberChangePrifile(member));
        }
        private void bHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberMain(member));
        }
        private void eventClose_Initialized(object sender, EventArgs e)
        {
            try
            {
                using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
                {
                    ObservableCollection<DataTimeEvent> needEvent = new ObservableCollection<DataTimeEvent>();
                    List<DataTimeEvent> allEvent = new ConverterBase().Converter(DB.Event.ToList(), DateTime.Now, ref member);
                    foreach (DataTimeEvent a in allEvent)
                    {
                        needEvent.Add(a);
                    }
                    eventClose.ItemsSource = needEvent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
