using Academy.Domain.Entities;
using Academy.Domain.Navigation;
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

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        Domain.Entities.Teacher teacher;
        public MainPage(Domain.Entities.Teacher teacher)
        {
            this.teacher = teacher;
            InitializeComponent();
            LTeacherName.Content = teacher.Name + " " + teacher.Surname;
                
            MainFrame.Content = new Schedule(teacher);
        }

        private void BHomeClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(Schedule))
            {
                MainFrame.Content = new Schedule(teacher);
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Authorization());
        }
    }
}
