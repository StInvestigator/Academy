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
    /// Interaction logic for GradesList.xaml
    /// </summary>
    public partial class GradesList : UserControl
    {
        Frame MainFrame;
        public GradesList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            //GradeRepository gradeRepository = new GradeRepository();
            //GradeUseCase gradeUseCase = new GradeUseCase();
            //gradeUseCase.GetAllGradesFromModel(gradeRepository);

            //if (gradeUseCase.grades.Count > 0)
            //{
            //    LVGrades.ItemsSource = gradeUseCase.grades.OrderByDescending(x => x.Date).ToList();
            //}

            //
            LVGrades.ItemsSource = new List<Grade>() { new Grade
            {
                Date = DateTime.Now,
                WorkType = "HT",
                GradeNumber = 10,
                Lesson = new Lesson{ Name = "Math" },
                Student = new Domain.Entities.Student
                {
                    Age = 14,
                    Group = new Group
                    {
                        Name = "B205",
                        Year = 1
                    },
                    Login = "ultraLogin",
                    Password = "12312",
                    Name = "Name",
                    Surname = "Surname",
                }
            }
            };
            //
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVGrades.SelectedIndex != -1)
            {
                //GradeUseCase gradeUseCase = new GradeUseCase();
                //gradeUseCase.DeleteGrade(LVGrades.SelectedItem as Domain.Entities.Grade);

                MainFrame.Content = new GradesList(MainFrame);
            }
        }
    }
}
