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

namespace Academy.Presentation.Pages.Admin
{
    /// <summary>
    /// Interaction logic for TasksList.xaml
    /// </summary>
    public partial class TasksList : UserControl
    {
        Frame MainFrame;
        public TasksList(Frame MainFrame)
        {
            InitializeComponent();
            this.MainFrame = MainFrame;

            //TaskRepository taskRepository = new TaskRepository();
            //TaskUseCase taskUseCase = new TaskUseCase();
            //taskUseCase.GetAllTasksFromModel(taskRepository);

            //if (taskUseCase.tasks.Count > 0)
            //{
            //    LVTasks.ItemsSource = taskUseCase.tasks.OrderBy(x => x.termin).ToList();
            //}
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVTasks.SelectedIndex != -1)
            {
                //TaskUseCase taskUseCase = new TaskUseCase();
                //taskUseCase.DeleteTask(LVTasks.SelectedItem as Domain.Entities.Task);

                MainFrame.Content = new TasksList(MainFrame);
            }
        }
    }
}
