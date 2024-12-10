using SPMS.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMS.Models.Student;

public class StudentListResponseModel
{
    public List<StudentModel> Students { get; set; }
    public PageSettingModel PageSetting { get; set; }
}
