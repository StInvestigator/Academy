using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Academy.Domain.UseCases
{
    class ScheduleUseCase
    {
        public List<Schedule> schedules;
        public ScheduleUseCase()
        {
            schedules = new List<Schedule>();
        }
        public void GetAllSchedulesFromModel(IRepository<Schedule> scheduleRepository)
        {
            schedules = scheduleRepository.GetAll();
        }
        public void AddSchedule(DateTime date, string @class, string teacherLogin, string groupName, string lesson)
        {
            AcademyDB.insertSchedule(date, @class, teacherLogin, groupName, lesson);
        }
        public void UpdateSchedule(DateTime date, string @class, string teacherLogin, string groupName, string lesson, int id)
        {
            AcademyDB.updateSchedule(date, @class, teacherLogin, groupName, lesson, AcademyDB.GetShceduleIdByNum(id));
        }
        public void DeleteSchedule(int id)
        {
            AcademyDB.deleteSchedule(AcademyDB.GetShceduleIdByNum(id));
        }
    }
}
