using Microsoft.Extensions.Configuration;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        G6FinalAssignmentContext context;
        public LoginWindow()
        {
            InitializeComponent();
            context = new G6FinalAssignmentContext();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var conf = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            string name, pass;
            name = conf.GetSection("Admin").GetSection("Name").Value;
            pass = conf.GetSection("Admin").GetSection("Password").Value;

            string username = usernameTextBox.Text;
            string password = passwordBox.Password;
            string role = (roleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (username == name && password == pass && role == "Admin")
            {
                Settings.Id = 0;
                Settings.Name = username;
                Settings.Role = 0;
                MessageBox.Show($"Login successful as {role}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else if (role == "Student")
            {
                Student student = context.Students.FirstOrDefault(s => s.StudentName == username && s.Password == password);
                if (student != null)
                {
                    Settings.Id = student.StudentId;
                    Settings.Name = student.StudentName;
                    Settings.Role = 1;
                    MainWindow m = new MainWindow();
                    m.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (role == "Teacher")
            {
                Teacher teacher = context.Teachers.FirstOrDefault(t => t.TeacherName == username && t.Password == password);
                if (teacher != null)
                {
                    Settings.Id = teacher.TeacherId;
                    Settings.Name = username;
                    Settings.Role = 2;
                    TeacherHomeWindow m = new TeacherHomeWindow();
                    m.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username, password, or role.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the fields
            usernameTextBox.Clear();
            passwordBox.Clear();
            roleComboBox.SelectedIndex = -1;
        }
    }
}
