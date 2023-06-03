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
        List<Event> dataTime = new List<Event>();
        Member member = new Member();
        public wMemberMain(Member user)
        {
            //получение данных о пользователе
            member = user;
            //инициализация компонентов страницы
            InitializeComponent();
            //присваивание значения Фамилии и инициалов Пользователя
            bUserProfile.Content = member.surname + " " + member.name[0] + "." + member.middleName[0] + ".";
            //Загрузка дат календаря
            loadedCalendar();
            //Загрузка дат, в которые проводятся события
            loadedData();
            //Раскрасить даты в кадендаре, в которые проводятся мероприятия
            loadedColorData();
            //Изменения данных о мероприятии, которое проводится Сеодня
            changeEventDescription(DateTime.Now.ToString().Split(' ')[0]);
        }
        private void bUserProfile_Click(object sender, RoutedEventArgs e)
        {
            //Нажатие на кнопку открывает страницу Профиля пользователя
            NavigationService.Navigate(new wMemberUserPrifile(member));
        }

        private void bDel_Click(object sender, RoutedEventArgs e)
        {
            //нахождение мероприятия по дате
            List<Event> ev = DataBaseConnect.DataBase.Event.ToList();
            DateTime dateEvent;
            if (aMonth.Text.Split(' ')[1] != "Сегодня")//инициализация даты
            {
                dateEvent = DateTime.Parse(aData.Text.Split(' ')[0]);
            }
            else
            {
                dateEvent = DateTime.Now;
            }
            List<Event> events = ev.Where(tb => tb.date == dateEvent).ToList();//нужное мероприятие
            List<Record> records = DataBaseConnect.DataBase.Record.ToList();
            List<Record> r = records.Where(tb => tb.idEvent == events[0].idEvent && tb.idMember == member.idMember).ToList();//запись на это меро
            DataBaseConnect.DataBase.Record.Remove(r[0]);
            DataBaseConnect.DataBase.SaveChanges();
            DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
            bReg.Visibility = Visibility.Visible;
            bDel.Visibility = Visibility.Hidden;
        }
        private void bReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //нахождение мероприятия по дате
                List<Event> ev = DataBaseConnect.DataBase.Event.ToList();
                DateTime dateEvent;
                if (aMonth.Text.Split(' ')[1] != "Сегодня")//инициализация даты
                {
                    dateEvent = DateTime.Parse(aData.Text.Split(' ')[0]);
                }
                else
                {
                    dateEvent = DateTime.Now;
                }
                List<Event> events = ev.Where(tb => tb.date == dateEvent).ToList();//нужное мероприятие
                                                                                   //запись
                Record r = new Record
                {
                    idRecord = 1,
                    idEvent = events[0].idEvent,
                    idMember = member.idMember
                };
                DataBaseConnect.DataBase.Record.Add(r);
                DataBaseConnect.DataBase.SaveChanges();
                DataBaseConnect.DataBase = new KotkovaISazonovaEntities_();
                bReg.Visibility = Visibility.Hidden;
                bDel.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void b_Click(object sender, RoutedEventArgs e)//Нажатие на кнопку с датой
        {
            Button bt = (Button)sender;//инициализация кнопки            
            string day = bt.Content.ToString();//инициализация дня кнопки            
            int monthN = timeData.giveMonthNum(aMonth.Text.Split(' ')[0]);//инициализация месяца
                                                                          //=> обращение к классу, метод которого по названию выводит номер месяца
            string month;//объявление стринговой переменной Месяц            
            string year = aMonth.Text.Split(' ')[1];//инициализация года

            if (int.Parse(day) < 10)//приведение переменной День к каноничному виду ДД
            {
                day = "0" + day;
            }
            if (monthN < 10)//приведение переменной Месяц к каноничному виду ММ
            {
                month = "0" + monthN;
            }
            else
            {
                month = "" + monthN;
            }
            string dataheader = day + "." + month + "." + year;//Формирование даты проведения мероприятия            
            changeEventDescription(dataheader);//вызов функции для изменения блока с информацией о мероприятии
        }
        private void loadedCalendar()
        {
            string dateNow = DateTime.Now.ToString(); //получение сегодняшней даты
            string yearNow = (dateNow.Split(' ')[0]).Split('.')[2];//получение года
            aMonth.Text = timeData.giveMonthName(int.Parse(dateNow.Split('.')[1])) + yearNow;//получение месяца => месяц + год - заголовок
            int countDay = DateTime.DaysInMonth(int.Parse(yearNow), int.Parse(dateNow.Split('.')[1])); // количество дней в месяце
            int day = (int)DateTime.Parse("01." + (dateNow.Split('.')[1]) + "." + yearNow).DayOfWeek;//получение дня недели с которого начинается месяц
            if (day == 0)//0 - воскресенье => 0 = 7
            {
                day = 7;
            }
            nullValueButton();//обнуление всех ячеек кадендаря
            writeValueButton(countDay, day);//запись всех дат в ячейки таблицы
        }
        private void bRight_Click(object sender, RoutedEventArgs e)
        {
            string month = aMonth.Text.Split(' ')[0];//получение месяца
            int year = int.Parse(aMonth.Text.Split(' ')[1]);//получение года
            int numMonth = timeData.giveMonthNum(month);//получение месяца по году
            if (numMonth == 12)//если декабрь, то слю месяц - январь
            {
                year++;
                numMonth = 1;
            }
            else//иначе просто сл месяц
            {
                numMonth++;
            }
            aMonth.Text = timeData.giveMonthName(numMonth) + year;//заголовок
            nullValueButton();//обнуление значения
            int countDay = DateTime.DaysInMonth(year, numMonth); // количество дней в месяце
            int day = (int)DateTime.Parse("01." + numMonth + "." + year).DayOfWeek;//получение дня недели с которого начинается месяц
            if (day == 0)//0 - воскресенье => 0 = 7
            {
                day = 7;
            }
            writeValueButton(countDay, day);//запись всех дат в ячейки таблицы
            nullColorDate();//обнуление цвета
            loadedColorData();//закрасить ячейки с мероприятем
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
                    string nameButton = "b" + i + j;//название кнопки
                    changeContentButton(nameButton, "", false);//изменение кнопки 
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
        private void loadedData()
        {
            dataTime = DataBaseConnect.DataBase.Event.ToList();//цикл с загрузкой даты и ее описания
        }
        private void loadedColorData()
        {
            foreach (Event date in dataTime)
            {
                if (aMonth.Text == timeData.giveMonthName(int.Parse(Convert.ToString(date.date).Split('.')[1])) + Convert.ToString(date.date).Split(' ')[0].Split('.')[2])
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            string name = "b" + j + i;
                            Button bt = (Button)this.FindName(name);
                            string contentButton = bt.Content.ToString().Replace('b', ' ').Trim();
                            string locDate = Convert.ToString(date.date).Split('.')[0];
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
            //новый заголовок
            if (dateHeader == DateTime.Now.ToString().Split(' ')[0])
            {
                header = "Сегодня";
            }
            else
            {
                header = dateHeader;
            }
            foreach (Event data in dataTime)
            {
                if (Convert.ToString(data.date).Split(' ')[0] == dateHeader)
                {
                    //присвоение значений описанию
                    header += " в " + data.time;
                    aData.Text = header;
                    aName.Text = data.name;
                    aDescript.Text = data.description;
                    aTheme.Text = data.theme;
                    //включение видимости
                    aData.Visibility = Visibility.Visible;
                    aName0.Visibility = Visibility.Visible;
                    aTheme0.Visibility = Visibility.Visible;
                    aDescript0.Visibility = Visibility.Visible;
                    aName.Visibility = Visibility.Visible;
                    aTheme.Visibility = Visibility.Visible;
                    aDescript.Visibility = Visibility.Visible;
                    //проверка кнопок
                    if (data.date <= DateTime.Now)
                    {
                        //отключение видимости кнопок если дата меро меньше сегодняшней
                        bReg.Visibility = Visibility.Hidden;
                        bDel.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        //проверка записан или нет
                        checkWrite(data.idEvent);
                    }
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                //показать сведения о том что меро нет на этот день
                aData.Text = header;
                aData.Visibility = Visibility.Visible;
                aNoEvent.Visibility = Visibility.Visible;
                bReg.Visibility = Visibility.Hidden;
                bDel.Visibility = Visibility.Hidden;
            }
        }
        private void checkWrite(int idEvent)
        {
            //проверка записан человек или нет
            List<Record> records = DataBaseConnect.DataBase.Record.ToList();//получение всех значений таблицы
            List<Record> check = records.Where(tb => tb.idMember == member.idMember && tb.idEvent == idEvent).ToList();
            if (check.Count == 0)
            {
                bReg.Visibility = Visibility.Visible;
            }
            else
            {
                bDel.Visibility = Visibility.Visible;
            }
        }
        private void noColorTextBlock()
        {
            //отключение видимости всех полей сведений о мероприятии
            aName0.Visibility = Visibility.Hidden;
            aTheme0.Visibility = Visibility.Hidden;
            aDescript0.Visibility = Visibility.Hidden;
            aData.Visibility = Visibility.Hidden;
            aName.Visibility = Visibility.Hidden;
            aTheme.Visibility = Visibility.Hidden;
            aDescript.Visibility = Visibility.Hidden;
            aNoEvent.Visibility = Visibility.Hidden;
            bReg.Visibility = Visibility.Hidden;
            bDel.Visibility = Visibility.Hidden;
        }
    }
}

