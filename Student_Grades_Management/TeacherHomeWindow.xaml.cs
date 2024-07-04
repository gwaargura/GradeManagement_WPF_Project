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
using System.Windows.Shapes;

namespace Student_Grades_Management
{
    /// <summary>
    /// Interaction logic for TeacherHomeWindow.xaml
    /// </summary>
    public partial class TeacherHomeWindow : Window
    {
        public TeacherHomeWindow()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuViewTeaching_Click(object sender, RoutedEventArgs e)
        {
            ViewTeachingWindow v = new ViewTeachingWindow();
            v.Show();
        }


        private void mnuProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow v = new ProfileWindow();
            v.Show();
        }

        private void mnuLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            this.Close();
        }
    }
}
