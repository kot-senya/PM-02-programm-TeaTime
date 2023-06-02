using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
using System.Xml.Linq;
using System.ComponentModel;
using TeaTime;

namespace teaTime
{
    public partial class wMemberMain : Page
    {

        Color Green = (Color)ColorConverter.ConvertFromString("#D3DB94");
        Color Yellow = (Color)ColorConverter.ConvertFromString("#FAEDCD");
        Color Brown = (Color)ColorConverter.ConvertFromString("#A77748");
        Member member = new Member();
        public wMemberMain(Member user)
        {
            InitializeComponent();
            member = user;
            bUserProfile.Content = member.surname + " " + member.name[0] + "." + member.middleName[0] + ".";
            loadedCalendar();
            loadedData();
            loadedColorData();
            changeEventDescription(DateTime.Now.ToString().Split(':')[0]);
        }
        private void bUserProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberUserPrifile(member));
        }
        private void bReg_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            string day = bt.Content.ToString();
            int monthN = timeData.giveMonthNum(aMonth.Text.Split(' ')[0]);
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
        }
        private void loadedCalendar()
        {
            string dateNow = DateTime.Now.ToString(); //получение сегодняшней даты
            string yearNow = (dateNow.Split(' ')[0]).Split('.')[2];
            aMonth.Text = timeData.giveMonthName(int.Parse(dateNow.Split('.')[1])) + yearNow;
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
            int numMonth = timeData.giveMonthNum(month);
            if (numMonth == 12)
            {
                year++;
                numMonth = 1;
            }
            else
            {
                numMonth++;
            }
            aMonth.Text = timeData.giveMonthName(numMonth) + year;
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
            int numMonth = timeData.giveMonthNum(month);
            if (numMonth == 1)
            {
                year--;
                numMonth = 12;
            }
            else
            {
                numMonth--;
            }
            aMonth.Text = timeData.giveMonthName(numMonth) + year;
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
       
        List<DataTimeEvent> dataTime = new List<DataTimeEvent>();
        private void loadedData()
        {
            //цикл с загрузкой даты и ее описания
            using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
            {
                dataTime = new ConverterBase().Converter(DB.Event.ToList());
            }
        }
        private void loadedColorData()
        {
            foreach (DataTimeEvent date in dataTime)
            {
                //string[] line = date.Data.Split('.');
                if (aMonth.Text == timeData.giveMonthName(int.Parse(date.Data.Split('.')[1])) + date.Data.Split('.')[2])
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
                    if (DateTime.Parse(dateHeader) <= DateTime.Parse(DateTime.Now.ToString().Split(' ')[0]))
                    {
                        bReg.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        bReg.Visibility = Visibility.Visible;
                    }                    
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                aData.Text = header;
                aData.Visibility = Visibility.Visible;
                aNoEvent.Visibility = Visibility.Visible;
                bReg.Visibility = Visibility.Hidden;
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
            bReg.Visibility = Visibility.Hidden;
        }

    }
}

