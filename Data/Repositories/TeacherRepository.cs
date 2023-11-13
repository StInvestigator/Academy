using Academy.Core.Interfases;
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
    public class TeacherRepository : ITeacherRepository
    {
        List<TeacherModel> _teachers;
        public TeacherRepository()
        {
            _teachers = new List<TeacherModel>();
            // HardCode data 
            _teachers.Add(new TeacherModel("Mark", "Peterson", 20, Core.Constants.Constants.TeacherLogin, Core.Constants.Constants.TeacherPassword));
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
