using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.UseCases
{
    class ScheduleUseCase
    {
        public List<Schedule> schedules;
        public ScheduleUseCase()
        {
            schedules = new List<Schedule>();
        }
        public void GetAllSchedulesFromModel(IScheduleRepository scheduleRepository)
        {
            schedules = scheduleRepository.GetAll();
        }
    }
}
