using Academy.DataBase;
using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for GradesList.xaml
    /// </summary>
    public partial class GradesList : UserControl
    {
        Frame MainFrame;
        AcademyContext academyContext = new AcademyContext();
        public GradesList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            LVGrades.ItemsSource = academyContext.Grades
                .Include(x=>x.Lesson)
                .Include(x=>x.Student).ToList();
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVGrades.SelectedIndex != -1)
            {
                academyContext.Grades.Remove(LVGrades.SelectedItem as Grade);
                academyContext.SaveChanges();

                MainFrame.Content = new GradesList(MainFrame);
            }
        }
    }
}
