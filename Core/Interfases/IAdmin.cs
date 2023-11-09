using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interfases
{
    interface IAdmin
    {
        void AddTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);
        void EditTeacher(Teacher teacher);

        void AddStudent(Student student);
        void RemoveStudent(Student student);
        void EditStudent(Student student);
        
        void AddSubject(string subject);
        void RemoveSubject(string subject);
        void EditSubject(string subject);

        void CreateSchebule();
    }
}
