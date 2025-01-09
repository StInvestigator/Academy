using Academy.DataBase;
using Academy.Domain.Entities;
using Academy.Presentation.Pages.Teacher;
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

namespace Academy.Presentation.Pages.Admin.CRUD_Student
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Frame MainFrame;
        public StudentsList(Frame MainFrame)
        {
            this.MainFrame = MainFrame;
            InitializeComponent();

            LVStudents.ItemsSource = academyContext.Students
                .Include(x => x.Group)
                .OrderBy(x => x.Surname)
                .OrderBy(x => x.Group.Name).ToList();
        }

        private void BAddClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EditStudent(MainFrame);
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            if(LVStudents.SelectedIndex != -1) 
            {
                MainFrame.Content = new EditStudent(MainFrame,LVStudents.SelectedItem as Domain.Entities.Student);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVStudents.SelectedIndex != -1)
            {
                academyContext.Students.Remove(LVStudents.SelectedItem as Domain.Entities.Student);
                academyContext.SaveChanges();

                MainFrame.Content = new StudentsList(MainFrame);
            }
        }
    }
}
