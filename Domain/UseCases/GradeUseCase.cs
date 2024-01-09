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
    public class GradeUseCase
    {
        public List<Grade> grades;
        public GradeUseCase() 
        {
            grades = new List<Grade>();
        }
        public void GetAllGradesFromModel(IGradeRepository gradeRepository)
        {
            grades = gradeRepository.GetAll();
        }
        public void AddGrade(DateTime date, string workType, int grade, string lesson, string studentLogin)
        {
            AcademyDB.insertGrade(date, workType, grade, lesson, studentLogin);
        }
        public void DeleteGrade(Grade grade)
        {
            AcademyDB.deleteGrade(grade);
        }
    }
}
