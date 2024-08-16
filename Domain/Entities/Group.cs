
using System.Collections.Generic;
using System.ComponentModel;


namespace Academy.Domain.Entities
{
    public class Group : INotifyPropertyChanged
    {
        public int Id { get; set; }
        string name;
        int year;
        public string Name { get => name; set { name = value; NotifyPropertyChanged("Name"); } }
        public int Year { get => year; set { year = value; NotifyPropertyChanged("Year"); } }
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
