using Student_Grades_Management.Models;
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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        G6FinalAssignmentContext context;
        public ProfileWindow()
        {
            InitializeComponent();
            context = new G6FinalAssignmentContext();
            load();
        }

        private void load()
        {
            if (Settings.Role == 0) ;
            else if (Settings.Role == 1)
            {
                Student s = context.Students.Find(Settings.Id);
                IdTextBox.Text = s.StudentId.ToString();
                NameTextBox.Text = s.StudentName;
                PasswordBox.Password = s.Password;
                RoleTextBox.Text = "Student";
            }
            else if (Settings.Role == 2)
            {
                Teacher t = context.Teachers.Find(Settings.Id);
                IdTextBox.Text = t.TeacherId.ToString();
                NameTextBox.Text = t.TeacherName;
                PasswordBox.Password = t.Password;
                RoleTextBox.Text = "Teacher";
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Role == 0);
            else if (Settings.Role == 1)
            {
                Student s = context.Students.Find(Settings.Id);
                s.StudentName = NameTextBox.Text;
                s.Password = PasswordBox.Password;
                context.Students.Update(s);
                context.SaveChanges();
                MessageBox.Show("Update Student Information Successfully");
            }
            else if (Settings.Role == 2)
            {
                Teacher t = context.Teachers.Find(Settings.Id);
                t.TeacherName = NameTextBox.Text;
                t.Password = PasswordBox.Password;
                context.Teachers.Update(t);
                context.SaveChanges();
                MessageBox.Show("Update Teacher Information Successfully");
            }
            load();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
