using Academy.Core.Interfases;
using Academy.Domain.Entities;
using Academy.Domain.Navigation;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        Domain.Entities.Student student;
        public MainPage(Domain.Entities.Student student)
        {
            this.student = student;
            InitializeComponent();
            MainFrame.Content = new MainInfo(student);
            LGroup.Content = student.GroupName;
            LStudentName.Content = student.Surname + " " + student.Name;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Authorization());
        }

        private void BHomeClick(object sender, RoutedEventArgs e)
        {
            if(MainFrame.Content.GetType() != typeof(MainInfo))
            {
                MainFrame.Content = new MainInfo(student);
            }
        }

        private void BGradesClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(GradesList))
            {
                MainFrame.Content = new GradesList(student);
            }
        }

        private void BTasksClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(TasksList))
            {
                MainFrame.Content = new TasksList(student);
            }
        }

        private void BScheduleClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(ScheduleList))
            {
                MainFrame.Content = new ScheduleList(student);
            }
        }
    }
}
