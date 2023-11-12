using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Models
{
    public class TeacherModel
    {
        public string? name;
        public string? surname;
        public int? age;
        public string? login;
        public string? password;
        public TeacherModel(string? name, string? surname, int? age, string? login, string? password)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.login = login;
            this.password = password;
        }
        public TeacherModel(Teacher t)
        {
            name = t.Name;
            surname = t.Surname;
            age = t.Age;
            login = t.Login;
            password = t.Password;
        }
    }
}
