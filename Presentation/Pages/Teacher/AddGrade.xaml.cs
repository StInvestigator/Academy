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
        public AddGrade()
        {
            InitializeComponent();

            LessonRepository lessonRepository = new LessonRepository();
            LessonUseCase lessonUseCase = new LessonUseCase();
            lessonUseCase.GetAllLessonsFromModel(lessonRepository);

            foreach (var item in lessonUseCase.lessons)
            {
                CBLesson.Items.Add(item.name);  
            }
        }

        private void TextBox_LoginChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBLogin);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GradeRepository gradeRepository = new GradeRepository();
            GradeUseCase gradeUseCase = new GradeUseCase();
            gradeUseCase.GetAllGradesFromModel(gradeRepository);

            if (CBGrade.Text != "" && CBLesson.Text != "" && TBLogin.Text.Trim() != "" && CBWorkType.Text != "")
            {
                try
                {
                    gradeUseCase.AddGrade(DateTime.Now, CBWorkType.Text, Convert.ToInt32(CBGrade.Text), CBLesson.Text, TBLogin.Text);
                    MessageBox.Show("Success!", "Evaluation done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Wrong data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                CBGrade.Text = ""; CBLesson.Text = ""; TBLogin.Text = ""; CBWorkType.Text = "";
                CBWorkType.BorderBrush = new SolidColorBrush(Colors.Red);
                CBGrade.BorderBrush = new SolidColorBrush(Colors.Red);
                CBLesson.BorderBrush = new SolidColorBrush(Colors.Red);
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
                TB.Text = TB.Text.Trim();
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
    }
}