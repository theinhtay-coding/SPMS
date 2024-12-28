using SPMS.Models;
using SPMS.Models.Grade;

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

    public async Task<Result<GradeResponseModel>> CreateGrade(GradeRequestModel reqModel)
    {
        var respModel = await _daGrade.CreateGrade(reqModel);
        return respModel;
    }

    public async Task<Result<GradeResponseModel>> UpdateGrade(int id, GradeRequestModel reqModel)
    {
        if (id <= 0) throw new Exception("id is null");
        var respModel = await _daGrade.UpdateGrade(id, reqModel);
        return respModel;
    }

    public async Task<Result<object>> DeleteGrade(int id)
    {
        if (id <= 0) throw new Exception("Id less than 0");
        var respModel = await _daGrade.DeleteGrade(id);
        return respModel;
    }
}
