using Microsoft.EntityFrameworkCore;
using SPMS.Database.Models;
using SPMS.Models.Student;
using SPMS.Mapper;
using SPMS.Models;
using SPMS.Models.Custom;
using System.Net.Sockets;

namespace SPMS.Modules.Features.Student;

public class DA_Student
{
    private readonly AppDbContext _db;

    public DA_Student(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<StudentListResponseModel>> GetStudents()
    {
        Result<StudentListResponseModel> model = null;

        try
        {
            var lstStudent = await _db.Students.AsNoTracking().ToListAsync();

            if (!lstStudent.Any())
            {
                // Return an empty result if no students exist
                model = Result<StudentListResponseModel>.Success(new StudentListResponseModel
                {
                    Students = new List<StudentModel>()
                });
                return model;
            }

            var students = lstStudent.Select(student => student.Change()).ToList();

            var listResponseModel = new StudentListResponseModel
            {
                Students = students,
            };

            model = Result<StudentListResponseModel>.Success(listResponseModel);
        }
        catch (Exception ex)
        {
            model = Result<StudentListResponseModel>.Error(ex);
        }

        return model;
    }

    public async Task<Result<StudentListResponseModel>> GetStudents(string? firstName, string? lastName, int pageNo, int pageSize)
    {
        Result<StudentListResponseModel> model = null;

        try
        {
            var query = _db.Students.AsNoTracking().AsQueryable();
            var totalCount = await query.CountAsync();

            // Apply filters based on provided parameters
            if (!string.IsNullOrEmpty(firstName)) query = query.Where(c => c.FirstName.Contains(firstName));
            if (!string.IsNullOrEmpty(lastName)) query = query.Where(c => c.LastName.Contains(lastName));

            var students = await query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();

            var pageCount = (int)Math.Ceiling((double)totalCount / pageSize);

            var studentListResponse = new StudentListResponseModel
            {
                Students = students.Select(student => student.Change()).ToList(),
                PageSetting = new PageSettingModel(pageNo, pageSize, pageCount, totalCount)
            };

            model = Result<StudentListResponseModel>.Success(studentListResponse);
        }
        catch (Exception ex)
        {
            model = Result<StudentListResponseModel>.Error(ex);
        }

        return model;
    }

    public async Task<Result<StudentResponseModel>> GetStudentById(int id)
    {
        Result<StudentResponseModel> model = null;
        try
        {
            var student = await _db.Students.AsNoTracking().SingleOrDefaultAsync(x => x.StudentId == id);
            if (student is null)
            {
                model = Result<StudentResponseModel>.Error($"There is no student record with id {id}");
                goto result;
            }
            var respModel = student!.ChangeToResponseModel();

            model = Result<StudentResponseModel>.Success(respModel);
        }
        catch (Exception ex)
        {
            model = Result<StudentResponseModel>.Error(ex);
        }
    result:
        return model;
    }

    public async Task<Result<StudentResponseModel>> CreateStudent(StudentRequestModel reqModel)
    {
        Result<StudentResponseModel> model = null;

        try
        {
            if (reqModel == null)
                throw new ArgumentNullException(nameof(reqModel), "Request model cannot be null");

            var student = reqModel.Change();
            await _db.Students.AddAsync(student);
            var result = await _db.SaveChangesAsync();
            var respModel = student.ChangeToResponseModel();

            model = result > 0
                ? Result<StudentResponseModel>.Success(respModel)
                : Result<StudentResponseModel>.Error("Client create failed.");
        }
        catch (Exception ex)
        {
            model = Result<StudentResponseModel>.Error(ex);
        }
        return model;
    }

    public async Task<Result<StudentResponseModel>> UpdateStudent(int id, StudentRequestModel reqModel)
    {
        Result<StudentResponseModel> model = null;
        try
        {
            if (reqModel == null)
                throw new ArgumentNullException(nameof(reqModel), "Request model cannot be null");

            var student = await _db.Students.AsNoTracking().FirstOrDefaultAsync(x => x.StudentId == id);
            if (student is null) return model = Result<StudentResponseModel>.Error($"Student Not Found with id {id}");

            if (!string.IsNullOrEmpty(reqModel.FirstName)) student.FirstName = reqModel.FirstName;
            if (!string.IsNullOrEmpty(reqModel.LastName)) student.LastName = reqModel.LastName;
            if (reqModel.GradeId > 0) student.GradeId = reqModel.GradeId;
            if (reqModel.CurrentYearId > 0) student.CurrentYearId = reqModel.CurrentYearId;
            if (reqModel.EnrollmentDate is DateOnly enrollmentDate && enrollmentDate != default)
            {
                student.EnrollmentDate = enrollmentDate;
            }
            if (reqModel.DateOfBirth is DateOnly dateOfBirth && dateOfBirth != default)
            {
                student.EnrollmentDate = dateOfBirth;
            }

            _db.Entry(student).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            var respModel = student.ChangeToResponseModel();

            model = Result<StudentResponseModel>.Success(respModel);
        }
        catch (Exception ex)
        {
            model = Result<StudentResponseModel>.Error(ex);
        }
        return model;
    }

    public async Task<Result<object>> DeleteStudent(int id)
    {
        Result<object> model = null;
        try
        {
            var student = await _db.Students.AsNoTracking().FirstOrDefaultAsync(x => x.StudentId == id);
            if (student is null) return model = Result<object>.Error($"Student Not Found with id {id}");

            _db.Students.Remove(student);
            _db.Entry(student).State = EntityState.Deleted;
            var result = await _db.SaveChangesAsync();
            model = result > 0
                ? Result<object>.Success(null)
                : Result<object>.Error("Delete failed.");
        }
        catch (Exception ex)
        {
            model = Result<object>.Error(ex);
        }

        return model;
    }
}
