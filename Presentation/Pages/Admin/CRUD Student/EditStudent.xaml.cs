using Academy.Data.Repositories;
using Academy.Domain.Entities;
using Academy.Domain.UseCases;
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
        Domain.Entities.Student? student;
        Frame frame;
        GroupUseCase groupUseCase;
        public EditStudent(Frame MainFrame, Domain.Entities.Student? student = null)
        {
            InitializeComponent();

            frame = MainFrame;

            for (int i = 10; i < 100; i++)
            {
                CBAge.Items.Add(i.ToString());
            }

            GroupRepository groupRepository = new GroupRepository();
            groupUseCase = new GroupUseCase();
            groupUseCase.GetAllGroupsFromModel(groupRepository);

            foreach (var item in groupUseCase.groups)
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
                CBGroup.Text = student.GroupName;
            }
        }
        void Validation(TextBox TB)
        {
            if (TB.Text.Length == 0 || TB.Text.Trim() == "")
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBName.Text!="" && TBSurname.Text != "" && TBLogin.Text != "" && TBPassword.Text != "" && CBAge.Text != "" && CBGroup.Text != "")
            {
                try
                {
                    StudentUseCase studentUseCase = new StudentUseCase();
                    if (student == null)
                    {
                        studentUseCase.AddStudent(TBName.Text, TBSurname.Text,Convert.ToInt32(CBAge.Text), TBLogin.Text, TBPassword.Text, CBGroup.Text);
                    }
                    else
                    {
                        studentUseCase.UpdateStudent(TBName.Text, TBSurname.Text, Convert.ToInt32(CBAge.Text), TBLogin.Text, TBPassword.Text, CBGroup.Text,student.Login);
                    }
                    frame.Content = new StudentsList(frame);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CBGroup_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string text = (CBGroup.Text + e.Text).ToLower();
            CBGroup.Items.Clear();
            foreach (var item in groupUseCase.groups)
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
                    foreach (var item in groupUseCase.groups)
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
