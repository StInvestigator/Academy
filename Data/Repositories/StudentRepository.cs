using Academy.Data.Models;
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
            // HardCode data 
            _students.Add(new StudentModel("B204", "Vladislav", "Murashko", 16, Core.Constants.Constants.StudentLogin, Core.Constants.Constants.StudentPassword));
        }
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            foreach (var item in _students)
            {
                students.Add(new Student(
                    item.login ?? "login1",
                    item.password ?? "password1",
                    item.name ?? "StudentName",
                    item.surname ?? "StudentSurname",
                    item.age ?? 18,
                    item.groupName ?? "Group1"
                    ));
            }
            return students;
        }
    }
}
