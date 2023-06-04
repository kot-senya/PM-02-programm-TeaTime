using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
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
using System.Windows.Shapes;
using teaTime;

namespace TeaTime.newPage
{
    public partial class workerChengeEvent : Window
    {
        ObservableCollection<DataSee> teas = new ObservableCollection<DataSee>();
        List<DataSee> teaDel = new List<DataSee>();
        List<Event> l = new List<Event>();
        Event _ev;
        bool flagAdd = false;
        bool flagDel = false;
        public workerChengeEvent()
        {
            InitializeComponent();
            bAdd.Visibility = Visibility.Hidden;
            bDell.Visibility = Visibility.Hidden;
            bWrite.Visibility = Visibility.Hidden;
        }
        private void nMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //bнициализация времение
            string hour = nHour.Text;
            string min = nMin.SelectedItem.ToString();
            if (hour == "")//bнициализация времение
            {
                hour = "09";
            }
            aTime.Text = hour + ":" + min;
        }
        private void nHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //bнициализация времение
                string hour = nHour.SelectedItem.ToString();
                string min = nMin.Text;
                if (min == "")//если не задано, то пустое
                {
                    min = "00";
                }
                aTime.Text = hour + ":" + min;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void bWrite_Click(object sender, RoutedEventArgs e)
        {
            List<Tea> t = DataBaseConnect.DataBase.Tea.ToList();
            for (int i = 0; i < teas.Count; i++)//добавление записей
            {
                List<int> idTea = t.Where(tb => tb.name == teas[i].value).Select(tb => tb.idTea).ToList();//id чая, который будет на мероприятии
                if (idTea.Count != 0)// если не нашел id то бесполезно что-либо делать
                {
                    List<ProgrammEvent> p = DataBaseConnect.DataBase.ProgrammEvent.ToList().Where(tb => tb.idEvent == _ev.idEvent).ToList();
                    List<ProgrammEvent> list = p.Where(tb => tb.idTea == idTea[0]).ToList();// нахождение нужной записи
                    if (list.Count == 0)//если нет, добавляем
                    {
                        ProgrammEvent newPE = new ProgrammEvent()
                        {
                            idPogrammEvent = 1,
                            idEvent = _ev.idEvent,
                            idTea = idTea[0]
                        };
                        DataBaseConnect.DataBase.ProgrammEvent.Add(newPE);
                        DataBaseConnect.DataBase.SaveChanges();
                    }
                }
            }
            List<ProgrammEvent> pe = DataBaseConnect.DataBase.ProgrammEvent.ToList().Where(tb => tb.idEvent == _ev.idEvent).ToList();                    
            for (int i = 0; i < pe.Count; i++)//удаление записей
            {
                List<string> nameTea = t.Where(tb => tb.idTea == pe[i].idTea).Select(tb => tb.name).ToList();//id чая, который будет на мероприятии
                if (nameTea.Count != 0)// если не нашел имя то бесполезно что-либо делать
                {
                    List<DataSee> list = teas.Where(tb => tb.value == nameTea[0]).ToList();// нахождение нужной записи
                    if (list.Count == 0)//если нет, удаляем
                    {
                        DataBaseConnect.DataBase.ProgrammEvent.Remove(pe[i]);
                        DataBaseConnect.DataBase.SaveChanges();
                    }
                }
            }
            //изменение данных о мероприятии
            _ev.time = TimeSpan.Parse(aTime.Text);
            _ev.name = aName.Text;
            _ev.theme = aTheme.Text;
            _ev.description = aDescript.Text;
            DataBaseConnect.DataBase.Event.AddOrUpdate(_ev);
            DataBaseConnect.DataBase.SaveChanges();
            DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
            MessageBox.Show("Cведения о мероприятии успешно изменены");
            this.Close();

        }
        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            l = DataBaseConnect.DataBase.Event.ToList().Where(tb => tb.date == DateTime.Parse(dp.Text) && tb.date > DateTime.Now).ToList();
            if (l.Count == 0)
            {
                aTime.Text = "";
                aName.Text = "";
                aTheme.Text = "";
                aDescript.Text = "";
                MessageBox.Show("Редактирование на этот день недоступно");
                bAdd.Visibility = Visibility.Hidden;
                bDell.Visibility = Visibility.Hidden;
                newTea.Visibility = Visibility.Collapsed;
                bWrite.Visibility = Visibility.Hidden;
            }
            else
            {
                _ev = l[0];
                string time = Convert.ToString(l[0].time);
                aTime.Text = time.Split(':')[0] + ':' + time.Split(':')[1];
                aName.Text = l[0].name;
                aTheme.Text = l[0].theme;
                aDescript.Text = l[0].description;
                bAdd.Visibility = Visibility.Visible;
                bDell.Visibility = Visibility.Visible;
                bWrite.Visibility = Visibility.Visible;
                loadTea(0);
            }
        }
        public void loadTea(int k)
        {
            List<string> t = new List<string>();
            switch (k)
            {
                case (0):
                    {
                        List<ProgrammEvent> p = DataBaseConnect.DataBase.ProgrammEvent.ToList().Where(tb => tb.idEvent == _ev.idEvent).OrderBy(tb => tb.idTea).ToList();//какой чай пьют
                        foreach (ProgrammEvent pe in p)
                        {
                            teas.Add(new DataSee { num = teas.Count + 1, value = DataBaseConnect.DataBase.Tea.ToList().Where(tb => tb.idTea == pe.idTea).Select(tb => tb.name).ToList()[0] });
                        }
                        teaProgramm.ItemsSource = null;
                        teaProgramm.ItemsSource = new ObservableCollection<DataSee>();
                        teaProgramm.ItemsSource = teas;
                    }
                    break;
                case (1):
                    {
                        if (newTea.Text != "")
                        {
                            teas.Add(new DataSee { num = teas.Count + 1, value = newTea.Text });
                            teaProgramm.ItemsSource = null;
                            teaProgramm.ItemsSource = new ObservableCollection<DataSee>();
                            teaProgramm.ItemsSource = teas;
                        }
                    }
                    break;
                case (2):
                    {
                        if (newTea.Text != "")
                        {
                            List<DataSee> s = teas.Where(tb => tb.value == newTea.Text).ToList();
                            if (s.Count != 0)
                            {
                                teas.Remove(s[0]);
                                for (int i = 0; i < teas.Count; i++)
                                {
                                    teas[i].num = i + 1;
                                }
                                teaProgramm.ItemsSource = null;
                                teaProgramm.ItemsSource = new ObservableCollection<DataSee>();
                                teaProgramm.ItemsSource = teas;
                            }
                        }
                    }
                    break;
            }
            switch (k)
            {
                case (1):
                    {
                        t = DataBaseConnect.DataBase.Tea.ToList().Select(tb => tb.name).ToList();
                        int j = 0;
                        for (int i = 0; i < teas.Count; i++)
                        {
                            if (t.Count == 0)
                            {
                                break;
                            }
                            List<DataSee> d = teas.Where(tb => tb.value == t[j]).ToList();
                            if (d.Count != 0)
                            {
                                t.RemoveAt(j);
                            }
                            else
                            {
                                j++;
                            }
                        }
                        newTea.ItemsSource = null;
                        newTea.ItemsSource = new List<string>();
                        newTea.ItemsSource = t;
                    }
                    break;
                case (2):
                    {
                        for (int i = 0; i < teas.Count; i++)
                        {
                            t = teas.Select(tb => tb.value).ToList();
                        }
                        newTea.ItemsSource = null;
                        newTea.ItemsSource = new List<string>();
                        newTea.ItemsSource = t;
                    }
                    break;
            }
        }
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (flagAdd && newTea.Text != "" && !flagDel)
            {
                loadTea(1);
                newTea.Visibility = Visibility.Collapsed;
                flagAdd = false;
            }
            else if (flagDel)
            {
                MessageBox.Show("Операция удаления отменена");
                newTea.Text = "";
                loadTea(2);
            }
            else
            {
                MessageBox.Show("Выберите чай для добавления и нажмите кнопку еще раз");
                newTea.Text = "";
                loadTea(1);
                newTea.Visibility = Visibility.Visible;
                flagAdd = true;
            }

        }
        private void bDell_Click(object sender, RoutedEventArgs e)
        {
            if (flagDel && newTea.Text != "" && !flagAdd)
            {
                loadTea(2);
                newTea.Visibility = Visibility.Collapsed;
                flagDel = false;
            }
            else if (flagAdd)
            {
                MessageBox.Show("Операция добавления отменена");
                newTea.Text = "";
                loadTea(1);
            }
            else
            {

                MessageBox.Show("Выберите чай для удаления и нажмите кнопку еще раз");
                newTea.Text = "";
                loadTea(2);
                newTea.Visibility = Visibility.Visible;
                flagDel = true;
            }
        }
    }
}
