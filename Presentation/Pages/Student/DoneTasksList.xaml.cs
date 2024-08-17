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
    /// Interaction logic for TasksList.xaml
    /// </summary>
    public partial class DoneTasksList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Domain.Entities.Student student;
        Frame MainFrame;
        public DoneTasksList(Domain.Entities.Student student, Frame MainFrame)
        {
            this.student = student;
            InitializeComponent();
            this.MainFrame = MainFrame;

            LVTasks.ItemsSource = academyContext.Tasks
                .Where(x => x.Student.Id == student.Id && x.isDone == true)
                .Include(x => x.Lesson)
                .OrderBy(x => x.Date).ToList();
        }

        private void BDoneClick(object sender, RoutedEventArgs e)
        {
            if (LVTasks.SelectedIndex != -1)
            {
                academyContext.Tasks.First(x => x.Id == (LVTasks.SelectedItem as Domain.Entities.Task).Id).isDone = false;
                academyContext.SaveChanges();
                MainFrame.Content = new DoneTasksList(student, MainFrame);
            }

        }

        private void BSwapClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TasksList(student, MainFrame);
        }
    }
}
