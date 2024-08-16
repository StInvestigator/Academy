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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //GroupRepository groupRepository = new GroupRepository();
            //GroupUseCase groupUseCase = new GroupUseCase();
            //groupUseCase.GetAllGroupsFromModel(groupRepository);

            if (TBGroup.Text != "")
            {
                try
                {
                    //if (group == null)
                    //{
                    //    groupUseCase.AddGroup(TBGroup.Text, Convert.ToInt32(CBYear.Text));
                    //}
                    //else
                    //{
                    //    groupUseCase.UpdateGroup(TBGroup.Text, Convert.ToInt32(CBYear.Text), group.Name);
                    //}
                }
                catch
                {
                    MessageBox.Show("Wrong data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MainFrame.Content = new GroupsList(MainFrame);
            }
            else
            {
                MessageBox.Show("Not all fields are fillen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CBYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBYear.BorderBrush = new SolidColorBrush(Colors.White);
        }
    }
}
