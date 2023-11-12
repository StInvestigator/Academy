using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.UseCases
{
    class TeacherUseCase
    {
        public List<Teacher> teachers;
        public TeacherUseCase()
        {
            teachers = new List<Teacher>();
        }
        public void GetAllTeachersFromModel(ITeacherRepository teacherRepository)
        {
            teachers = teacherRepository.GetAll();
        }
    }
}
