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
        DateOnly dateOnly;
        TimeOnly timeOnly;
        string teacherName;
        string teacherSurname;
        string groupName;
        string @class;
        string lesson;
        public DateOnly DateOnly { get => dateOnly; set { dateOnly = value; NotifyPropertyChanged("DateOnly"); } }
        public TimeOnly TimeOnly { get => timeOnly; set { timeOnly = value; NotifyPropertyChanged("TimeOnly"); } }
        public string TeacherName { get => teacherName; set { teacherName = value; NotifyPropertyChanged("TeacherName"); } }
        public string TeacherSurname { get => teacherSurname; set { teacherSurname = value; NotifyPropertyChanged("TeacherSurname"); } }
        public string GroupName { get => groupName; set { groupName = value; NotifyPropertyChanged("GroupName"); } }
        public string Class { get => @class; set { @class = value; NotifyPropertyChanged("Class"); } }
        public string Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }
        public Schedule(DateOnly dateOnly, TimeOnly timeOnly, string teacherName, string teacherSurname, string groupName, string @class, string lesson)
        {
            this.dateOnly = dateOnly;
            this.timeOnly = timeOnly;
            this.teacherName = teacherName;
            this.teacherSurname = teacherSurname;
            this.groupName = groupName;
            this.@class = @class;
            this.lesson = lesson;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
