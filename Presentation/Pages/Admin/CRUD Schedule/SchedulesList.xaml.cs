using Academy.DataBase;
using Academy.Domain.Entities;
using Academy.Presentation.Pages.Student;
using Microsoft.EntityFrameworkCore;
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
        AcademyContext academyContext = new AcademyContext();
        Frame MainFrame;
        public SchedulesList(Frame MainFrame)
        {
            InitializeComponent();

            LVSchedule.ItemsSource = academyContext.Schedules
                .Include(x=>x.Lesson)
                .Include(x=>x.Group)
                .Include(x=>x.Teacher)
                .ToList();

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
                MainFrame.Content = new EditSchedule(MainFrame,LVSchedule.SelectedItem as Domain.Entities.Schedule);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVSchedule.SelectedIndex != -1)
            {
                academyContext.Schedules.Remove(LVSchedule.SelectedItem as Schedule);
                academyContext.SaveChanges();

                MainFrame.Content = new SchedulesList(MainFrame);
            }
        }
    }
}
