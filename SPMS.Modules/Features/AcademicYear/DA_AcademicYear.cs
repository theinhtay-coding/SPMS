using SPMS.Models.AcademicYear;
using SPMS.Models.Student;

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

    public async Task<Result<AcademicYearResponseModel>> GetAcademicYearById(int id)
    {
        Result<AcademicYearResponseModel> model = null;
        try
        {
            var academicYear = await _db.AcademicYears.AsNoTracking().SingleOrDefaultAsync(x => x.AcademicYearId == id);
            if (academicYear is null)
            {
                model = Result<AcademicYearResponseModel>.Error($"There is no academic year record with id {id}");
                goto result;
            }
            var respModel = academicYear!.Change();

            model = Result<AcademicYearResponseModel>.Success(respModel);
        }
        catch (Exception ex)
        {
            model = Result<AcademicYearResponseModel>.Error(ex);
        }
    result:
        return model;
    }

    public async Task<Result<AcademicYearResponseModel>> CreateAcademicYear(AcademicYearRequestModel reqModel)
    {
        Result<AcademicYearResponseModel> model = new Result<AcademicYearResponseModel>();

        try
        {
            if (reqModel is null)
            {
                throw new ArgumentNullException("Request model can not be null");
            }

            var academicYear = reqModel.Change();
            await _db.AcademicYears.AddAsync(academicYear);
            var result = await _db.SaveChangesAsync();
            var respModel = academicYear.Change();

            model = result > 0
                ? Result<AcademicYearResponseModel>.Success(respModel)
                : Result<AcademicYearResponseModel>.Error("Academic Year create failed.");
        }
        catch (Exception ex)
        {
            model = Result<AcademicYearResponseModel>.Error(ex);
        }
        return model;
    }

    public async Task<Result<AcademicYearResponseModel>> UpdateAcademicYear(int id, AcademicYearRequestModel reqModel)
    {
        Result<AcademicYearResponseModel> model = null;
        try
        {
            if (reqModel is null) throw new ArgumentNullException("Request model can not be null");

            var academicYear = await _db.AcademicYears.AsNoTracking().FirstOrDefaultAsync(x => x.AcademicYearId == id);
            if (academicYear is null)
            {
                model = Result<AcademicYearResponseModel>.Error($"There is no academic year record with id {id}");
                goto result;
            }
            if (!string.IsNullOrEmpty(reqModel.Year)) academicYear.Year = reqModel.Year;

            _db.Entry(academicYear).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            var respModel = academicYear.Change();
            model = result > 0
                ? Result<AcademicYearResponseModel>.Success(respModel)
                : Result<AcademicYearResponseModel>.Error("Academic Year update failed.");
        }
        catch (Exception ex)
        {
            model = Result<AcademicYearResponseModel>.Error(ex);
        }

    result:
        return model;
    }

    public async Task<Result<object>> DeleteAcademicYear(int id)
    {
        Result<object> model = null;
        try
        {
            var academicYear = await _db.AcademicYears.AsNoTracking().FirstOrDefaultAsync(x => x.AcademicYearId == id);
            if (academicYear is null) return model = Result<object>.Error($"Academic Year not found with id {id}");

            _db.AcademicYears.Remove(academicYear);
            _db.Entry(academicYear).State = EntityState.Deleted;
            var result = await _db.SaveChangesAsync();
            model = result > 0
                ? Result<object>.Success(null)
                : Result<object>.Error("Academic Year delete failed.");
        }
        catch (Exception ex)
        {
            model = Result<object>.Error(ex);
        }

        return model;
    }
}