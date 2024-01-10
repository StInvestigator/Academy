using Academy.Data.Repositories;
using Academy.Domain.Entities;
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

namespace Academy.Presentation.Pages.Admin
{
    /// <summary>
    /// Interaction logic for LessonsList.xaml
    /// </summary>
    public partial class LessonsList : UserControl
    {
        Frame MainFrame;
        public LessonsList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            LessonRepository lessonRepository = new LessonRepository();
            LessonUseCase lessonUseCase = new LessonUseCase();
            lessonUseCase.GetAllLessonsFromModel(lessonRepository);

            if(lessonUseCase.lessons.Count > 0 )
            {
                LVLessons.ItemsSource = lessonUseCase.lessons;
            }
        }

        private void BAddClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EditLesson(MainFrame);
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            if (LVLessons.SelectedIndex != -1)
            {
                MainFrame.Content = new EditLesson(MainFrame,LVLessons.SelectedItem as Lesson);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVLessons.SelectedIndex != -1)
            {
                LessonUseCase lessonUseCase = new LessonUseCase();
                lessonUseCase.DeleteLesson((LVLessons.SelectedItem as Lesson).Name);
            }
        }
    }
}
