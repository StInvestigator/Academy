using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Academy.Domain.Entities
{
    public class Student : Human, IStudent
    {
        public List<Grade> grades;
        string groupName;

        public Student(string login,string password) : base("First","Student",19,login,password)
        {
            grades = new List<Grade>();
            groupName = "Group1";
        }
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; } 
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
