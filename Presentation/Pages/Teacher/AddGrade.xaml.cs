using Academy.Data.Repositories;
using Academy.Domain.UseCases;
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

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for AddGrade.xaml
    /// </summary>
    public partial class AddGrade : UserControl
    {

        StudentUseCase studentUseCase;
        public AddGrade()
        {
            InitializeComponent();

            StudentRepository studentRepository = new StudentRepository();
            studentUseCase = new StudentUseCase();
            studentUseCase.GetAllStudentsFromModel(studentRepository);

            foreach (var item in studentUseCase.students)
            {
                CBLogin.Items.Add($"{item.GroupName}: {item.Surname} {item.Name} ({item.Login})");
            }

            LessonRepository lessonRepository = new LessonRepository();
            LessonUseCase lessonUseCase = new LessonUseCase();
            lessonUseCase.GetAllLessonsFromModel(lessonRepository);

            foreach (var item in lessonUseCase.lessons)
            {
                CBLesson.Items.Add(item.name);  
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GradeRepository gradeRepository = new GradeRepository();
            GradeUseCase gradeUseCase = new GradeUseCase();
            gradeUseCase.GetAllGradesFromModel(gradeRepository);

            if (CBGrade.Text != "" && CBLesson.Text != "" && CBLogin.Text != "" && CBWorkType.Text != "")
            {
                try
                {
                    gradeUseCase.AddGrade(DateTime.Now, CBWorkType.Text, Convert.ToInt32(CBGrade.Text), CBLesson.Text, CBLogin.Text.Split("(")[1].Remove(CBLogin.Text.Split("(")[1].Length-1));
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
            foreach (var item in studentUseCase.students)
            {
                if ($"{item.GroupName}: {item.Surname} {item.Name} ({item.Login})".ToLower().Contains(text))
                {
                    CBLogin.Items.Add($"{item.GroupName}: {item.Surname} {item.Name} ({item.Login})");
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
                    foreach (var item in studentUseCase.students)
                    {
                        if ($"{item.GroupName}: {item.Surname} {item.Name} ({item.Login})".ToLower().Contains(text))
                        {
                            CBLogin.Items.Add($"{item.GroupName}: {item.Surname} {item.Name} ({item.Login})");
                        }
                    }
                    CBLogin.IsDropDownOpen = true;
                    CBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}