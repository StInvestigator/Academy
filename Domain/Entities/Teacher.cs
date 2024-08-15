
using System;

namespace Academy.Domain.Entities
{
    public class Teacher : Human
    {
        public Teacher(string login, string password, string name, string surname, int age) : base(name, surname, age, login, password)
        { }
    }
}
