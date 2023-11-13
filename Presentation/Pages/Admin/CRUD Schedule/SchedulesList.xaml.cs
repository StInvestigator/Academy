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

namespace Academy.Presentation.Pages.Admin.CRUD_Schedule
{
    /// <summary>
    /// Interaction logic for SchedulesList.xaml
    /// </summary>
    public partial class SchedulesList : UserControl
    {
        public SchedulesList()
        {
            InitializeComponent();

            ScheduleRepository scheduleRepository = new ScheduleRepository();
            ScheduleUseCase scheduleUseCase = new ScheduleUseCase();
            scheduleUseCase.GetAllSchedulesFromModel(scheduleRepository);
            if (scheduleUseCase.schedules.Count > 0)
            {
                scheduleUseCase.schedules = scheduleUseCase.schedules.OrderBy(x => x.TimeOnly).ToList().OrderBy(x => x.DateOnly).ToList();
                LVSchedule.ItemsSource = scheduleUseCase.schedules;
            }
        }
    }
}
