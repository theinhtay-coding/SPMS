using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMS.Models.Custom;

namespace SPMS.Models.AcademicYear;

public class AcademicYearListResponseModel
{
    public List<AcademicYearResponseModel> AcademicYears { get; set; }
    public PageSettingModel PageSetting { get; set; }
}
