using System.Text.Json.Serialization;

namespace SPMS.Models.Grade;

public class GradeRequestModel
{
    [JsonIgnore]
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public decimal PaymentAmount { get; set; }
}
