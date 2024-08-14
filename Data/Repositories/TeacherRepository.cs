
using Academy.Data.Models;
using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System.Collections.Generic;

namespace Academy.Data.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        List<TeacherModel> _teachers;
        public TeacherRepository()
        {
            _teachers = new List<TeacherModel>();

            foreach (var item in AcademyDB.GetTeachers())
            {
                _teachers.Add(item);
            }
        }
        public List<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();
            foreach (var item in _teachers)
            {
                teachers.Add(new Teacher(
                    item.login ?? "login1",
                    item.password ?? "password1",
                    item.name ?? "TeacherName",
                    item.surname ?? "TeacherSurname",
                    item.age ?? 20
                    ));
            }
            return teachers;
        }
    }
}
