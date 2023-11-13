using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public abstract class Human : INotifyPropertyChanged
    {
        string name;
        string surname;
        int age;
        string login;
        string password;

        public Human(string name, string surname, int age, string login, string password)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.login = login;
            this.password = password;
        }
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

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
