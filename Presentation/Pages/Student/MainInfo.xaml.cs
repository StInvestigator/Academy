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
            InitializeComponent();

            GradeRepository gradeRepository = new GradeRepository();
            GradeUseCase gradeUseCase = new GradeUseCase();
            gradeUseCase.GetAllGradesFromModel(gradeRepository);
            if (gradeUseCase.grades.Count > 0)
            {
                gradeUseCase.grades = gradeUseCase.grades.FindAll(x => x.StudentLogin == student.Login).OrderByDescending(x => x.Date).ToList();
                gradeUseCase.grades = gradeUseCase.grades.GetRange(0, gradeUseCase.grades.Count > 4 ? 4 : gradeUseCase.grades.Count);
                LVGrades.ItemsSource = gradeUseCase.grades;
            }

            ScheduleRepository scheduleRepository = new ScheduleRepository();
            ScheduleUseCase scheduleUseCase = new ScheduleUseCase();
            scheduleUseCase.GetAllSchedulesFromModel(scheduleRepository);
            if (scheduleUseCase.schedules.Count > 0)
            {
                scheduleUseCase.schedules = scheduleUseCase.schedules.FindAll(x => x.GroupName == student.GroupName && x.DateOnly == DateOnly.FromDateTime(DateTime.Now.AddDays(1)))
                        .OrderBy(x => x.TimeOnly).ToList();
                scheduleUseCase.schedules = scheduleUseCase.schedules.GetRange(0, scheduleUseCase.schedules.Count > 4 ? 4 : scheduleUseCase.schedules.Count);
                LVSchedule.ItemsSource = scheduleUseCase.schedules;
            }

            TaskRepository taskRepository = new TaskRepository();
            TaskUseCase taskUseCase = new TaskUseCase();
            taskUseCase.GetAllTasksFromModel(taskRepository);
            if(taskUseCase.tasks.Count > 0)
            {
                taskUseCase.tasks = taskUseCase.tasks.FindAll(x => x.StudentLogin == student.Login && x.isDone == false)
                    .OrderBy(x => x.termin).ToList();
                taskUseCase.tasks = taskUseCase.tasks.GetRange(0, taskUseCase.tasks.Count > 4 ? 4 : taskUseCase.tasks.Count);
                LVTasks.ItemsSource = taskUseCase.tasks;
            }
        }
    }
}
