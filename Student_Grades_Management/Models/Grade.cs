using System;
using System.Collections.Generic;

namespace Student_Grades_Management.Models;

public partial class Grade
{
    public int GradeId { get; set; }
    public int? StudentId { get; set; }

    public int? TestId { get; set; }

    public int? TeacherId { get; set; }

    public double? Grade1 { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual Test? Test { get; set; }
}
