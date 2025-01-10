using SPMS.Models;
using SPMS.Models.AcademicYear;
using SPMS.Modules.Features.Student;

namespace SPMS.Modules.Features.AcademicYear;

public class BL_AcademicYear
{
    private readonly DA_AcademicYear _daAcademicYear;

    public BL_AcademicYear(DA_AcademicYear daAcademicYear)
    {
        _daAcademicYear = daAcademicYear;
    }

    public async Task<Result<AcademicYearListResponseModel>> GetAcademicYears()
    {
        var lstAcademicYear = await _daAcademicYear.GetAcademicYears();
        return lstAcademicYear;
    }

    public async Task<Result<AcademicYearResponseModel>> GetAcademicYearById(int id)
    {
        Result<AcademicYearResponseModel> respModel = await _daAcademicYear.GetAcademicYearById(id);
        return respModel;
    }

    public async Task<Result<AcademicYearResponseModel>> CreateAcademicYear(AcademicYearRequestModel reqModel)
    {
        var respModel = await _daAcademicYear.CreateAcademicYear(reqModel);
        return respModel;
    }

    public async Task<Result<AcademicYearResponseModel>> UpdateAcademicYear(int id, AcademicYearRequestModel reqModel)
    {
        var respModel = await _daAcademicYear.UpdateAcademicYear(id, reqModel);
        return respModel;
    }

    public async Task<Result<object>> DeleteAcademicYear(int id)
    {
        if (id <= 0) throw new Exception("id less than 0");
        var respModel = await _daAcademicYear.DeleteAcademicYear(id);
        return respModel;
    }
}
