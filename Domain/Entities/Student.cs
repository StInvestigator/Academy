using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    class Student : User, IStudent
    {
        List<Grade> grades;

        public Student(string login,string password) 
        {
            Login = login;
            Password = password;
            grades = new List<Grade>();
        }
        public void PassTheExam(Grade grade)
        {
            grades.Add(grade);
        }

        public void PassTheWork(Grade grade)
        {
            grades.Add(grade);
        }

        public void ShowGrades()
        {
            throw new NotImplementedException();
        }

        public void ShowSchedule()
        {
            throw new NotImplementedException();
        }

        public void ShowTasks()
        {
            throw new NotImplementedException();
        }
    }
}
