using Academy.DataBase;
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

namespace Academy.Presentation.Pages.Student
{
    /// <summary>
    /// Interaction logic for GradesList.xaml
    /// </summary>
    public partial class GradesList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        public GradesList(Domain.Entities.Student student)
        {
           InitializeComponent();

            LVGrades.ItemsSource = academyContext.Grades
                .Include(x => x.Student)
                .Include(x => x.Lesson)
                .Where(x => x.Student.Login == student.Login)
                .OrderByDescending(x => x.Date).ToList();

        }
    }
}
