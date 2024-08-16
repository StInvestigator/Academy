using Academy.Presentation.Pages.Admin.CRUD_Student;
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

namespace Academy.Presentation.Pages.Admin.CRUD_Teacher
{
    /// <summary>
    /// Interaction logic for TeachersList.xaml
    /// </summary>
    public partial class TeachersList : UserControl
    {
        Frame MainFrame;
        public TeachersList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            //TeacherUseCase teacherUseCase = new TeacherUseCase();
            //TeacherRepository teacherRepository = new TeacherRepository();
            //teacherUseCase.GetAllTeachersFromModel(teacherRepository);
            //LVTeachers.ItemsSource = teacherUseCase.teachers.OrderBy(x => x.Age).ToList();
        }
        private void BAddClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EditTeacher(MainFrame);
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            if (LVTeachers.SelectedIndex != -1)
            {
                MainFrame.Content = new EditTeacher(MainFrame, LVTeachers.SelectedItem as Domain.Entities.Teacher);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVTeachers.SelectedIndex != -1)
            {
                //TeacherUseCase teacherUseCase = new TeacherUseCase();
                //teacherUseCase.DeleteTeacher((LVTeachers.SelectedItem as Domain.Entities.Teacher).Login);
                MainFrame.Content = new TeachersList(MainFrame);
            }
        }
    }
}
