using Academy.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Navigation;
using Academy.Presentation.Pages;
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

namespace Academy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {

            AcademyContext academyContext = new AcademyContext();
            academyContext.Database.EnsureCreated();

            MessageBox.Show(academyContext.Groups.Count().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            NavigatorObject.pageSwitcher = this;
            NavigatorObject.Switch(new Presentation.Pages.Authorization());
        }

        public Action? CloseAction { get; set; }

        public void Navigate(UserControl nextPage)
        {
            Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            Content = nextPage;
            INavigator? s = nextPage as INavigator;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not INavigator! " + nextPage.Name.ToString());
        }
    }
}
