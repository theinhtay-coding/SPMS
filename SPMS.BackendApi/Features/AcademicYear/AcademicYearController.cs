using Microsoft.AspNetCore.Mvc;
using SPMS.Models.AcademicYear;
using SPMS.Modules.Features.Student;

namespace SPMS.BackendApi.Features.AcademicYear
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicYearController : ControllerBase
    {
        private readonly BL_AcademicYear _blAcademicYear;

        public AcademicYearController(BL_AcademicYear blAcademicYear)
        {
            _blAcademicYear = blAcademicYear;
        }

        [HttpGet]
        public async Task<IActionResult> GetAcademicYears()
        {
            try
            {
                var lstAcademicYear = await _blAcademicYear.GetAcademicYears();
                return Ok(lstAcademicYear);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcademicYearById(int id)
        {
            try
            {
                var respModel = await _blAcademicYear.GetAcademicYearById(id);
                return Ok(respModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAcademicYear(AcademicYearRequestModel reqModel)
        {
            var respModel = await _blAcademicYear.CreateAcademicYear(reqModel);
            return Ok(respModel);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAcademicYear(int id, AcademicYearRequestModel reqModel)
        {
            try
            {
                var respModel = await _blAcademicYear.UpdateAcademicYear(id, reqModel);
                return Ok(respModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAcademicYear(int id)
        {
            try
            {
                var response = await _blAcademicYear.DeleteAcademicYear(id);
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
