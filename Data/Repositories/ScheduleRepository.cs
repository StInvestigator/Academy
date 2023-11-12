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
    class ScheduleRepository : IScheduleRepository
    {
        List<ScheduleModel> _schedules;
        public ScheduleRepository()
        {
            _schedules = new List<ScheduleModel>();
        }
        public List<Schedule> GetAll()
        {
            List<Schedule> schedules = new List<Schedule>();
            foreach (var item in _schedules)
            {
                schedules.Add(new Schedule(
                    item.DateOnly ?? DateOnly.FromDateTime(DateTime.Now),
                    item.TimeOnly ?? TimeOnly.FromDateTime(DateTime.Now),
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
