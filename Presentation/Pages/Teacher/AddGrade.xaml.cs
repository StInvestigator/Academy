using Academy.DataBase;
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
    /// Interaction logic for AddGrade.xaml
    /// </summary>
    public partial class AddGrade : UserControl
    {

        AcademyContext academyContext = new AcademyContext();
        public AddGrade()
        {
            InitializeComponent();

            var students = academyContext.Students.Include(x => x.Group);

            foreach (var item in students)
            {
                CBLogin.Items.Add($"{item.Group.Name}: {item.Surname} {item.Name} ({item.Login})");
            }

            foreach (var item in academyContext.Lessons)
            {
                CBLesson.Items.Add(item.Name);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CBGrade.Text != "" && CBLesson.Text != "" && CBLogin.Text != "" && CBWorkType.Text != "")
            {
                try
                {
                    var login = CBLogin.Text.Split("(")[1].Remove(CBLogin.Text.Split("(")[1].Length - 1);

                    var lesson = academyContext.Lessons.First(x => x.Name == CBLesson.Text);
                    var student = academyContext.Students.First(x => x.Login == login);
                    academyContext.Grades.Add(new Domain.Entities.Grade{
                        Date = DateTime.Now, 
                        WorkType = CBWorkType.Text, 
                        GradeNumber = Convert.ToInt32(CBGrade.Text),
                        Lesson = lesson,
                        Student = student
                    });
                    academyContext.SaveChanges();

                    MessageBox.Show("Success!", "Evaluation done", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void CBWorkType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWorkType.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBGrade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBGrade.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBLesson.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBLogin.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string text = (CBLogin.Text + e.Text).ToLower();
            CBLogin.Items.Clear();
            var students = academyContext.Students.Include(x => x.Group);

            foreach (var item in students)
            {
                if ($"{item.Group.Name}: {item.Surname} {item.Name} ({item.Login})".ToLower().Contains(text))
                {
                    CBLogin.Items.Add($"{item.Group.Name}: {item.Surname} {item.Name} ({item.Login})");
                }
            }
            CBLogin.IsDropDownOpen = true;
            CBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void CBLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (CBLogin.Text.Length != 0)
                {
                    string text = CBLogin.Text.Remove(CBLogin.Text.Length - 1).ToLower();
                    CBLogin.Items.Clear();
                    var students = academyContext.Students.Include(x => x.Group);
                    foreach (var item in students)
                    {
                        if ($"{item.Group.Name}: {item.Surname} {item.Name} ({item.Login})".ToLower().Contains(text))
                        {
                            CBLogin.Items.Add($"{item.Group.Name}: {item.Surname} {item.Name} ({item.Login})");
                        }
                    }
                    CBLogin.IsDropDownOpen = true;
                    CBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}