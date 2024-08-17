using Academy.DataBase;
using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Schema;

namespace Academy.Presentation.Pages.Admin.CRUD_Student
{
    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Domain.Entities.Student? student;
        Frame frame;
        public EditStudent(Frame MainFrame, Domain.Entities.Student? student = null)
        {
            InitializeComponent();

            frame = MainFrame;

            for (int i = 10; i < 100; i++)
            {
                CBAge.Items.Add(i.ToString());
            }

            foreach (var item in academyContext.Groups)
            {
                CBGroup.Items.Add(item.Name);
            }

            this.student = student;

            if (student != null)
            {
                TBName.Text = student.Name;
                TBSurname.Text = student.Surname;
                TBLogin.Text = student.Login;
                TBPassword.Text = student.Password;
                CBAge.Text = student.Age.ToString();
                CBGroup.Text = student.Group.Name;

                CBAge.BorderBrush = new SolidColorBrush(Colors.White);
                CBGroup.BorderBrush = new SolidColorBrush(Colors.White);
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

        private void CBGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBGroup.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void TBPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBPassword);
        }

        private bool isLoginExists(int id = -1)
        {
            if (academyContext.Teachers.FirstOrDefault(x => x.Login == TBLogin.Text) != null ||
                    academyContext.Students.FirstOrDefault(x => x.Login == TBLogin.Text && x.Id != id) != null)
            {
                TBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBLogin, "This login is already exists");
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBName.Text == "" || TBSurname.Text == "" || TBLogin.Text == "" || TBPassword.Text == "" || CBAge.Text == "" || CBGroup.Text == "")
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {

                if (student == null)
                {
                    if (isLoginExists()) return;

                    academyContext.Students.Add(new Domain.Entities.Student
                    {
                        Name = TBName.Text,
                        Surname = TBSurname.Text,
                        Age = Convert.ToInt32(CBAge.Text),
                        Login = TBLogin.Text,
                        Password = TBPassword.Text,
                        Group = academyContext.Groups.First(x => x.Name == CBGroup.Text)
                    });
                }
                else
                {
                    if (isLoginExists(student.Id)) return;

                    student.Name = TBName.Text;
                    student.Surname = TBSurname.Text;
                    student.Age = Convert.ToInt32(CBAge.Text);
                    student.Login = TBLogin.Text;
                    student.Password = TBPassword.Text;
                    student.Group = academyContext.Groups.First(x => x.Name == CBGroup.Text);

                    academyContext.Students.Update(student);
                }
                academyContext.SaveChanges();
                frame.Content = new StudentsList(frame);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void CBGroup_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string text = (CBGroup.Text + e.Text).ToLower();
            CBGroup.Items.Clear();
            foreach (var item in academyContext.Groups)
            {
                if (item.Name.ToLower().Contains(text))
                {
                    CBGroup.Items.Add(item.Name);
                }
            }
            CBGroup.IsDropDownOpen = true;
            CBGroup.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void CBAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                CBAge.BorderBrush = new SolidColorBrush(Colors.Red);
                int num = Convert.ToInt32(CBAge.Text + e.Text);
                CBAge.BorderBrush = new SolidColorBrush(Colors.White);
                if (num > 100)
                {
                    CBAge.Text = "100";
                    throw new Exception();
                }
            }
            catch
            {
                Keyboard.ClearFocus();
            }
        }

        private void CBGroup_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (CBGroup.Text.Length != 0)
                {
                    string text = CBGroup.Text.Remove(CBGroup.Text.Length - 1).ToLower();
                    CBGroup.Items.Clear();
                    foreach (var item in academyContext.Groups)
                    {
                        if (item.Name.ToLower().Contains(text))
                        {
                            CBGroup.Items.Add(item.Name);
                        }
                    }
                    CBGroup.IsDropDownOpen = true;
                    CBGroup.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}
