using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interfases
{
    interface ITeacher
    {
        void markTheStudent(Student student);

        void setGrade(Student student, Grade grade);
    }
}
