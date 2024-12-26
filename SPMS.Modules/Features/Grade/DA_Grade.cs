using Microsoft.EntityFrameworkCore;
using SPMS.Database.Models;
using SPMS.Mapper;
using SPMS.Models;
using SPMS.Models.Grade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public GradeResponseModel UpdateGrade(int id, GradeRequestModel requestModel)
    {
        GradeResponseModel respModel = new GradeResponseModel();
        return respModel;
    }

    public void DeleteGrade(int id)
    {

    }
}
