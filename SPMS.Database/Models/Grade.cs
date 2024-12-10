using System;
using System.Collections.Generic;

namespace SPMS.Database.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public virtual ICollection<Promotion> PromotionFromGrades { get; set; } = new List<Promotion>();

    public virtual ICollection<Promotion> PromotionToGrades { get; set; } = new List<Promotion>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
