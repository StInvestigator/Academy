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
using Academy.Data.Repositories;
using Academy.Domain.UseCases;

namespace Academy.Presentation.Pages.Student
{
    /// <summary>
    /// Interaction logic for MainInfo.xaml
    /// </summary>
    public partial class MainInfo : UserControl
    {
        Domain.Entities.Student student;
        public MainInfo(Domain.Entities.Student student)
        {
            this.student = student;
            student.grades.Add(new Grade(new DateTime(2020, 12, 30), "HT", 10));
            student.grades.Add(new Grade(new DateTime(2021, 01, 1), "HT", 10));
            student.grades.Add(new Grade(new DateTime(2021, 01, 2), "LB", 11));
            student.grades.Add(new Grade(new DateTime(2021, 01, 3), "CT", 11));
            student.grades.Add(new Grade(new DateTime(2021, 01, 4), "EX", 12));
            student.grades.Add(new Grade(new DateTime(2021, 01, 1), "CT", 9));
            InitializeComponent();
            LVGrades.ItemsSource = student.grades.OrderByDescending(x => x.Date).ToList().GetRange(0, student.grades.Count > 4 ? 4 : student.grades.Count);
            ScheduleRepository scheduleRepository = new ScheduleRepository();
            ScheduleUseCase scheduleUseCase = new ScheduleUseCase();
            scheduleUseCase.GetAllSchedulesFromModel(scheduleRepository);
            scheduleUseCase.schedules = scheduleUseCase.schedules.FindAll(x => x.GroupName == student.GroupName && x.DateOnly == DateOnly.FromDateTime(DateTime.Now.AddDays(1))).OrderBy(x => x.TimeOnly).ToList();
            LVSchedule.ItemsSource = scheduleUseCase.schedules;
        }
    }
}
