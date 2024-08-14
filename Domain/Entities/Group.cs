
using System.ComponentModel;


namespace Academy.Domain.Entities
{
    public class Group : INotifyPropertyChanged
    {
        string name;
        int year;
        int studentsCount;
        public string Name { get => name; set { name = value; NotifyPropertyChanged("Name"); } }
        public int Year { get => year; set { year = value; NotifyPropertyChanged("Year"); } }
        public int StudentsCount { get => studentsCount; set { studentsCount = value; NotifyPropertyChanged("StudentsCount"); } }
        public Group(string name, int year, int studentsCount) 
        {
            this.name = name;
            this.year = year;
            this.studentsCount = studentsCount;
        }
        public void nextYear()
        {
            Year++;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
