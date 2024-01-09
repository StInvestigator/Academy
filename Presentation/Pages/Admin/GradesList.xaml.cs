using Academy.Data.Repositories;
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
    /// Interaction logic for GradesList.xaml
    /// </summary>
    public partial class GradesList : UserControl
    {
        Frame MainFrame;
        public GradesList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            GradeRepository gradeRepository = new GradeRepository();
            GradeUseCase gradeUseCase = new GradeUseCase();
            gradeUseCase.GetAllGradesFromModel(gradeRepository);

            if (gradeUseCase.grades.Count > 0)
            {
                LVGrades.ItemsSource = gradeUseCase.grades.OrderByDescending(x => x.Date).ToList();
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVGrades.SelectedIndex != -1)
            {
                GradeUseCase gradeUseCase = new GradeUseCase();
                gradeUseCase.DeleteGrade(LVGrades.SelectedItem as Domain.Entities.Grade);

                MainFrame.Content = new GradesList(MainFrame);
            }
        }
    }
}
