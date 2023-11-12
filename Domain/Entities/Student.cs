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

        public Student(string login,string password, string name, string surname, int age, string groupName) : base(name,surname,age,login,password)
        {
            grades = new List<Grade>();
            this.groupName = groupName;
        }
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; } 
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
