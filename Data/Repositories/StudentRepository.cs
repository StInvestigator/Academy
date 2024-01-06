using Academy.Data.Models;
using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        List<StudentModel> _students;
        public StudentRepository()
        {
            _students = new List<StudentModel>();

            foreach (var student in AcademyDB.GetStudents())
            {
                _students.Add(student);
            }
        }
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            foreach (var item in _students)
            {
                students.Add(new Student(
                    item.Login ?? "login1",
                    item.Password ?? "password1",
                    item.Name ?? "StudentName",
                    item.Surname ?? "StudentSurname",
                    item.Age ?? 18,
                    item.GroupName ?? "Group1"
                    ));
            }
            return students;
        }
    }
}
