using System;
using System.Collections.Generic;

namespace SPMS.Database.Models;

public partial class AcademicYear
{
    public int AcademicYearId { get; set; }

    public string Year { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
