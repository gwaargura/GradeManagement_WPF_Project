using System;
using System.Collections.Generic;

namespace Student_Grades_Management.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public virtual ICollection<TeacherAssignment> TeacherAssignments { get; set; } = new List<TeacherAssignment>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
