using SPMS.Models;
using SPMS.Models.AcademicYear;

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

    public AcademicYearResponseModel GetAcademicYearById(int id)
    {
        var respModel = _daAcademicYear.GetAcademicYearById(id);
        return respModel;
    }

    public AcademicYearResponseModel CreateAcademicYear(AcademicYearRequestModel reqModel)
    {
        var respModel = _daAcademicYear.CreateAcademicYear(reqModel);
        return respModel;
    }

    public AcademicYearResponseModel UpdateAcademicYear(int id, AcademicYearRequestModel reqModel)
    {
        var respModel = _daAcademicYear.UpdateAcademicYear(id, reqModel);
        return respModel;
    }

    public void DeleteAcademicYear(int id)
    {
        _daAcademicYear.DeleteAcademicYear(id);
    }
}
