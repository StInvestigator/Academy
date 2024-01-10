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
    public partial class DoneTasksList : UserControl
    {
        Domain.Entities.Student student;
        Frame MainFrame;
        public DoneTasksList(Domain.Entities.Student student, Frame MainFrame)
        {
            this.student = student;
            InitializeComponent();
            this.MainFrame = MainFrame;

            TaskRepository taskRepository = new TaskRepository();
            TaskUseCase taskUseCase = new TaskUseCase();
            taskUseCase.GetAllTasksFromModel(taskRepository);

            if (taskUseCase.tasks.Count > 0)
            {
                taskUseCase.tasks = taskUseCase.tasks.FindAll(x => x.StudentLogin == student.Login && x.isDone == true)
                    .OrderByDescending(x => x.termin).ToList();
                LVTasks.ItemsSource = taskUseCase.tasks;
            }
        }

        private void BDoneClick(object sender, RoutedEventArgs e)
        {
            if (LVTasks.SelectedIndex != -1)
            {
                TaskUseCase taskUseCase = new TaskUseCase();
                taskUseCase.MarkAsUndone(LVTasks.SelectedItem as Domain.Entities.Task);
                MainFrame.Content = new DoneTasksList(student, MainFrame);
            }

        }

        private void BSwapClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TasksList(student, MainFrame);
        }
    }
}
