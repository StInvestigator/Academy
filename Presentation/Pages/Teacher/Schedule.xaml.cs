using Academy.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Controls;

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        public Schedule(Domain.Entities.Teacher teacher)
        {
            InitializeComponent();

            LVSchedule.ItemsSource = academyContext.Schedules
                .Include(x=>x.Teacher)
                .Include(x=>x.Group)
                .Include(x=>x.Lesson)
                .Where(x => x.Teacher.Login == teacher.Login && x.Date >= DateTime.Now)
                .OrderBy(x => x.Date).ToList();
        }
    }
}
