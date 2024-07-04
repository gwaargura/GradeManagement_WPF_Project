using System;
using System.Collections.Generic;

namespace Student_Grades_Management.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<TeacherAssignment> TeacherAssignments { get; set; } = new List<TeacherAssignment>();
}
