using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Task : INotifyPropertyChanged
    {
        public int Id { get; set; }
        string description;
        string workType;
        Lesson lesson;
        DateTime date;
        Student student;
        [Column("Desctiption")]
        public string Description { get => description; set { description = value; NotifyPropertyChanged("Description"); } }
        public string WorkType { get => workType; set { workType = value; NotifyPropertyChanged("WorkType"); } }
        public Lesson Lesson { get => lesson; set { lesson = value; NotifyPropertyChanged("Lesson"); } }
        public DateTime Date { get => date; set { date = value; NotifyPropertyChanged("Date"); } }
        public Student Student { get => student; set { student = value; NotifyPropertyChanged("Student"); } }
        public bool isDone { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
