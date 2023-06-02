using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TeaTime
{
    public class TeaTimes : INotifyPropertyChanged
    {
        private string _endTea = "";
        private int _num;
        public int num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
                OnPropertyChanged("num");
            }
        }
        public string endTea
        {
            get
            {
                return _endTea;
            }
            set
            {
                _endTea = value;
            }
        }
        public List<string> value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
