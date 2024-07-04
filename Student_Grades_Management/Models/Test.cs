using System;
using System.Collections.Generic;

namespace Student_Grades_Management.Models;

public partial class Test
{
    public int TestId { get; set; }

    public string? TestName { get; set; }

    public double? Weight { get; set; }

    public int? SubjectId { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Subject? Subject { get; set; }
}
