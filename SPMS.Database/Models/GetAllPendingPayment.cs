using System;
using System.Collections.Generic;

namespace SPMS.Database.Models;

public partial class GetAllPendingPayment
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string GradeName { get; set; } = null!;

    public string AcademicYear { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public decimal TotalPaid { get; set; }

    public decimal? OutstandingAmount { get; set; }
}
