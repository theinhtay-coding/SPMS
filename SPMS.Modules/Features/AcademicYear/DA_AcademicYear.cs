using SPMS.Models.AcademicYear;

namespace SPMS.Modules.Features.AcademicYear;

public class DA_AcademicYear
{
    private readonly AppDbContext _db;

    public DA_AcademicYear(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<AcademicYearListResponseModel>> GetAcademicYears()
    {
        Result<AcademicYearListResponseModel> model = new Result<AcademicYearListResponseModel>();
        try
        {
            var lstAcademicYear = await _db.AcademicYears.AsNoTracking().ToListAsync();
            if (!lstAcademicYear.Any())
            {
                model = Result<AcademicYearListResponseModel>.Success(new AcademicYearListResponseModel()
                {
                    AcademicYears = new List<AcademicYearResponseModel>()
                });
            }

            var academicYears = lstAcademicYear.Select(academicYear => academicYear.Change()).ToList();

            var lstResponseModel = new AcademicYearListResponseModel()
            {
                AcademicYears = academicYears
            };

            model = Result<AcademicYearListResponseModel>.Success(lstResponseModel);
        }
        catch (Exception ex)
        {
            model = Result<AcademicYearListResponseModel>.Error(ex);
        }

        return model;
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