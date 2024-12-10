using System;
using System.Collections.Generic;

namespace SPMS.Database.Models;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public int StudentId { get; set; }

    public int FromGradeId { get; set; }

    public int ToGradeId { get; set; }

    public int AcademicYearId { get; set; }

    public DateOnly PromotionDate { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Grade FromGrade { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Grade ToGrade { get; set; } = null!;
}
