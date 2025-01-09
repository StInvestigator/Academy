using Academy.DataBase;
using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditLesson.xaml
    /// </summary>
    public partial class EditGroup : UserControl
    {
        AcademyContext academyContext = new AcademyContext();
        Frame MainFrame;
        Domain.Entities.Group? group;
        public EditGroup(Frame MainFrame, Domain.Entities.Group? group = null)
        {
            InitializeComponent();

            this.MainFrame = MainFrame;
            this.group = group;

            for (int i = 1; i <= 5; i++)
            {
                CBYear.Items.Add(i.ToString());
            }

            if (group != null)
            {
                TBGroup.Text = group.Name;
                CBYear.Text = group.Year.ToString();
            }

        }

        private void TBGroupName_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            if (TBGroup.Text.Length == 0 || TBGroup.Text.Trim() == "")
            {
                TBGroup.Text = string.Empty;
                TBGroup.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                TBGroup.BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        private bool isNameExists(int id = -1)
        {
            if (academyContext.Groups.FirstOrDefault(x => x.Name == TBGroup.Text && x.Id != id) != null)
            {
                TBGroup.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TBGroup, "This login is already exists");
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBGroup.Text == "")
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (group == null)
                {
                    if (isNameExists()) return;

                    academyContext.Groups.Add(new Domain.Entities.Group { 
                        Name = TBGroup.Text, 
                        Year = Convert.ToInt32(CBYear.Text) 
                    });
                }
                else
                {
                    if (isNameExists(group.Id)) return;

                    group.Name = TBGroup.Text;
                    group.Year = Convert.ToInt32(CBYear.Text);

                    academyContext.Groups.Update(group);
                }
                academyContext.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Wrong data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MainFrame.Content = new GroupsList(MainFrame);
        }

        private void CBYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBYear.BorderBrush = new SolidColorBrush(Colors.White);
        }
    }
}
