
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Academy.Domain.Entities
{
    public class Grade : INotifyPropertyChanged
    {
        DateOnly date;
        string workType;
        int gradeNumber;
        string studentLogin;
        string lesson;
        public Grade(DateOnly date, string workType, int GradeNumber, string studentLogin, string lesson)
        {
            this.date = date;
            this.workType = workType;
            this.gradeNumber = GradeNumber;
            this.studentLogin = studentLogin;
            this.lesson = lesson;
        }

        public DateOnly Date { get => date; set { date = value; NotifyPropertyChanged("Date"); } }
        public string WorkType { get => workType; set { workType = value; NotifyPropertyChanged("WorkType"); } }
        public int GradeNumber { get => gradeNumber; set { gradeNumber = value; NotifyPropertyChanged("GradeNumber"); } }
        public string StudentLogin { get => studentLogin; set { studentLogin = value; NotifyPropertyChanged("StudentLogin"); } }
        public string Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
