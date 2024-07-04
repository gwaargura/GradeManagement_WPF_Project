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
    /// <summary>
    /// Interaction logic for ViewGradeWindow.xaml
    /// </summary>
    public partial class ViewGradeWindow : Window
    {
        G6FinalAssignmentContext context;
        public ViewGradeWindow(string subjectName)
        {
            InitializeComponent();
            context = new G6FinalAssignmentContext();
            LoadData(subjectName);
        }

        private void LoadData(string subjectName)
        {
            var subject = context.Subjects.FirstOrDefault(s => s.SubjectName == subjectName);
            if (subject != null)
            {
                txtSubjectName.Text = subject.SubjectName;
            }
            else
            {
                txtSubjectName.Text = "Subject Not Found";
                return;
            }
            var className = context.Classes
                                .Where(c => c.Students.Any(s => s.StudentId == Settings.Id))
                                .Select(c => c.ClassName)
                                .FirstOrDefault();
            txtClassName.Text = className;
            var query = from t in context.Tests
                        join s in context.Subjects
                        on t.SubjectId equals s.SubjectId into subjectGroup
                        from s in subjectGroup.DefaultIfEmpty()
                        join g in context.Grades
                        on t.TestId equals g.TestId into gradeGroup
                        from g in gradeGroup.DefaultIfEmpty()
                        where s.SubjectName == subjectName && g.StudentId == Settings.Id
                        select new
                        {
                            t.TestName,
                            t.Weight,
                            Grade = g != null ? g.Grade1 : 0
                        };
            var results = query.ToList();
            if (results.Count == 0)
            {
                MessageBox.Show("No data found.");
            }
            double total = 0;
            foreach (var item in results)
            {
                total += (double)(item.Weight * item.Grade);
            }
            lsTests.ItemsSource = results;
            txtTotalGrade.Text = total.ToString();
        }

        private void lsTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsTests.SelectedItem != null)
            {
                dynamic selectedTest = lsTests.SelectedItem;
                //string message = $"Test Name: {selectedTest.TestName}\nWeight: {selectedTest.Weight}\nGrade: {selectedTest.Grade}";
                //MessageBox.Show(message, "Selected Test Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }

}
