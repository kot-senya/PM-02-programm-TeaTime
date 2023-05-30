using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace teaTime.page
{
    /// <summary>
    /// Логика взаимодействия для wWorkerMain.xaml
    /// </summary>
    public partial class wWorkerMain : Page
    {
        public wWorkerMain()
        {
            InitializeComponent();
            loadedCalendar();
            loadedData();
            loadedColorData();
            changeEventDescription(DateTime.Now.ToString().Split(' ')[0]);
        }
        private void bRead_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wEventSee());
        }
        private void bwrite_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wEventAdd());
        }
        private void bUserProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wWorkerUserPrifile());
        }
        private void b_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            string day = bt.Content.ToString();
            int monthN = giveMonthNum(aMonth.Text.Split(' ')[0]);
            string month;
            if (int.Parse(day) < 10)
            {
                day = "0" + day;
            }
            if (monthN < 10)
            {
                month = "0" + monthN;
            }
            else
            {
                month = "" + monthN;
            }
            string dataheader = day + "." + month + "." + int.Parse(aMonth.Text.Split(' ')[1]);
            changeEventDescription(dataheader);
            //MessageBox.Show((sender as Button).Name);//отображение названия кнопки
        }
        private void loadedCalendar()
        {
            string dateNow = DateTime.Now.ToString(); //получение сегодняшней даты
            string yearNow = (dateNow.Split(' ')[0]).Split('.')[2];
            aMonth.Text = giveMonthName(int.Parse(dateNow.Split('.')[1])) + yearNow;
            int countDay = DateTime.DaysInMonth(int.Parse(yearNow), int.Parse(dateNow.Split('.')[1])); // количество дней в месяце
            int day = (int)DateTime.Parse("01." + (dateNow.Split('.')[1]) + "." + yearNow).DayOfWeek;
            if (day == 0)
            {
                day = 7;
            }
            nullValueButton();
            writeValueButton(countDay, day);
        }
        private void bRight_Click(object sender, RoutedEventArgs e)
        {
            string month = aMonth.Text.Split(' ')[0];
            int year = int.Parse(aMonth.Text.Split(' ')[1]);
            int numMonth = giveMonthNum(month);
            if (numMonth == 12)
            {
                year++;
                numMonth = 1;
            }
            else
            {
                numMonth++;
            }
            aMonth.Text = giveMonthName(numMonth) + year;
            nullValueButton();
            int countDay = DateTime.DaysInMonth(year, numMonth); // количество дней в месяце
            int day = (int)DateTime.Parse("01." + numMonth + "." + year).DayOfWeek;
            if (day == 0)
            {
                day = 7;
            }
            writeValueButton(countDay, day);
            nullColorDate();
            loadedColorData();
        }
        private void bLeft_Click(object sender, RoutedEventArgs e)
        {
            string month = aMonth.Text.Split(' ')[0];
            int year = int.Parse(aMonth.Text.Split(' ')[1]);
            int numMonth = giveMonthNum(month);
            if (numMonth == 1)
            {
                year--;
                numMonth = 12;
            }
            else
            {
                numMonth--;
            }
            aMonth.Text = giveMonthName(numMonth) + year;
            nullValueButton();
            int countDay = DateTime.DaysInMonth(year, numMonth); // количество дней в месяце
            int day = (int)DateTime.Parse("01." + numMonth + "." + year).DayOfWeek;
            if (day == 0)
            {
                day = 7;
            }
            writeValueButton(countDay, day);
            nullColorDate();
            loadedColorData();
        }
        private void nullValueButton()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    string nameButton = "b" + i + j;
                    changeContentButton(nameButton, "", false);
                }
            }
        }
        private void writeValueButton(int countDay, int day)
        {
            int week = 0;
            int num = 1;
            try
            {
                while (countDay > num)
                {
                    for (int j = day; j <= 7; j++)
                    {
                        string nameButton = "b" + week + j;
                        changeContentButton(nameButton, Convert.ToString(num), true);
                        if (num < countDay)
                        {
                            num++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    day = 1;
                    if (week > 5)
                    {
                        break;
                    }
                    else
                    {
                        week++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void changeContentButton(string name, string value, bool flag)
        {
            Button bt = (Button)this.FindName(name);
            bt.Content = value;
            if (flag)
            {
                bt.Visibility = Visibility.Visible;
            }
            else
            {
                bt.Visibility = Visibility.Hidden;
            }
        }
        private string giveMonthName(int num)
        {
            string nameMonth = "";
            switch (num) //выбор месяца
            {
                case (1):
                    nameMonth = "Январь ";
                    break;
                case (2):
                    nameMonth = "Февраль ";
                    break;
                case (3):
                    nameMonth = "Март ";
                    break;
                case (4):
                    nameMonth = "Апрель ";
                    break;
                case (5):
                    nameMonth = "Май ";
                    break;
                case (6):
                    nameMonth = "Июнь ";
                    break;
                case (7):
                    nameMonth = "Июль ";
                    break;
                case (8):
                    nameMonth = "Август ";
                    break;
                case (9):
                    nameMonth = "Сентябрь ";
                    break;
                case (10):
                    nameMonth = "Октябрь ";
                    break;
                case (11):
                    nameMonth = "Ноябрь ";
                    break;
                case (12):
                    nameMonth = "Декабрь ";
                    break;
            }
            return nameMonth;
        }
        private int giveMonthNum(string name)
        {
            switch (name)
            {
                case ("Январь"):
                    return 1;
                case ("Февраль"):
                    return 2;
                case ("Март"):
                    return 3;
                case ("Апрель"):
                    return 4;
                case ("Май"):
                    return 5;
                case ("Июнь"):
                    return 6;
                case ("Июль"):
                    return 7;
                case ("Август"):
                    return 8;
                case ("Сентябрь"):
                    return 9;
                case ("Октябрь"):
                    return 10;
                case ("Ноябрь"):
                    return 11;
                case ("Декабрь"):
                    return 12;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// новый код !!!
        /// </summary>
        BindingList<DataTimeEvent> dataTime = new BindingList<DataTimeEvent>();
        private void loadedData()
        {
            //цикл с загрузкой даты и ее описания
            
            
            
            
            dataTime.Add(new DataTimeEvent { Data = "15.05.2023", Time = "15:00", Name = "Proba 1", Theme = "Proba 1", Description = "Proba 1" });
            dataTime.Add(new DataTimeEvent { Data = "25.05.2023", Time = "15:00", Name = "Proba 2", Theme = "Proba 2", Description = "Proba 2" });
            dataTime.Add(new DataTimeEvent { Data = "10.04.2023", Time = "15:00", Name = "Proba 3", Theme = "Proba 3", Description = "Proba 3" });
            dataTime.Add(new DataTimeEvent { Data = "28.06.2023", Time = "15:00", Name = "Proba 4", Theme = "Proba 4", Description = "Proba 4" });
            dataTime.Add(new DataTimeEvent { Data = "02.06.2023", Time = "15:00", Name = "Proba 5", Theme = "Proba 5", Description = "Proba 5" });
        }
        Color Green = (Color)ColorConverter.ConvertFromString("#D3DB94");
        Color Yellow = (Color)ColorConverter.ConvertFromString("#FAEDCD");
        Color Brown = (Color)ColorConverter.ConvertFromString("#A77748");

        private void loadedColorData()
        {
            foreach (DataTimeEvent date in dataTime)
            {
                //string[] line = date.Data.Split('.');
                if (aMonth.Text == giveMonthName(int.Parse(date.Data.Split('.')[1])) + date.Data.Split('.')[2])
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            string name = "b" + j + i;
                            Button bt = (Button)this.FindName(name);
                            string contentButton = bt.Content.ToString().Replace('b', ' ').Trim();
                            string locDate = date.Data.Split('.')[0];
                            if (locDate[0] == '0')
                            {
                                locDate = locDate.Replace("0", "");
                            }

                            if (contentButton == locDate)
                            {
                                try
                                {
                                    colorRectangle(Green, name);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void nullColorDate()
        {
            for (int i = 1; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    string name = "b" + j + i;
                    colorRectangle(Yellow, name);
                }
            }
        }
        private void colorRectangle(Color colorName, string name)
        {
            Button bt = (Button)this.FindName(name);
            bt.Background = new SolidColorBrush(colorName);
        }
        private void changeEventDescription(string dateHeader)
        {
            noColorTextBlock();
            string header;
            bool flag = true;
            if (dateHeader == DateTime.Now.ToString().Split(':')[0])
            {
                header = "Сегодня";
            }
            else
            {
                header = dateHeader;
            }
            foreach (DataTimeEvent data in dataTime)
            {
                if (data.Data == dateHeader)
                {

                    header += " в " + data.Time;
                    aData.Text = header;
                    aName.Text = data.Name;
                    aDescript.Text = data.Description;
                    aTheme.Text = data.Theme;
                    aData.Visibility = Visibility.Visible;
                    aName0.Visibility = Visibility.Visible;
                    aTheme0.Visibility = Visibility.Visible;
                    aDescript0.Visibility = Visibility.Visible;
                    aName.Visibility = Visibility.Visible;
                    aTheme.Visibility = Visibility.Visible;
                    aDescript.Visibility = Visibility.Visible;
                    bRead.Visibility = Visibility.Visible;
                    bWrite.Visibility = Visibility.Hidden;
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                aData.Text = header;
                aData.Visibility = Visibility.Visible;
                aNoEvent.Visibility = Visibility.Visible;
                bRead.Visibility = Visibility.Hidden;
                if (DateTime.Parse(dateHeader) <= DateTime.Parse(DateTime.Now.ToString().Split(' ')[0]))
                {
                    bWrite.Visibility = Visibility.Hidden;
                }
                else
                {
                    bWrite.Visibility = Visibility.Visible;
                }

            }
        }
        private void noColorTextBlock()
        {
            aName0.Visibility = Visibility.Hidden;
            aTheme0.Visibility = Visibility.Hidden;
            aDescript0.Visibility = Visibility.Hidden;
            aData.Visibility = Visibility.Hidden;
            aName.Visibility = Visibility.Hidden;
            aTheme.Visibility = Visibility.Hidden;
            aDescript.Visibility = Visibility.Hidden;
            aNoEvent.Visibility = Visibility.Hidden;
            bWrite.Visibility = Visibility.Hidden;
            bRead.Visibility = Visibility.Hidden;
        }

    }
}
