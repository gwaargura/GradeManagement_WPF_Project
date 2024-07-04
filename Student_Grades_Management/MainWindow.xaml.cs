using Student_Grades_Management.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Grades_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void mnuShow_SWP391(object sender, RoutedEventArgs e)
        {
            ViewGradeWindow v = new ViewGradeWindow("SWP391");
            v.Show();
        }

        private void mnuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuShow_SWT301(object sender, RoutedEventArgs e)
        {
            ViewGradeWindow v = new ViewGradeWindow("SWT301");
            v.Show();
        }

        private void mnuShow_SWR302(object sender, RoutedEventArgs e)
        {
            ViewGradeWindow v = new ViewGradeWindow("SWR302");
            v.Show();
        }

        private void mnuShow_PRN212(object sender, RoutedEventArgs e)
        {
            ViewGradeWindow v = new ViewGradeWindow("PRN212");
            v.Show();
        }

        private void mnuProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow v = new ProfileWindow();
            v.Show();
        }

        private void mnuLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }
    }
}