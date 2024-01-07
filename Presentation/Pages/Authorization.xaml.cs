using Academy.Core.Constants;
using Academy.Data.Repositories;
using Academy.Domain.Entities;
using Academy.Domain.Navigation;
using Academy.Domain.UseCases;
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

namespace Academy.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        User user;
        public Authorization()
        {
            InitializeComponent();
            user = new User();
        }

        private void TextBox_LoginChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBLogin);
        }

        void Validation(TextBox TB)
        {
            if (TB.Text.Length == 0 || TB.Text.Trim() == "")
            {
                TB.Text = string.Empty;
                TB.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TB, "Field is required");
            }
            else
            {
                TB.BorderBrush = new SolidColorBrush(Colors.White);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TB, "");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Login = TBLogin.Text.Trim();
            user.Password = TBPassword.Password.Trim();
            if (user.Login == Constants.AdminLogin && user.Password == Constants.AdminPassword)
            {
                NavigatorObject.Switch(new Admin.MainPage());
                return;
            }

            StudentUseCase studentUseCase = new StudentUseCase();
            StudentRepository studentRepository = new StudentRepository();
            studentUseCase.GetAllStudentsFromModel(studentRepository);
            if (studentUseCase.students.Contains(studentUseCase.students.Find(x => x.Login == user.Login && x.Password == user.Password)))
            {
                NavigatorObject.Switch(new Student.MainPage(studentUseCase.students.Find(x => x.Login == user.Login && x.Password == user.Password)));
                return;
            }

            TeacherUseCase teacherUseCase = new TeacherUseCase();
            TeacherRepository teacherRepository = new TeacherRepository();
            teacherUseCase.GetAllTeachersFromModel(teacherRepository);

            if (teacherUseCase.teachers.Contains(teacherUseCase.teachers.Find(x => x.Login == user.Login && x.Password == user.Password)))
            {
                NavigatorObject.Switch(new Teacher.MainPage(teacherUseCase.teachers.Find(x => x.Login == user.Login && x.Password == user.Password)));
            }
        }

        private void TextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Password.Length == 0 || TBPassword.Password.Trim() == "")
            {
                TBPassword.Password = string.Empty;
                TBPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBPassword, "Field is required");
            }
            else
            {
                TBPassword.BorderBrush = new SolidColorBrush(Colors.White);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBPassword, "");
            }
        }
    }
}
