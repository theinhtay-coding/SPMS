using SPMS.Models.Custom;

namespace SPMS.Models.Grade;

public class GradeListResponseModel
{
    public List<GradeModel> Grades { get; set; }
    public PageSettingModel PageSetting { get; set; }
}
