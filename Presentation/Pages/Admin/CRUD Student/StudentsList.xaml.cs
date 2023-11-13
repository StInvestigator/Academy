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

namespace Academy.Presentation.Pages.Admin.CRUD_Student
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        public StudentsList()
        {
            InitializeComponent();

            StudentUseCase studentUseCase = new StudentUseCase();
            StudentRepository studentRepository = new StudentRepository();
            studentUseCase.GetAllStudentsFromModel(studentRepository);
            LVStudents.ItemsSource = studentUseCase.students.OrderBy(x => x.GroupName).ToList();
        }
    }
}
