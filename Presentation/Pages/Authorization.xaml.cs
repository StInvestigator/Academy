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
            user.Login = TBLogin.Text.Trim();
            if (user.Login.Length == 0)
            {
                TBLogin.Text = string.Empty;
                TBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBLogin, "Field is required");
            }
            else
            {
                TBLogin.BorderBrush = new SolidColorBrush(Colors.White);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBLogin, "");
            }
        }

        private void TextBox_PasswordChanged(object sender, TextChangedEventArgs e)
        {
            user.Password = TBPassword.Text.Trim();
            if (user.Password.Length == 0)
            {
                TBPassword.Text = string.Empty;
                TBPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBPassword, "Field is required");
            }
            else
            {
                TBPassword.BorderBrush = new SolidColorBrush(Colors.White);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBPassword, "");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
