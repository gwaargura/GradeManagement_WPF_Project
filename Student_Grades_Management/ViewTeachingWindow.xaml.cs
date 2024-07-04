using Microsoft.EntityFrameworkCore;
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
    public partial class ViewTeachingWindow : Window
    {
        string sub = "";
        string cl = "";
        int subId = 0;

        G6FinalAssignmentContext context;
        public ViewTeachingWindow()
        {
            InitializeComponent();
            context = new G6FinalAssignmentContext();
            load();
        }
        public void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            var selected = lsTeach.SelectedItem;
            if (selected != null)
            {
                ClassWindow c = new ClassWindow(sub, cl);
                c.Show();

            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void load()
        {
            var result = context.TeacherAssignments
        .Where(ta => ta.TeacherId == Settings.Id)
        .Select(ta => new
        {
            SubjectId = ta.SubjectId,
            SubjectName = ta.Subject.SubjectName,
            ClassName = ta.Class.ClassName
        })
        .ToList();

            lsTeach.ItemsSource = result;
        }
        private void lsTeach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsTeach.SelectedItem != null)
            {
                dynamic selectedTeach = lsTeach.SelectedItem;
                subId = selectedTeach.SubjectId;
                sub = selectedTeach.SubjectName;
                cl = selectedTeach.ClassName;
                //string message = $"Subject Name: {selectedTeach.SubjectName}\nClass Name: {selectedTeach.ClassName}";
                //MessageBox.Show(message, "Selected Test Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
