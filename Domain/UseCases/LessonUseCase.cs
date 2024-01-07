using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.UseCases
{
    public class LessonUseCase
    {
        public List<Lesson> lessons;
        public LessonUseCase()
        {
            lessons = new List<Lesson>();
        }
        public void GetAllLessonsFromModel(ILessonRepository lessonRepository)
        {
            lessons = lessonRepository.GetAll();
        }
    }
}
