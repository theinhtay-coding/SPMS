namespace SPMS.Models.Grade;

public class GradeResponseModel
{
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public decimal PaymentAmount { get; set; }
}