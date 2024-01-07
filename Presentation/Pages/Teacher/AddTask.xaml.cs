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

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : UserControl
    {
        public AddTask()
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

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DPdate.SelectedDate < DateTime.Now.Date) { DPdate.SelectedDate = null; DPdate.Text = ""; }
            if (DPdate.Text.Length == 0 || DPdate.Text.Trim() == "")
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
            if(TBGroupStudent.IsChecked == true)
            {
                LGL.Content = "Student Login";
            }
            else
            {
                LGL.Content = "Group Name";
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

        private void TextBox_LoginChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBLogin);
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
            Validation(TBDesc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskRepository taskRepository = new TaskRepository();
            TaskUseCase taskUseCase = new TaskUseCase();
            taskUseCase.GetAllTasksFromModel(taskRepository);

            if (TBDesc.Text != "" && CBLesson.Text != "" && TBLogin.Text != "" && CBWorkType.Text != "" && DPdate.Text != "")
            {
                try
                {
                    if (TBGroupStudent.IsChecked == true)
                    {
                        taskUseCase.AddTask(TBDesc.Text, CBWorkType.Text, CBLesson.Text, TBLogin.Text, DPdate.SelectedDate ?? DateTime.Now);
                    }
                    else
                    {

                        StudentRepository studentRepository = new StudentRepository();
                        StudentUseCase studentUseCase = new StudentUseCase();
                        studentUseCase.GetAllStudentsFromModel(studentRepository);

                        var res = studentUseCase.students.Where(x => x.GroupName == TBLogin.Text).ToList();
                        if (res.Count == 0) { throw new Exception(); }

                        foreach (var item in studentUseCase.students.Where(x => x.GroupName == TBLogin.Text))
                        {
                            taskUseCase.AddTask(TBDesc.Text, CBWorkType.Text, CBLesson.Text, item.Login, DPdate.SelectedDate ?? DateTime.Now);
                        }
                    }
                    MessageBox.Show("Success!", "Evaluation done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Wrong data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                TBDesc.Text = ""; CBLesson.Text = ""; TBLogin.Text = ""; CBWorkType.Text = ""; DPdate.SelectedDate = null; DPdate.Text = "";
                CBWorkType.BorderBrush = new SolidColorBrush(Colors.Red);
                DPdate.BorderBrush = new SolidColorBrush(Colors.Red);
                CBLesson.BorderBrush = new SolidColorBrush(Colors.Red);

            }
            else
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
