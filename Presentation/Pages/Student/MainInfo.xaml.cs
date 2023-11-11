using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Academy.Domain.Entities;
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
    /// Interaction logic for MainInfo.xaml
    /// </summary>
    public partial class MainInfo : UserControl
    {
        Domain.Entities.Student student;
        public MainInfo(Domain.Entities.Student student)
        {
            this.student = student;
            student.grades.Add(new Grade(new DateTime(2020, 12, 30), "HT", 10));
            InitializeComponent();
            LVGrades.ItemsSource = student.grades.GetRange(0, student.grades.Count >= 5 ? 5 : student.grades.Count);

        }
    }
}
