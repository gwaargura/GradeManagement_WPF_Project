using System;
using System.Collections.Generic;

namespace Student_Grades_Management.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
