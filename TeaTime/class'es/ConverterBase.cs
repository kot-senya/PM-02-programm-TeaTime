using System;
using System.Collections.Generic;

namespace TeaTime
{
    public class ConverterBase
    {
        public List<DataTimeEvent> Converter(List<Event> List)
        {
            List<DataTimeEvent> dataTimeEvents = new List<DataTimeEvent>();
            sort(List);
            for (int i = 0; i < List.Count; i++)
            {
                dataTimeEvents.Add(new DataTimeEvent
                {
                    Data = Convert.ToString(List[i].date).Split(' ')[0],
                    Time = Convert.ToString(List[i].time).Split(':')[0] + ":" + Convert.ToString(List[i].time).Split(':')[1],
                    Name = List[i].name,
                    Description = List[i].description,
                    Theme = List[i].theme
                });
            }
            return dataTimeEvents;
        }

        public List<DataTimeEvent> Converter(List<Event> List, DateTime date)
        {
            sort(List);
            List<DataTimeEvent> dataTimeEvents = new List<DataTimeEvent>();
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].date > date)
                {
                    dataTimeEvents.Add(new DataTimeEvent
                    {
                        Data = Convert.ToString(List[i].date).Split(' ')[0] + " " + Convert.ToString(List[i].time).Split(':')[0] + ":" + Convert.ToString(List[i].time).Split(':')[1],
                        Name = List[i].name,
                        Description = List[i].description,
                        Theme = List[i].theme
                    });
                }
            }
            return dataTimeEvents;
        }
        private void sort(List<Event> List)
        {
            Event bufer;
            for(int i = 0; i < List.Count; i++)
            {
                for(int j = i + 1; j < List.Count; j++)
                {
                    if (List[i].date > List[j].date)
                    {
                        bufer = List[i];
                        List[i] = List[j];
                        List[j] = bufer;
                    }
                }
            }
        }
    }
}