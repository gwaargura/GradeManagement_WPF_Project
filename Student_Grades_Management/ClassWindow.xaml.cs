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
    /// Interaction logic for ClassWindow.xaml
    /// </summary>
    public partial class ClassWindow : Window
    {
        string s = "";
        string c = "";
        int t = 0;
        bool update = false;
        double x = 0;
        G6FinalAssignmentContext context;
        public ClassWindow(string sub, string cl)
        {
            InitializeComponent();
            context = new G6FinalAssignmentContext();
            s = sub;
            c = cl;
            t = context.Subjects
            .Where(tii => tii.SubjectName == s)
            .Select(tii => tii.SubjectId)
            .FirstOrDefault();
            loadCb();
            load(s, c, t);
        }

        public void BtnSave_click(object sender, RoutedEventArgs e)
        {
                double a = int.Parse(txtSG.Text);
                if (a < 0)
                {
                    MessageBox.Show("Incorrect format of grade (0 <= grade <= 10)");
                }
                else if (a > 10) {      
                    MessageBox.Show("Incorrect format of grade (0 <= grade <= 10)");
                }
                else
                {
                    if (update == true)
                    {
                        var grade1 = context.Grades
                        .Where(g => g.StudentId == int.Parse(txtSI.Text) && g.TestId == (int)cbTest.SelectedValue)
                        .FirstOrDefault();
                        
                        if (grade1 != null)
                        {
                            MessageBox.Show($"Id: {grade1.GradeId}, StudentId: {grade1.StudentId}, TestId: {grade1.TestId}, TeacherId: {grade1.TeacherId}, Grade: {grade1.Grade1}, A: {a}");
                            grade1.Grade1 = a;
                            MessageBox.Show($"Id: {grade1.GradeId}, StudentId: {grade1.StudentId}, TestId: {grade1.TestId}, TeacherId: {grade1.TeacherId}, Grade: {grade1.Grade1}");

                        context.Grades.Update(grade1);
                            context.SaveChanges();
                            MessageBox.Show("Update Grade Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Grade not found");
                        }
                    }
                    else if (update == false)
                    {
                        Grade grade = new Grade();
                        grade.GradeId = context.Grades.Count() + 1;
                        grade.StudentId = int.Parse(txtSI.Text);
                        grade.TestId = (int)cbTest.SelectedValue;
                        grade.TeacherId = Settings.Id;
                        grade.Grade1 = double.Parse(txtSG.Text);
                        context.Grades.Add(grade);
                        context.SaveChanges();
                        MessageBox.Show("Add Grade Successfully!");
                    }
                }
            load(s, c, t);

        }
        public void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var grade1 = context.Grades
                        .Where(g => g.StudentId == int.Parse(txtSI.Text) && g.TestId == (int)cbTest.SelectedValue)
                        .FirstOrDefault();
            if (grade1 != null)
            {
                context.Grades.Remove(grade1);
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
            load(s, c, t);
        }
        public void load(string sub, string cl, int testId)
        {
            var students = context.Students
            .Where(s => s.Subjects.Any(subj => subj.SubjectName == sub) && s.Classes.Any(cls => cls.ClassName == cl))
            .Select(s => new
            {
                s.StudentId,
                s.StudentName,
                Grade = s.Grades
                    .Where(g => g.TestId == testId && g.StudentId == s.StudentId).
                    Select(g => g.Grade1).FirstOrDefault(),
            })
            .ToList();

            txtSubject.Text = sub;
            txtClass.Text = cl;
            
            //foreach (var student in students)
            //{
            //    MessageBox.Show("Student " + student.StudentName + ", Grade " + student.Grade);
            //}
            lsClass.ItemsSource = students;
        }
        private void lsClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsClass.SelectedItem != null)
            {
                dynamic selectedTest = lsClass.SelectedItem;
                txtSI.Text = selectedTest.StudentId + "";
                txtSN.Text = selectedTest.StudentName;
                txtSG.Text = selectedTest.Grade + "";
                x = selectedTest.Grade;
                if(txtSG.Text.Length > 0)
                {
                    update = true;
                }
                else
                {
                update = false; 
                }
                //string message = $"Test Name: {selectedTest.TestName}\nWeight: {selectedTest.Weight}\nGrade: {selectedTest.Grade}";
                //MessageBox.Show(message, "Selected Test Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        private void loadCb()
        {
            t = context.Subjects
            .Where(tii => tii.SubjectName == s)
            .Select(tii => tii.SubjectId)
            .FirstOrDefault();
            var cb = context.Tests.Where(test => test.SubjectId == t).Select(test => new
            {
                TestName = test.TestName,
                TestId = test.TestId,
            }).ToList(); 
            cbTest.ItemsSource = cb;
            cbTest.DisplayMemberPath = "TestName";
            cbTest.SelectedValuePath = "TestId";
            if(cbTest.SelectedValue == null)
            {
                cbTest.SelectedIndex = 0;
            }
        }
        private void cmbTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load(s, c, (int)cbTest.SelectedValue);
        }
    }
}
