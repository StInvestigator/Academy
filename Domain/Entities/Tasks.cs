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
        public DateOnly termin;
        public string studentLogin;
        public string Description { get => description; set { description = value; NotifyPropertyChanged("Description"); } }
        public string Type { get => type; set { type = value; NotifyPropertyChanged("Type"); } }
        public string Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }
        public DateOnly Termin { get => termin; set { termin = value; NotifyPropertyChanged("Termin"); } }
        public string StudentLogin { get => studentLogin; set { studentLogin = value; NotifyPropertyChanged("StudentLogin"); } }
        public bool isDone { get; set; }
        public Task(string description, string type, string lesson, DateOnly termin,string studentLogin, bool isDone)
        {
            this.description = description;
            this.type = type;
            this.lesson = lesson;
            this.termin = termin;
            this.studentLogin = studentLogin;
            this.isDone = isDone;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
