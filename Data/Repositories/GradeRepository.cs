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
    public class GradeRepository : IGradeRepository
    {
        List<GradeModel> _grades;
        public GradeRepository()
        {
            _grades = new List<GradeModel>();

            foreach (var item in AcademyDB.GetGrades())
            {
                _grades.Add(item);
            }
        }
        public List<Grade> GetAll()
        {
            List<Grade> grades = new List<Grade>();
            foreach (var item in _grades)
            {
                grades.Add(new Grade(
                    item.date ?? DateOnly.FromDateTime(DateTime.Now),
                    item.workType ?? "HT",
                    item.gradeNumber ?? 1,
                    item.studentLogin ?? "Student",
                    item.lesson ?? "Math"
                    ));
            }
            return grades;
        }
    }
}
