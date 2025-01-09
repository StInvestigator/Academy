using Academy.Core.Constants;
using Academy.DataBase;
using Academy.Domain.Navigation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        AcademyContext academyContext = new AcademyContext();
        public Authorization()
        {
            InitializeComponent();
        }

        private void TextBox_LoginChanged(object sender, TextChangedEventArgs e)
        {
            if (TBLogin.Text.Trim() == "")
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text.Trim();
            string password = TBPassword.Password.Trim();
            if (login == Constants.AdminLogin && password == Constants.AdminPassword)
            {
                NavigatorObject.Switch(new Admin.MainPage());
                return;
            }

            var student = academyContext.Students
                .Include(x=>x.Group)
                .FirstOrDefault(x => x.Login == login && x.Password == password)
                ;
            if (student!=null)
            {
                NavigatorObject.Switch(new Student.MainPage(student));
                return;
            }

            var teacher = academyContext.Teachers.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (teacher != null)
            {
                NavigatorObject.Switch(new Teacher.MainPage(teacher));
                return;
            }

            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBPassword, "Wrong login or password");
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
