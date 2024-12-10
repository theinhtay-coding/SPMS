using System;
using System.Collections.Generic;

namespace SPMS.Database.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int GradeId { get; set; }

    public int CurrentYearId { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public virtual AcademicYear CurrentYear { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
