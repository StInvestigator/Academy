
using Academy.DataBase;
using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        public AddTask()
        {
            InitializeComponent();

            foreach (var item in academyContext.Lessons)
            {
                CBLesson.Items.Add(item.Name);
            }

            foreach (var item in academyContext.Groups)
            {
                CBLogin.Items.Add(item.Name);
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DPdate.SelectedDate < DateTime.Now.Date) { DPdate.SelectedDate = null; DPdate.Text = ""; }
            if (DPdate.Text.Trim() == "")
            {
                DPdate.Text = string.Empty;
                DPdate.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                DPdate.BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        private void TBGroupStudent_Checked(object sender, RoutedEventArgs e)
        {
            CBLogin.Items.Clear();
            if (TBGroupStudent.IsChecked == true)
            {
                LGL.Content = "Student";
                var students = academyContext.Students.Include(x => x.Group);

                foreach (var item in students)
                {
                    CBLogin.Items.Add($"{item.Group.Name}: {item.Surname} {item.Name} ({item.Login})");
                }
            }
            else
            {
                LGL.Content = "Group Name";

                foreach (var item in academyContext.Groups)
                {
                    CBLogin.Items.Add(item.Name);
                }
            }
        }

        private void CBLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBLesson.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBWorkType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWorkType.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void TextBox_DescChanged(object sender, TextChangedEventArgs e)
        {
            if (TBDesc.Text.Trim() == "")
            {
                TBDesc.Text = string.Empty;
                TBDesc.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                TBDesc.BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        void addTask(string login)
        {
            var lesson = academyContext.Lessons.First(x => x.Name == CBLesson.Text);
            var student = academyContext.Students.First(x => x.Login == login);
            academyContext.Tasks.Add(new Domain.Entities.Task
            {
                Description = TBDesc.Text,
                WorkType = CBWorkType.Text,
                Lesson = lesson,
                Student = student,
                Date = DPdate.SelectedDate ?? DateTime.Now
            });
            academyContext.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (TBDesc.Text != "" && CBLesson.Text != "" && CBLogin.Text != "" && CBWorkType.Text != "" && DPdate.Text != "")
            {
                try
                {
                    if (TBGroupStudent.IsChecked == true)
                    {
                        var login = CBLogin.Text.Split("(")[1].Remove(CBLogin.Text.Split("(")[1].Length - 1);

                        addTask(login);
                    }
                    else
                    {
                        var students = academyContext.Students.Where(x => x.Group.Name == CBLogin.Text).ToList();

                        foreach (var item in students)
                        {
                            addTask(item.Login);
                        }
                    }
                    MessageBox.Show("Success!", "Task was added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Wrong data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CBLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (CBLogin.Text.Length != 0)
                {
                    string text = CBLogin.Text.Remove(CBLogin.Text.Length - 1).ToLower();
                    CBLogin.Items.Clear();
                    if (TBGroupStudent.IsChecked == true)
                    {
                        var students = academyContext.Students.Include(x => x.Group);

                        foreach (var item in students)
                        {
                            if ($"{item.Group.Name}: {item.Surname} {item.Name}  ({item.Login})".ToLower().Contains(text))
                            {
                                CBLogin.Items.Add($"{item.Group.Name}: {item.Surname} {item.Name}  ({item.Login})");
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in academyContext.Groups)
                        {
                            if (item.Name.ToLower().Contains(text))
                            {
                                CBLogin.Items.Add(item.Name);
                            }
                        }
                    }
                    CBLogin.IsDropDownOpen = true;
                    CBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void ComboBox_LoginChanged(object sender, SelectionChangedEventArgs e)
        {
            CBLogin.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string text = (CBLogin.Text + e.Text).ToLower();
            CBLogin.Items.Clear();

            if (TBGroupStudent.IsChecked == true)
            {
                var students = academyContext.Students.Include(x => x.Group);
                foreach (var item in students)
                {
                    if ($"{item.Group.Name}: {item.Surname} {item.Name}  ({item.Login})".ToLower().Contains(text))
                    {
                        CBLogin.Items.Add($"{item.Group.Name}: {item.Surname} {item.Name}  ({item.Login})");
                    }
                }
            }

            else
            {
                foreach (var item in academyContext.Groups)
                {
                    if (item.Name.ToLower().Contains(text))
                    {
                        CBLogin.Items.Add(item.Name);
                    }
                }
            }
            CBLogin.IsDropDownOpen = true;
            CBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
        }
    }
}
