using SPMS.Models;
using SPMS.Models.Student;

namespace SPMS.Modules.Features.Student;

public class BL_Student
{
    private readonly DA_Student _daStudent;

    public BL_Student(DA_Student daStudent)
    {
        _daStudent = daStudent;
    }

    public async Task<Result<StudentListResponseModel>> GetStudents()
    {
        var lstStudent = await _daStudent.GetStudents();
        return lstStudent;
    }

    public async Task<Result<StudentListResponseModel>> GetStudents(string? firstName, string? lastName, int pageNo, int pageSize)
    {
        if(pageNo < 1 || pageSize < 1)
        {
            throw new Exception("PageNo or PageSize cannot be less than 1");
        }
        var response = await _daStudent.GetStudents(firstName, lastName, pageNo, pageSize);
        return response;
    }

    public async Task<Result<StudentResponseModel>> GetStudentById(int id)
    {
        var respModel = await _daStudent.GetStudentById(id);
        return respModel;
    }

    public async Task<Result<StudentResponseModel>> CreateStudent(StudentRequestModel requestModel)
    {
        if(requestModel is null)
        {
            throw new Exception("Request model is null");
        }
        var respModel = await _daStudent.CreateStudent(requestModel);
        return respModel;
    }

    public async Task<Result<StudentResponseModel>> UpdateStudent(int id, StudentRequestModel requestModel)
    {
        if (id <= 0) throw new Exception("id is null");
        var respModel = await _daStudent.UpdateStudent(id, requestModel);
        return respModel;
    }

    public async Task<Result<object>> DeleteStudent(int id)
    {
        if (id <= 0) throw new Exception("id less than 0");
        var respModel = await _daStudent.DeleteStudent(id);
        return respModel;
    }
}
