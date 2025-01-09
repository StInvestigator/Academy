using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Schedule : INotifyPropertyChanged
    {
        public int Id { get; set; }
        DateTime date;
        Teacher teacher;
        Group group;
        string @class;
        Lesson lesson;
        public DateTime Date { get => date; set { date = value; NotifyPropertyChanged("Date"); } }
        public Teacher Teacher { get => teacher; set { teacher = value; NotifyPropertyChanged("Teacher"); } }
        public Group Group { get => group; set { group = value; NotifyPropertyChanged("Group"); } }
        public string Class { get => @class; set { @class = value; NotifyPropertyChanged("Class"); } }
        public Lesson Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
