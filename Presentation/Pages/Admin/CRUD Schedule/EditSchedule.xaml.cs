using Academy.DataBase;
using Academy.Domain.Entities;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy.Presentation.Pages.Admin.CRUD_Schedule
{
    /// <summary>
    /// Interaction logic for EditSchedule.xaml
    /// </summary>
    public partial class EditSchedule : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Domain.Entities.Schedule? schedule;
        Frame MainFrame;
        public EditSchedule(Frame MainFrame, Domain.Entities.Schedule? schedule = null)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;
            this.schedule = schedule;

            foreach (var item in academyContext.Lessons)
            {
                CBLesson.Items.Add(item.Name);
            }

            foreach (var item in academyContext.Groups)
            {
                CBGroup.Items.Add(item.Name);
            }

            foreach (var teacher in academyContext.Teachers)
            {
                CBLogin.Items.Add($"{teacher.Login} ({teacher.Surname})");
            }

            if (schedule != null)
            {
                CBLogin.Text = $"{schedule.Teacher.Login} ({schedule.Teacher.Surname})";
                TBClass.Text = schedule.Class;
                CBGroup.Text = schedule.Group.Name;
                CBLesson.Text = schedule.Lesson.Name;
                DPdate.Text = schedule.Date.ToString();
                TPtime.Text = TimeOnly.FromDateTime(schedule.Date).ToString();
                TPtime.BorderBrush = new SolidColorBrush(Colors.White);
                CBLogin.BorderBrush = new SolidColorBrush(Colors.White);
                CBGroup.BorderBrush = new SolidColorBrush(Colors.White);
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

        Schedule fillTheSchedule(Schedule schedule)
        {
            var teacherLogin = CBLogin.Text.Split(" ")[0];

            schedule.Date = DateOnly.FromDateTime(DPdate.SelectedDate ?? DateTime.Now).ToDateTime(TimeOnly.FromDateTime(TPtime.SelectedTime ?? DateTime.Now));
            schedule.Class = TBClass.Text;
            schedule.Teacher = academyContext.Teachers.First(x => x.Login == teacherLogin);
            schedule.Group = academyContext.Groups.First(x => x.Name == CBGroup.Text);
            schedule.Lesson = academyContext.Lessons.First(x => x.Name == CBLesson.Text);

            return schedule;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBClass.Text == "" || CBLogin.Text == "" || CBGroup.Text == "" || CBLesson.Text == "" || DPdate.Text == "" || TPtime.Text == "")
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (schedule == null)
                {
                    academyContext.Schedules.Add(fillTheSchedule(new Schedule()));
                }
                else
                {
                    academyContext.Schedules.Update(fillTheSchedule(schedule));
                }
                academyContext.SaveChanges();
                MainFrame.Content = new SchedulesList(MainFrame);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CBGroup_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string text = (CBGroup.Text + e.Text).ToLower();
            CBGroup.Items.Clear();
            foreach (var item in academyContext.Groups)
            {
                if (item.Name.ToLower().Contains(text))
                {
                    CBGroup.Items.Add(item.Name);
                }
            }
            CBGroup.IsDropDownOpen = true;
            CBGroup.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void CBLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBLogin.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void CBLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string text = (CBLogin.Text + e.Text).ToLower();
            CBLogin.Items.Clear();
            foreach (var item in academyContext.Teachers)
            {
                if ($"{item.Login} ({item.Surname})".ToLower().Contains(text))
                {
                    CBLogin.Items.Add($"{item.Login} ({item.Surname})");
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
                    foreach (var item in academyContext.Teachers)
                    {
                        if ($"{item.Login} ({item.Surname})".ToLower().Contains(text))
                        {
                            CBLogin.Items.Add($"{item.Login} ({item.Surname})");
                        }
                    }
                    CBLogin.IsDropDownOpen = true;
                    CBLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void CBGroup_KeyDown(object sender, KeyEventArgs e)
        {
            string text = CBGroup.Text.ToLower();
            CBGroup.Items.Clear();
            foreach (var item in academyContext.Groups)
            {
                if (item.Name.ToLower().Contains(text))
                {
                    CBGroup.Items.Add(item.Name);
                }
            }
        }
    }
}
