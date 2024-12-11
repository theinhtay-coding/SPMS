namespace SPMS.Models.Grade;

public class GradeModel
{
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public decimal PaymentAmount { get; set; }
}
