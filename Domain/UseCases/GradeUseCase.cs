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
    }
}
