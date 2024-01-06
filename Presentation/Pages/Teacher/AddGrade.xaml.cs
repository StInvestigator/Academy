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

namespace Academy.Presentation.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for AddGrade.xaml
    /// </summary>
    public partial class AddGrade : UserControl
    {
        public AddGrade()
        {
            InitializeComponent();
        }

        private void TextBox_LoginChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBLogin);
        }

        private void TextBox_LessonChanged(object sender, TextChangedEventArgs e)
        {
            Validation(TBLesson);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GradeRepository gradeRepository = new GradeRepository();
            GradeUseCase gradeUseCase = new GradeUseCase();
            gradeUseCase.GetAllGradesFromModel(gradeRepository);

            if(CBGrade.Text != "" && TBLesson.Text.Trim() != "" && TBLogin.Text.Trim() != "" && CBWorkType.Text != "")
            {
                try
                {
                    gradeUseCase.AddGrade(DateTime.Now, CBWorkType.Text, Convert.ToInt32(CBGrade.Text), TBLesson.Text, TBLogin.Text);
                    MessageBox.Show("Success!", "Evaluation done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch 
                {
                    MessageBox.Show("Wrong data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    CBGrade.Text = ""; TBLesson.Text = ""; TBLogin.Text = ""; CBWorkType.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Not all fields are fillen!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        void Validation(TextBox TB)
        {
            if (TB.Text.Length == 0 || TB.Text.Trim() == "")
            {
                TB.Text = string.Empty;
                TB.BorderBrush = new SolidColorBrush(Colors.Red);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TB, "Field is required");
            }
            else
            {
                TB.BorderBrush = new SolidColorBrush(Colors.White);
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(TB, "");
            }
        }
    }
}
