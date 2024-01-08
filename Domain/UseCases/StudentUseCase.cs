using Academy.Data.Repositories.DataBase;
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
        public void GetAllStudentsFromModel(IStudentRepository studentRepository)
        {
            students = studentRepository.GetAll();
        }
        public void AddStudent(string name, string surname, int age, string login, string password, string groupName)
        {
            AcademyDB.insertStudent(name,surname,age,login,password,groupName);
        }
        public void UpdateStudent(string name, string surname, int age, string login, string password, string groupName, string selectedLogin)
        {
            AcademyDB.updateStudent(name, surname, age, login, password, groupName, selectedLogin);
        }
        public void DeleteStudent(string selectedLogin)
        {
            AcademyDB.deleteStudent(selectedLogin);
        }
    }
}
