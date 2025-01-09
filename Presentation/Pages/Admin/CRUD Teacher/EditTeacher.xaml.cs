using Academy.DataBase;
using Academy.Domain.Entities;
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
    /// Interaction logic for EditTeacher.xaml
    /// </summary>
    public partial class EditTeacher : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Domain.Entities.Teacher? teacher;
        Frame frame;
        public EditTeacher(Frame MainFrame, Domain.Entities.Teacher? teacher = null)
        {
            InitializeComponent();

            frame = MainFrame;

            for (int i = 10; i < 100; i++)
            {
                CBAge.Items.Add(i.ToString());
            }

            this.teacher = teacher;

            if (teacher != null)
            {
                TBName.Text = teacher.Name;
                TBSurname.Text = teacher.Surname;
                TBLogin.Text = teacher.Login;
                TBPassword.Text = teacher.Password;
                CBAge.Text = teacher.Age.ToString();

                CBAge.BorderBrush = new SolidColorBrush(Colors.White);

            }
        }
        void Validation(TextBox TB)
        {
            if (TB.Text.Trim() == "")
            {
                TB.Text = string.Empty;
                TB.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                TB.BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBox_NameChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBName);
        }

        private void TextBox_SurnameChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBSurname);
        }

        private void TextBox_LoginChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBLogin);
        }

        private void CBAge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBAge.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void TBPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBPassword);
        }

        private bool isLoginExists(int id = -1)
        {
            if (academyContext.Students.FirstOrDefault(x => x.Login == TBLogin.Text) != null ||
                    academyContext.Teachers.FirstOrDefault(x => x.Login == TBLogin.Text && x.Id != id) != null)
            {
                TBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBLogin, "This login is already exists");
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBName.Text == "" || TBSurname.Text == "" || TBLogin.Text == "" || TBPassword.Text == "" || CBAge.Text == "")
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (teacher == null)
                {
                    if (isLoginExists()) return;

                    academyContext.Teachers.Add(new Domain.Entities.Teacher
                    {
                        Name = TBName.Text,
                        Surname = TBSurname.Text,
                        Age = Convert.ToInt32(CBAge.Text),
                        Login = TBLogin.Text,
                        Password = TBPassword.Text
                    });
                }
                else
                {
                    if (isLoginExists(teacher.Id)) return;

                    teacher.Name = TBName.Text;
                    teacher.Surname = TBSurname.Text;
                    teacher.Age = Convert.ToInt32(CBAge.Text);
                    teacher.Login = TBLogin.Text;
                    teacher.Password = TBPassword.Text;

                    academyContext.Teachers.Update(teacher);
                }
                academyContext.SaveChanges();
                frame.Content = new TeachersList(frame);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CBAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(CBAge.Text + e.Text);
                if (num > 100) throw new Exception();
            }
            catch
            {
                Keyboard.ClearFocus();
                e.Text.Remove(e.Text.Length - 1);
                CBAge.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
