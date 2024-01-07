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
    /// Interaction logic for TasksList.xaml
    /// </summary>
    public partial class TasksList : UserControl
    {
        Domain.Entities.Student student;
        public TasksList(Domain.Entities.Student student)
        {
            this.student = student;
            InitializeComponent();

            TaskRepository taskRepository = new TaskRepository();
            TaskUseCase taskUseCase = new TaskUseCase();
            taskUseCase.GetAllTasksFromModel(taskRepository);
            if (taskUseCase.tasks.Count > 0)
            {
                taskUseCase.tasks = taskUseCase.tasks.FindAll(x => x.StudentLogin == student.Login)
                    .OrderBy(x => x.termin).ToList();
                LVTasks.ItemsSource = taskUseCase.tasks;
            }
        }
    }
}
