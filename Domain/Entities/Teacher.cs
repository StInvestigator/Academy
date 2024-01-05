
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Teacher : Human
    {
        public Teacher(string login, string password, string name, string surname, int age) : base(name, surname, age, login, password)
        { }
        public void markTheStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void setGrade(Student student, Grade grade)
        {
            throw new NotImplementedException();
        }
    }
}
