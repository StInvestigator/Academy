

using System.ComponentModel;

namespace Academy.Domain.Entities
{
    public class Student : INotifyPropertyChanged
    {
        int Id { get; set; }
        string groupName;
        string name;
        string surname;
        int age;
        string login;
        string password;

        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; NotifyPropertyChanged("Surname"); }
        }
        public int Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged("Age"); }
        }

        public string Login
        {
            get { return login; }
            set { login = value; NotifyPropertyChanged("Login"); }
        }
        public string Password { get => password; set => password = value; }

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; NotifyPropertyChanged("GroupName"); } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
