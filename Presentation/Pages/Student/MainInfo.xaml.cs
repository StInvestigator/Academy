using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Academy.Domain.Entities;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Academy.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Academy.Presentation.Pages.Student
{
    /// <summary>
    /// Interaction logic for MainInfo.xaml
    /// </summary>
    public partial class MainInfo : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        public MainInfo(Domain.Entities.Student student)
        {
            InitializeComponent();

            var grades = academyContext.Grades
                .Include(x => x.Lesson)
                .Include(x => x.Student)
                .Where(x => x.Student.Login == student.Login)
                .OrderByDescending(x => x.Date).ToList();

            LVGrades.ItemsSource = grades.GetRange(0, grades.Count > 4 ? 4 : grades.Count);

            var schedules = academyContext.Schedules
                .Include(x => x.Lesson)
                .Include(x => x.Group)
                .Where(x => x.Group.Name == student.Group.Name && x.Date.Date == DateTime.Now.AddDays(1).Date)
                .OrderBy(x => x.Date).ToList();

            LVSchedule.ItemsSource = schedules.GetRange(0, schedules.Count > 4 ? 4 : schedules.Count);

            var tasks = academyContext.Tasks
                .Include(x => x.Lesson)
                .Include(x => x.Student)
                .Where(x => x.Student.Login == student.Login && x.isDone == false)
                .OrderBy(x => x.Date).ToList();

            LVTasks.ItemsSource = tasks.GetRange(0, tasks.Count > 4 ? 4 : tasks.Count);
        }
    }
}
