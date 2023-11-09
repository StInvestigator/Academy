using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    class Teacher : User, ITeacher
    {
        public Teacher(string login, string password) 
        {
            Login = login;
            Password = password;
        }
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
