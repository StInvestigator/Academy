using Academy.Data.Models;
using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System.Collections.Generic;

namespace Academy.Data.Repositories
{
    class LessonRepository : IRepository<Lesson>
    {
        List<LessonModel> _lessons;
        public LessonRepository()
        {
            _lessons = new List<LessonModel>();

            foreach (var item in AcademyDB.GetLessons())
            {
                _lessons.Add(item);
            }
        }
        public List<Lesson> GetAll()
        {
            List<Lesson> schedules = new List<Lesson>();
            foreach (var item in _lessons)
            {
                schedules.Add(new Lesson(
                    item.name ?? "#Lesson#"
                    ));
            }
            return schedules;
        }
    }
}
