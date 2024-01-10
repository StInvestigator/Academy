using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Lesson : INotifyPropertyChanged
    {
        public string name;
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
        public Lesson(string name)
        {
            this.name = name;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
