using SPMS.Models;
using SPMS.Models.Grade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMS.Modules.Features.Grade;

public class BL_Grade
{
    private readonly DA_Grade _daGrade;

    public BL_Grade(DA_Grade daGrade)
    {
        _daGrade = daGrade;
    }

    public async Task<Result<GradeListResponseModel>> GetGrades()
    {
        var respModel = await _daGrade.GetGrades();
        return respModel;
    }

    public async Task<Result<GradeResponseModel>> GetGradeById(int id)
    {
        var respModel = await _daGrade.GetGradeById(id);
        return respModel;
    }

    public GradeResponseModel CreateGrade(GradeRequestModel reqModel)
    {
        var respModel = _daGrade.CreateGrade(reqModel);
        return respModel;
    }

    public GradeResponseModel UpdateGrade(int id, GradeRequestModel reqModel)
    {
        var respModel = _daGrade.UpdateGrade(id, reqModel);
        return respModel;
    }

    public void DeleteGrade(int id)
    {
        _daGrade.DeleteGrade(id);
    }
}
