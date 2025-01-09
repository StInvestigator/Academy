using Academy.DataBase;
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

namespace Academy.Presentation.Pages.Student
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class ScheduleList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        public ScheduleList(Domain.Entities.Student student)
        {
            InitializeComponent();

            LVSchedule.ItemsSource = academyContext.Schedules
                .Include(x=>x.Group)
                .Include(x => x.Lesson)
                .Include(x => x.Teacher)
                .Where(x => x.Group.Name == student.Group.Name && x.Date >= DateTime.Now)
                .ToList();
        }
    }
}
