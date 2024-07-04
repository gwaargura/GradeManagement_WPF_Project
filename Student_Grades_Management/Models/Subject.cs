using System;
using System.Collections.Generic;

namespace Student_Grades_Management.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public virtual ICollection<TeacherAssignment> TeacherAssignments { get; set; } = new List<TeacherAssignment>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
