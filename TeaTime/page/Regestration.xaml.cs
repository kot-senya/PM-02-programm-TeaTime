using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Regestration.xaml
    /// </summary>
    public partial class Regestration : Page
    {
        public Regestration()
        {
            InitializeComponent();
        }       
        private void bReg_Click(object sender, RoutedEventArgs e)
        {
            if (Checks.check(this))
            {
                try
                {
                    List<Member> List = DataBaseConnect.DataBase.Member.ToList();
                    var lastItem = List.Last();
                    Member newUser = new Member()
                    {
                        surname = aSurname.Text,
                        name = aName.Text,
                        middleName = aMiddleName.Text,
                        phone = aPhoneNum.Text,
                        email = aEmail.Text,
                        login = aLogin.Text,
                        password = aPass.Password
                    };
                    DataBaseConnect.DataBase.Member.Add(newUser);
                    DataBaseConnect.DataBase.SaveChanges();
                    DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
                    NavigationService.Navigate(new Authorization());
                }
                catch
                {
                    MessageBox.Show("При регистрации возникли технические неполадки попробуйте еще раз");
                }
            }
            else
            {
                MessageBox.Show("При регистрации возникли ошибки!\nПожалуйста перепроверьте введенные Вами данные или обратитесь к подсказкам справа.");
            }

        }
        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
