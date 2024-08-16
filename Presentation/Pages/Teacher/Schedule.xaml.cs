using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : UserControl
    {
        Domain.Entities.Teacher teacher;
        public Schedule(Domain.Entities.Teacher teacher)
        {
            this.teacher = teacher;
            InitializeComponent();

            //ScheduleRepository scheduleRepository = new ScheduleRepository();
            //ScheduleUseCase scheduleUseCase = new ScheduleUseCase();
            //scheduleUseCase.GetAllSchedulesFromModel(scheduleRepository);
            //if (scheduleUseCase.schedules.Count > 0)
            //{
            //    scheduleUseCase.schedules = scheduleUseCase.schedules.FindAll(x => x.TeacherName+x.TeacherSurname == teacher.Name+teacher.Surname && x.Date >= DateTime.Now)
            //        .OrderBy(x => x.Date).ToList();
            //    LVSchedule.ItemsSource = scheduleUseCase.schedules;
            //}
        }
    }
}
