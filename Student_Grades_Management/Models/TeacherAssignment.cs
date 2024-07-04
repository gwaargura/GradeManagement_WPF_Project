using System;
using System.Collections.Generic;

namespace Student_Grades_Management.Models;

public partial class TeacherAssignment
{
    public int TeacherId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
