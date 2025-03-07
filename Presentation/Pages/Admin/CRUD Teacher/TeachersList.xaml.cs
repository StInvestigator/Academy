﻿using Academy.DataBase;
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

namespace Academy.Presentation.Pages.Admin.CRUD_Teacher
{
    /// <summary>
    /// Interaction logic for TeachersList.xaml
    /// </summary>
    public partial class TeachersList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Frame MainFrame;
        public TeachersList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            LVTeachers.ItemsSource = academyContext.Teachers.OrderBy(x => x.Surname).ToList();
        }
        private void BAddClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EditTeacher(MainFrame);
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            if (LVTeachers.SelectedIndex != -1)
            {
                MainFrame.Content = new EditTeacher(MainFrame, LVTeachers.SelectedItem as Domain.Entities.Teacher);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVTeachers.SelectedIndex != -1)
            {
                academyContext.Teachers.Remove(LVTeachers.SelectedItem as Domain.Entities.Teacher);
                academyContext.SaveChanges();

                MainFrame.Content = new TeachersList(MainFrame);
            }
        }
    }
}
