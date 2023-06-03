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
            loadData();//загрузка данных о пользователе
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
                eventClose.ItemsSource = needEvent;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
