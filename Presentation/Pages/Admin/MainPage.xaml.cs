using Academy.Domain.Entities;
using Academy.Domain.Navigation;
using Academy.Presentation.Pages.Admin.CRUD_Schedule;
using Academy.Presentation.Pages.Admin.CRUD_Student;
using Academy.Presentation.Pages.Admin.CRUD_Teacher;
using Academy.Presentation.Pages.Student;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            MainFrame.Content = new StarterPage();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Authorization());
        }

        private void BStudentClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(StudentsList))
            {
                MainFrame.Content = new StudentsList(MainFrame);
            }
        }

        private void BTeachersClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(TeachersList))
            {
                MainFrame.Content = new TeachersList(MainFrame);
            }
        }

        private void BScheduleClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(SchedulesList))
            {
                MainFrame.Content = new SchedulesList();
            }
        }
    }
}
