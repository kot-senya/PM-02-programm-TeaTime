using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTime
{
    internal class timeData
    {
        public static string giveMonthName(int num)
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
        public static int giveMonthNum(string name)
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
    }
}
