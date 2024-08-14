using Academy.Data.Repositories;
using Academy.Domain.UseCases;
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

namespace Academy.Presentation.Pages.Student
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class ScheduleList : UserControl
    {
        Domain.Entities.Student student;
        public ScheduleList(Domain.Entities.Student student)
        {
            this.student = student;
            InitializeComponent();

            ScheduleRepository scheduleRepository = new ScheduleRepository();
            ScheduleUseCase scheduleUseCase = new ScheduleUseCase();
            scheduleUseCase.GetAllSchedulesFromModel(scheduleRepository);
            if (scheduleUseCase.schedules.Count > 0)
            {
                scheduleUseCase.schedules = scheduleUseCase.schedules.FindAll(x => x.GroupName == student.GroupName && x.DateOnly >= DateOnly.FromDateTime(DateTime.Now));
                LVSchedule.ItemsSource = scheduleUseCase.schedules;
            }
        }
    }
}
