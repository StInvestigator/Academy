using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interfases
{
    interface IStudent
    {
        void ShowSchedule();
        void ShowTasks();
        void PassTheWork(Grade grade);
        void ShowGrades();
    }
}
