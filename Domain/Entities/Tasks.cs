using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Task : INotifyPropertyChanged
    {
        public string description;
        public string type;
        public string lesson;
        public DateTime termin;
        public string Description { get => description; set { description = value; NotifyPropertyChanged("Description"); } }
        public string Type { get => type; set { type = value; NotifyPropertyChanged("Type"); } }
        public string Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }
        public DateTime Termin { get => termin; set { termin = value; NotifyPropertyChanged("Termin"); } }
        public string StudentLogin { get; set; }
        public Task(string description, string type, string lesson, DateTime termin,string sl)
        {
            this.description = description;
            this.type = type;
            this.lesson = lesson;
            this.termin = termin;
            StudentLogin = sl;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
