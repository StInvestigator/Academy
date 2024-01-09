using Academy.Data.Repositories;
using Academy.Domain.UseCases;
using Academy.Presentation.Pages.Student;
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
        Frame MainFrame;
        public SchedulesList(Frame MainFrame)
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
            this.MainFrame = MainFrame;
        }

        private void BAddClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EditSchedule(MainFrame);
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            if (LVSchedule.SelectedIndex != -1)
            {
                MainFrame.Content = new EditSchedule(MainFrame,LVSchedule.SelectedItem as Domain.Entities.Schedule, LVSchedule.SelectedIndex);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVSchedule.SelectedIndex != -1)
            {
                ScheduleUseCase scheduleUseCase = new ScheduleUseCase();
                scheduleUseCase.DeleteSchedule(LVSchedule.SelectedIndex);
                MainFrame.Content = new SchedulesList(MainFrame);
            }
        }
    }
}
