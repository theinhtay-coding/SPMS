using SPMS.Models.Grade;

namespace SPMS.Modules.Features.Grade;

public class DA_Grade
{
    private readonly AppDbContext _db;

    public DA_Grade(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<GradeListResponseModel>> GetGrades()
    {
        Result<GradeListResponseModel> model = null;

        try
        {
            var lstGrade = await _db.Grades.AsNoTracking().ToListAsync();
            if (!lstGrade.Any())
            {
                model = Result<GradeListResponseModel>.Success(new GradeListResponseModel
                {
                    Grades = new List<GradeModel>()
                });
                return model;
            }

            var grades = lstGrade.Select(grade => grade.Change()).ToList();
            var lstResponseModel = new GradeListResponseModel()
            {
                Grades = grades
            };
            model = Result<GradeListResponseModel>.Success(lstResponseModel);
        }
        catch (Exception ex)
        {
            model = Result<GradeListResponseModel>.Error(ex);
        }
        return model;
    }

    public async Task<Result<GradeResponseModel>> GetGradeById(int id)
    {
        Result<GradeResponseModel> model = null;
        try
        {
            var grade = await _db.Grades.SingleOrDefaultAsync(x => x.GradeId == id);
            if (grade is null)
            {
                model = Result<GradeResponseModel>.Error($"There is no grade record with id {id}");
                goto result;
            }

            var respModel = grade!.ChangeToResponseModel();

            model = Result<GradeResponseModel>.Success(respModel);
        }
        catch (Exception ex)
        {
            model = Result<GradeResponseModel>.Error(ex);
        }
    result:
        return model;
    }

    public async Task<Result<GradeResponseModel>> CreateGrade(GradeRequestModel requestModel)
    {
        Result<GradeResponseModel> model = null;

        try
        {
            if (requestModel == null)
                throw new ArgumentNullException(nameof(requestModel), "Request model cannot be null");

            var grade = requestModel.Change();
            await _db.Grades.AddAsync(grade);
            var result = _db.SaveChangesAsync();
            var respModel = grade.ChangeToResponseModel();

            model = result.Result > 0
                ? Result<GradeResponseModel>.Success(respModel)
                : Result<GradeResponseModel>.Error("Grade create failed.");
        }
        catch (Exception ex)
        {
            model = Result<GradeResponseModel>.Error(ex);
        }
        return model;
    }

    public async Task<Result<GradeResponseModel>> UpdateGrade(int id, GradeRequestModel requestModel)
    {
        Result<GradeResponseModel> model = null;
        try
        {
            if (requestModel == null)
                throw new ArgumentNullException(nameof(requestModel), "Request model cannot be null");

            var grade = await _db.Grades.AsNoTracking().FirstOrDefaultAsync(x => x.GradeId == id);
            if (grade is null)
            {
                return Result<GradeResponseModel>.Error($"There is no grade record with id {id}");
            }

            grade.GradeName = requestModel.GradeName;
            grade.PaymentAmount = requestModel.PaymentAmount;

            _db.Grades.Update(grade);
            var result = await _db.SaveChangesAsync();

            var respModel = grade.ChangeToResponseModel();
            model = result > 0
                ? Result<GradeResponseModel>.Success(respModel)
                : Result<GradeResponseModel>.Error("Grade update failed.");
        }
        catch (Exception ex)
        {
            model = Result<GradeResponseModel>.Error(ex.Message.ToString());
        }
        return model;
    }

    public async Task<Result<object>> DeleteGrade(int id)
    {
        Result<object> model = null;

        try
        {
            var grade = await _db.Grades.AsNoTracking().FirstOrDefaultAsync(x => x.GradeId == id);
            if (grade is null)
            {
                model = Result<object>.Error($"There is no grade record with id {id}");
            }
            _db.Grades.Remove(grade);
            _db.Entry(grade).State = EntityState.Deleted;
            var result = await _db.SaveChangesAsync();

            model = result > 0
                ? Result<object>.Success(null)
                : Result<object>.Error("Grade delete failed.");
        }
        catch (Exception ex)
        {
            model = Result<object>.Error(ex);
        }
        return model;
    }
}
