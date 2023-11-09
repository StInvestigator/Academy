using Academy.Core.Interfases;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    class Admin : User, IAdmin
    {
        public Admin(string login,string password) 
        {
            Login = login;
            Password = password;
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void AddSubject(string subject)
        {
            throw new NotImplementedException();
        }

        public void AddTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void CreateSchebule()
        {
            throw new NotImplementedException();
        }

        public void EditStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void EditSubject(string subject)
        {
            throw new NotImplementedException();
        }

        public void EditTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubject(string subject)
        {
            throw new NotImplementedException();
        }

        public void RemoveTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
