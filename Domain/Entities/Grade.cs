using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Academy.Domain.Entities
{
    public class Grade : IGrade, INotifyPropertyChanged
    {
        DateTime date;
        string workType;
        int gradeNumber;

        public Grade(DateTime date, string workType, int GradeNumber)
        {
            this.date = date;
            this.workType = workType;
            this.gradeNumber = GradeNumber;

        }

        public DateTime Date { get => date; set { date = value; NotifyPropertyChanged("Date"); } }
        public string WorkType { get => workType; set { workType = value; NotifyPropertyChanged("WorkType"); } }
        public int GradeNumber { get => gradeNumber; set { gradeNumber = value; NotifyPropertyChanged("GradeNumber"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
