using SPMS.Database.Models;
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

    public GradeListResponseModel GetGrades()
    {
        GradeListResponseModel lstGrade = new GradeListResponseModel();
        return lstGrade;
    }

    public GradeResponseModel GetGradeById(int id)
    {
        GradeResponseModel responseModel = new GradeResponseModel();
        return responseModel;
    }

    public GradeResponseModel CreateGrade(GradeRequestModel requestModel)
    {
        GradeResponseModel respModel = new GradeResponseModel();
        return respModel;
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
