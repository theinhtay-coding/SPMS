using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPMS.Models.AcademicYear;

public class AcademicYearRequestModel
{
    [JsonIgnore]
    public int AcademicYearId { get; set; }

    public string Year { get; set; } = null!;
}
