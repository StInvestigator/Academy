using Academy.Core.Constants;
using Academy.Domain.Entities;
using Academy.Domain.Navigation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Academy.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        public Authorization()
        {
            InitializeComponent();
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
            string login = TBLogin.Text.Trim();
            string password = TBPassword.Password.Trim();
            if (login == Constants.AdminLogin && password == Constants.AdminPassword)
            {
                NavigatorObject.Switch(new Admin.MainPage());
                return;
            }

            //StudentUseCase studentUseCase = new StudentUseCase();
            //StudentRepository studentRepository = new StudentRepository();
            //studentUseCase.GetAllStudentsFromModel(studentRepository);
            //if (studentUseCase.students.Contains(studentUseCase.students.Find(x => x.Login == login && x.Password == password)))
            //{
            //    NavigatorObject.Switch(new Student.MainPage(studentUseCase.students.Find(x => x.Login == login && x.Password == password)));
            //    return;
            //}

            //TeacherUseCase teacherUseCase = new TeacherUseCase();
            //TeacherRepository teacherRepository = new TeacherRepository();
            //teacherUseCase.GetAllTeachersFromModel(teacherRepository);

            //if (teacherUseCase.teachers.Contains(teacherUseCase.teachers.Find(x => x.Login == login && x.Password == password)))
            //{
            //    NavigatorObject.Switch(new Teacher.MainPage(teacherUseCase.teachers.Find(x => x.Login == login && x.Password == password)));
            //}
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
