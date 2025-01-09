using Academy.DataBase;
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

namespace Academy.Presentation.Pages.Admin.CRUD_Group
{
    /// <summary>
    /// Interaction logic for TeachersList.xaml
    /// </summary>
    public partial class GroupsList : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Frame MainFrame;
        public GroupsList(Frame MainFrame)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;

            var groups = academyContext.Groups.OrderBy(x => x.Name).ToList();
            foreach (var item in groups)
            {
                item.setStudentsCount();
            }
            LVTeachers.ItemsSource = groups;
        }
        private void BAddClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EditGroup(MainFrame);
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            if (LVTeachers.SelectedIndex != -1)
            {
                MainFrame.Content = new EditGroup(MainFrame, LVTeachers.SelectedItem as Domain.Entities.Group);
            }
        }

        private void BDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LVTeachers.SelectedIndex != -1)
            {
                academyContext.Groups.Remove(LVTeachers.SelectedItem as Domain.Entities.Group);
                academyContext.SaveChanges();

                MainFrame.Content = new GroupsList(MainFrame);
            }
        }
    }
}
