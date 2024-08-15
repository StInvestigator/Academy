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
using static System.Net.Mime.MediaTypeNames;

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : UserControl
    {
        StudentUseCase studentUseCase;
        GroupUseCase groupUseCase;
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

            StudentRepository studentRepository = new StudentRepository();
            studentUseCase = new StudentUseCase();
            studentUseCase.GetAllStudentsFromModel(studentRepository);

            GroupRepository groupRepository = new GroupRepository();
            groupUseCase = new GroupUseCase();
            groupUseCase.GetAllGroupsFromModel(groupRepository);

            foreach (var item in groupUseCase.groups)
            {
                CBLogin.Items.Add(item.Name);
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
            CBLogin.Items.Clear();
            if (TBGroupStudent.IsChecked == true)
            {
                LGL.Content = "Student";

                foreach (var item in studentUseCase.students)
                {
                    CBLogin.Items.Add($"{item.GroupName}: {item.Surname} {item.Name} ({item.Login})");
                }
            }
            else
            {
                LGL.Content = "Group Name";

                foreach (var item in groupUseCase.groups)
                {
                    CBLogin.Items.Add(item.Name);
                }
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

            if (TBDesc.Text != "" && CBLesson.Text != "" && CBLogin.Text != "" && CBWorkType.Text != "" && DPdate.Text != "")
            {
                try
                {
                    if (TBGroupStudent.IsChecked == true)
                    {
                        taskUseCase.AddTask(TBDesc.Text, CBWorkType.Text, CBLesson.Text, CBLogin.Text.Split("(")[1].Remove(CBLogin.Text.Split("(")[1].Length - 1), DPdate.SelectedDate ?? DateTime.Now);
                    }
                    else
                    {
                        var students = studentUseCase.students.Where(x => x.GroupName == CBLogin.Text);
                        if (students.Count() == 0) { throw new Exception(); }

                        foreach (var item in students)
                        {
                            taskUseCase.AddTask(TBDesc.Text, CBWorkType.Text, CBLesson.Text, item.Login, DPdate.SelectedDate ?? DateTime.Now);
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
                        foreach (var item in studentUseCase.students)
                        {
                            if ($"{item.GroupName}: {item.Surname} {item.Name}  ({item.Login})".ToLower().Contains(text))
                            {
                                CBLogin.Items.Add($"{item.GroupName}: {item.Surname} {item.Name}  ({item.Login})");
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in groupUseCase.groups)
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
                foreach (var item in studentUseCase.students)
                {
                    if ($"{item.GroupName}: {item.Surname} {item.Name}  ({item.Login})".ToLower().Contains(text))
                    {
                        CBLogin.Items.Add($"{item.GroupName}: {item.Surname} {item.Name}  ({item.Login})");
                    }
                }
            }

            else
            {

                foreach (var item in groupUseCase.groups)
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
