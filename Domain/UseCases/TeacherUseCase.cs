using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System.Collections.Generic;

namespace Academy.Domain.UseCases
{
    class TeacherUseCase
    {
        public List<Teacher> teachers;
        public TeacherUseCase()
        {
            teachers = new List<Teacher>();
        }
        public void GetAllTeachersFromModel(IRepository<Teacher> teacherRepository)
        {
            teachers = teacherRepository.GetAll();
        }
        public void AddTeacher(string name, string surname, int age, string login, string password)
        {
            AcademyDB.insertTeacher(name, surname, age, login, password);
        }
        public void UpdateTeacher(string name, string surname, int age, string login, string password, string selectedLogin)
        {
            AcademyDB.updateTeacher(name, surname, age, login, password, selectedLogin);
        }
        public void DeleteTeacher(string selectedLogin)
        {
            AcademyDB.deleteTeacher(selectedLogin);
        }
    }
}
