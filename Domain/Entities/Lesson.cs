﻿
using System.ComponentModel;


namespace Academy.Domain.Entities
{
    public class Lesson : INotifyPropertyChanged
    {
        public int Id { get; set; }
        string name;
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
