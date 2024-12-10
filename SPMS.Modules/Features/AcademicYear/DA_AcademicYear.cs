using SPMS.Database.Models;
using SPMS.Models.AcademicYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //return new AcademicYearListResponseModel();
        AcademicYearListResponseModel lst = new AcademicYearListResponseModel();
        var lstAcademicYear = _db.AcademicYears.ToList();
        //lst.DataList = lstAcademicYear;
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
