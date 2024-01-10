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
        public void AddLesson(string lesson)
        {
            AcademyDB.insertLesson(lesson);
        }
        public void UpdateLesson(string lesson,string oldName)
        {
            AcademyDB.updateLesson(lesson,oldName);
        }
        public void DeleteLesson(string lesson)
        {
            AcademyDB.deleteLesson(lesson);
        }
    }
}
