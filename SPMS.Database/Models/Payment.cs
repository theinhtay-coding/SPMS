using System;
using System.Collections.Generic;

namespace SPMS.Database.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int StudentId { get; set; }

    public int AcademicYearId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public decimal AmountPaid { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
