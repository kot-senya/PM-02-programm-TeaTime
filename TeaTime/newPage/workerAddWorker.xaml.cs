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

namespace TeaTime
{
    /// <summary>
    /// Логика взаимодействия для workerAddWorker.xaml
    /// </summary>
    public partial class workerAddWorker : Window
    {
        public workerAddWorker()
        {
            InitializeComponent();
        }
        private void bReg_Click(object sender, RoutedEventArgs e)
        {
            if (Checks.check(this))
            {
                try
                {
                    Worker newUser = new Worker()
                    {
                        surname = aSurname.Text,
                        name = aName.Text,
                        middleName = aMiddleName.Text,
                        phone = aPhoneNum.Text,
                        email = aEmail.Text,
                        login = aLogin.Text,
                        password = aPass.Password
                    };
                    DataBaseConnect.DataBase.Worker.Add(newUser);
                    DataBaseConnect.DataBase.SaveChanges();
                    DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
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
    }
}
