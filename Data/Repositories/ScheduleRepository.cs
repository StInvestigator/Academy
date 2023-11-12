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
    public class ScheduleRepository : IScheduleRepository
    {
        List<ScheduleModel> _schedules;
        public ScheduleRepository()
        {
            _schedules = new List<ScheduleModel>();
            // HardCode data 
            _schedules.Add(new ScheduleModel(DateOnly.FromDateTime(DateTime.Now.AddDays(1)),new TimeOnly(15,0),"Mark","Peterson","B204","A3","Math"));
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
