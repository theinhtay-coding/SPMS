using SPMS.Database.Models;
using SPMS.Models.AcademicYear;

namespace SPMS.Modules.Features.AcademicYear;

public class DA_AcademicYear
{
    private readonly AppDbContext _db;

    public DA_AcademicYear(AppDbContext db)
    {
        _db = db;
    }

    public AcademicYearListResponseModel GetAcademicYears()
    {
        AcademicYearListResponseModel lst = new AcademicYearListResponseModel();
        var lstAcademicYear = _db.AcademicYears.ToList();
        return lst;
    }

    public AcademicYearResponseModel GetAcademicYearById(int id)
    {
        return new AcademicYearResponseModel();
    }

    public AcademicYearResponseModel CreateAcademicYear(AcademicYearRequestModel reqModel)
    {
        return new AcademicYearResponseModel();
    }

    public AcademicYearResponseModel UpdateAcademicYear(int id, AcademicYearRequestModel reqModel)
    {
        return new AcademicYearResponseModel();
    }

    public void DeleteAcademicYear(int id)
    {

    }
}
