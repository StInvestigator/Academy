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

namespace Academy.Presentation.Pages.Admin.CRUD_Teacher
{
    /// <summary>
    /// Interaction logic for TeachersList.xaml
    /// </summary>
    public partial class TeachersList : UserControl
    {
        public TeachersList()
        {
            InitializeComponent();
            TeacherUseCase teacherUseCase = new TeacherUseCase();
            TeacherRepository teacherRepository = new TeacherRepository();
            teacherUseCase.GetAllTeachersFromModel(teacherRepository);
            LVTeachers.ItemsSource = teacherUseCase.teachers.OrderBy(x => x.Age).ToList();
        }
    }
}
