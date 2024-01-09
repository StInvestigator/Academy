using Academy.Data.Repositories;
using Academy.Domain.Entities;
using Academy.Domain.UseCases;
using Academy.Presentation.Pages.Admin.CRUD_Student;
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
using System.Xml.Linq;

namespace Academy.Presentation.Pages.Admin.CRUD_Schedule
{
    /// <summary>
    /// Interaction logic for EditSchedule.xaml
    /// </summary>
    public partial class EditSchedule : UserControl
    {
        int id;
        Domain.Entities.Schedule schedule;
        Frame MainFrame;
        public EditSchedule(Frame MainFrame, Domain.Entities.Schedule schedule = null, int Id = 0)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;
            this.schedule = schedule;
            id = Id;

            LessonRepository lessonRepository = new LessonRepository();
            LessonUseCase lessonUseCase = new LessonUseCase();
            lessonUseCase.GetAllLessonsFromModel(lessonRepository);

            foreach (var item in lessonUseCase.lessons)
            {
                CBLesson.Items.Add(item.name);
            }

            GroupRepository groupRepository = new GroupRepository();
            GroupUseCase groupUseCase = new GroupUseCase();
            groupUseCase.GetAllGroupsFromModel(groupRepository);

            foreach (var item in groupUseCase.groups)
            {
                CBGroup.Items.Add(item.Name);
            }

            if (schedule != null )
            {
                TeacherRepository teacherRepository = new TeacherRepository();
                TeacherUseCase teacherUseCase = new TeacherUseCase();
                teacherUseCase.GetAllTeachersFromModel(teacherRepository);

                TBLogin.Text = teacherUseCase.teachers.Find(x=> x.Name == schedule.TeacherName && x.Surname == schedule.TeacherSurname).Login;
                TBClass.Text = schedule.Class;
                CBGroup.Text = schedule.GroupName;
                CBLesson.Text = schedule.Lesson;
                DPdate.Text = schedule.DateOnly.ToString();
                TPtime.Text = schedule.TimeOnly.ToString();
                TPtime.BorderBrush = new SolidColorBrush(Colors.White);
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

        private void TextBox_LoginChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBLogin);
        }

        private void CBLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBLesson.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBGroup.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void TBClass_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBClass);
        }

        private void DPdate_TextChanged(object sender, SelectionChangedEventArgs e)
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

        private void TPtime_TextChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (TPtime.Text == null || TPtime.Text.Length == 0)
            {
                TPtime.Text = string.Empty;
                TPtime.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                TPtime.BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBClass.Text != "" && TBLogin.Text != "" && CBGroup.Text != "" && CBLesson.Text != "" && DPdate.Text != "" && TPtime.Text != "")
            {
                try
                {
                    TeacherRepository teacherRepository = new TeacherRepository();
                    TeacherUseCase useCase = new TeacherUseCase();
                    useCase.GetAllTeachersFromModel(teacherRepository);

                    ScheduleUseCase scheduleUseCase = new ScheduleUseCase();
                    if (schedule == null)
                    {
                        scheduleUseCase.AddSchedule(DateOnly.FromDateTime(DPdate.SelectedDate??DateTime.Now).ToDateTime(TimeOnly.FromDateTime(TPtime.SelectedTime??DateTime.Now)), 
                            TBClass.Text,TBLogin.Text, CBGroup.Text, CBLesson.Text);
                    }
                    else
                    {
                        scheduleUseCase.UpdateSchedule(DateOnly.FromDateTime(DPdate.SelectedDate ?? DateTime.Now).ToDateTime(TimeOnly.FromDateTime(TPtime.SelectedTime ?? DateTime.Now)),
                            TBClass.Text, TBLogin.Text, CBGroup.Text, CBLesson.Text, id);
                    }
                    MainFrame.Content = new SchedulesList(MainFrame);
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
    }
}
