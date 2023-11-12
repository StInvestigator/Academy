using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public abstract class Human
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
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
    }
}
