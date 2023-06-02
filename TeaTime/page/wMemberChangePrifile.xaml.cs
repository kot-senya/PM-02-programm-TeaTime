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
    /// <summary>
    /// Логика взаимодействия для wMemberChangePrifile.xaml
    /// </summary>
    public partial class wMemberChangePrifile : Page
    {
        Member member = new Member();
        public wMemberChangePrifile(Member user)
        {
            InitializeComponent();
            member = user;
            loadData();
        }
        private void loadData()
        {
            aSurname.Text = member.surname;
            aName.Text = member.name;
            aMiddleName.Text = member.middleName;
            aPhoneNum.Text = member.phone;
            aEmail.Text = member.email;
            aLogin.Text = member.login;
            aPass.Password = member.password;
        }
        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberUserPrifile(member));
        }
        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerUserPrifile(worker));
        }
    }
}
