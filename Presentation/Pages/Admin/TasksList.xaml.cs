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

namespace Academy.Presentation.Pages.Admin
{
    /// <summary>
    /// Interaction logic for TasksList.xaml
    /// </summary>
    public partial class TasksList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Frame MainFrame;
        public TasksList(Frame MainFrame)
        {
            InitializeComponent();
            this.MainFrame = MainFrame;

            LVTasks.ItemsSource = academyContext.Tasks
                .Include(x=>x.Student)
                .Include(x=>x.Lesson)
                .OrderBy(x => x.Date).ToList();
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVTasks.SelectedIndex != -1)
            {
                academyContext.Tasks.Remove(LVTasks.SelectedItem as Domain.Entities.Task);
                academyContext.SaveChanges();

                MainFrame.Content = new TasksList(MainFrame);
            }
        }
    }
}
