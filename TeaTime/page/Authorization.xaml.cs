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
using teaTime;
using TeaTime;

namespace teaTime
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        Worker worker = new Worker();
        Member member = new Member();
        private void bAuth_Click(object sender, RoutedEventArgs e)
        {
            if(checkWorker(aLogin.Text, aPass.Password))
            {
                NavigationService.Navigate(new wWorkerMain(worker));
            }
            else if (checkMember(aLogin.Text, aPass.Password))
            {
                NavigationService.Navigate(new wMemberMain(member));
            }
            else
            {
                MessageBox.Show("Не найдено");
            }
            
        }
        public bool checkWorker(string login, string password)
        {
            bool check = false;
            using(KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
            {
                List<Worker> w = DB.Worker.ToList();
                for(int i = 0; i < w.Count; i++)
                {
                    if(w[i].login == login && w[i].password == password)
                    {
                        check = true;
                        worker = w[i];
                    }
                }
            }
            return check;
        }
        public bool checkMember(string login, string password)
        {
            bool check = false;
            using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
            {
                List<Member> m = DB.Member.ToList();
                for (int i = 0; i < m.Count; i++)
                {
                    if (m[i].login == login && m[i].password == password)
                    {
                        check = true;
                        member = m[i];
                    }
                }
            }
            return check;
        }
        private void bReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Regestration());
        }
    }
}
