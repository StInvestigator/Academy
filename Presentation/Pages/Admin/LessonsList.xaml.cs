﻿using Academy.DataBase;
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
    /// Interaction logic for LessonsList.xaml
    /// </summary>
    public partial class LessonsList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Frame MainFrame;
        public LessonsList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            LVLessons.ItemsSource = academyContext.Lessons.ToList();
        }

        private void BAddClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EditLesson(MainFrame);
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            if (LVLessons.SelectedIndex != -1)
            {
                MainFrame.Content = new EditLesson(MainFrame, LVLessons.SelectedItem as Lesson);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVLessons.SelectedIndex != -1)
            {
                academyContext.Lessons.Remove(LVLessons.SelectedItem as Lesson);
                academyContext.SaveChanges();

                MainFrame.Content = new LessonsList(MainFrame);
            }
        }
    }
}
