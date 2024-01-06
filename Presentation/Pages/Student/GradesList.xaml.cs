using Academy.Data.Repositories;
using Academy.Data.Repositories.DataBase;
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

namespace Academy.Presentation.Pages.Student
{
    /// <summary>
    /// Interaction logic for GradesList.xaml
    /// </summary>
    public partial class GradesList : UserControl
    {
        Domain.Entities.Student student;
        public GradesList(Domain.Entities.Student student)
        {
           this.student = student;
           InitializeComponent();

            GradeRepository gradeRepository = new GradeRepository();
            GradeUseCase gradeUseCase = new GradeUseCase();
            gradeUseCase.GetAllGradesFromModel(gradeRepository);

            if (gradeUseCase.grades.Count > 0)
            {
                gradeUseCase.grades = gradeUseCase.grades.FindAll(x => x.StudentLogin == student.Login).OrderByDescending(x => x.Date).ToList();
                LVGrades.ItemsSource = gradeUseCase.grades;
            }
        }
    }
}
