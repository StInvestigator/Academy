using Academy.Domain.Entities;
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

namespace Academy.Presentation.Pages.Admin
{
    /// <summary>
    /// Interaction logic for EditLesson.xaml
    /// </summary>
    public partial class EditLesson : UserControl
    {
        Frame MainFrame;
        Lesson? lesson;
        public EditLesson(Frame MainFrame,Lesson? lesson = null)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;
            this.lesson = lesson;

            if(lesson != null )
            {
                TBLesson.Text = lesson.name;
            }

        }

        private void TBLesson_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            if (TBLesson.Text.Length == 0 || TBLesson.Text.Trim() == "")
            {
                TBLesson.Text = string.Empty;
                TBLesson.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                TBLesson.BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //LessonRepository lessonRepository = new LessonRepository();
            //LessonUseCase lessonUseCase = new LessonUseCase();
            //lessonUseCase.GetAllLessonsFromModel(lessonRepository);

            if (TBLesson.Text != "")
            {
                try
                {
                    //if (lesson==null)
                    //{
                    //    lessonUseCase.AddLesson(TBLesson.Text);
                    //}
                    //else
                    //{
                    //    lessonUseCase.UpdateLesson(TBLesson.Text, lesson.name);
                    //}
                }
                catch
                {
                    MessageBox.Show("Wrong data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MainFrame.Content = new LessonsList(MainFrame);
            }
            else
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
