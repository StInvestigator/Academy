using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.UseCases
{
    class StudentUseCase
    {
        public List<Student> students;
        public StudentUseCase()
        {
            students = new List<Student>();
        }
        public void GetAllGroupsFromModel(IStudentRepository studentRepository)
        {
            students = studentRepository.GetAll();
        }
    }
}
