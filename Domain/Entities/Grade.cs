
using System;
using System.ComponentModel;


namespace Academy.Domain.Entities
{
    public class Grade : INotifyPropertyChanged
    {
        public int Id { get; set; }
        DateTime date;
        string workType;
        int gradeNumber;
        Student student;
        Lesson lesson;

        public DateTime Date { get => date; set { date = value; NotifyPropertyChanged("Date"); } }
        public string WorkType { get => workType; set { workType = value; NotifyPropertyChanged("WorkType"); } }
        public int GradeNumber { get => gradeNumber; set { gradeNumber = value; NotifyPropertyChanged("GradeNumber"); } }
        public Student Student { get => student; set { student = value; NotifyPropertyChanged("Student"); } }
        public Lesson Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
