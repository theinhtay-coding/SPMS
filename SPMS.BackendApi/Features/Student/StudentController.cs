using Microsoft.AspNetCore.Mvc;
using SPMS.Models.Student;

namespace SPMS.BackendApi.Features.Student
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class StudentController : BaseController
    {
        private readonly BL_Student _blStudent;

        public StudentController(BL_Student blStudent)
        {
            _blStudent = blStudent;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var lstStudent = await _blStudent.GetStudents();
                return Ok(lstStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public async Task<IActionResult> GetStudents(string? firstName, string? lastName, int pageNo = 1, int pageSize = 10)
        {
            try
            {
                var lstStudent = await _blStudent.GetStudents(firstName, lastName, pageNo, pageSize);
                return Ok(lstStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var respModel = await _blStudent.GetStudentById(id);
                return Ok(respModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(StudentRequestModel requestModel)
        {
            try
            {
                var respModel = await _blStudent.CreateStudent(requestModel);
                return Ok(respModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateClient(int id, StudentRequestModel requestModel)
        {
            try
            {
                var respModel = await _blStudent.UpdateStudent(id, requestModel);
                return Ok(respModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientAsync(int id)
        {
            try
            {
                var response = await _blStudent.DeleteStudent(id);
                if (response.IsError) return BadRequest(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
