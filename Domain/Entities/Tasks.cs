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
        int Id { get; set; }
        public string description;
        public string type;
        public string lesson;
        public DateOnly termin;
        public string studentLogin;
        public string Description { get => description; set { description = value; NotifyPropertyChanged("Description"); } }
        public string Type { get => type; set { type = value; NotifyPropertyChanged("Type"); } }
        public string Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }
        public DateOnly Termin { get => termin; set { termin = value; NotifyPropertyChanged("Termin"); } }
        public string StudentLogin { get => studentLogin; set { studentLogin = value; NotifyPropertyChanged("StudentLogin"); } }
        public bool isDone { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
