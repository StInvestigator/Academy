using Academy.Data.Models;
using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Academy.Data.Repositories
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        List<ScheduleModel> _schedules;
        public ScheduleRepository()
        {
            _schedules = new List<ScheduleModel>();

            foreach (var item in AcademyDB.GetSchedules())
            {
                _schedules.Add(item);
            }
        }
        public List<Schedule> GetAll()
        {
            List<Schedule> schedules = new List<Schedule>();
            foreach (var item in _schedules)
            {
                schedules.Add(new Schedule(
                    item.dateOnly ?? DateOnly.FromDateTime(DateTime.Now),
                    item.timeOnly ?? TimeOnly.FromDateTime(DateTime.Now),
                    item.TeacherName ?? "TeacherName",
                    item.TeacherSurname ?? "TeacherSurname",
                    item.GroupName ?? "Group1",
                    item.Class ?? "A001",
                    item.Lesson ?? "Math"
                    ));
            }
            return schedules;
        }
    }
}
