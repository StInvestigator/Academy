using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Academy.Domain.Entities
{
    public class Student : Human, IStudent
    {
        string groupName;

        public Student(string login,string password, string name, string surname, int age, string groupName) : base(name,surname,age,login,password)
        {
            this.groupName = groupName;
        }
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; NotifyPropertyChanged("GroupName"); } 
        }


        public void PassTheWork()
        {
            throw new NotImplementedException();
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
