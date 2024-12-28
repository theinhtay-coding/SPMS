using Microsoft.AspNetCore.Mvc;
using SPMS.Models.AcademicYear;

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
        public IActionResult GetAcademicYears()
        {
            var lstAcademicYear = _blAcademicYear.GetAcademicYears();
            return Ok(lstAcademicYear);
        }

        [HttpGet("{id}")]
        public IActionResult GetAcademicYearById(int id)
        {
            var respModel = _blAcademicYear.GetAcademicYearById(id);
            return Ok(respModel);
        }

        [HttpPost]
        public IActionResult CreateAcademicYear(AcademicYearRequestModel reqModel)
        {
            var respModel = _blAcademicYear.CreateAcademicYear(reqModel);
            return Ok(respModel);
        }

        [HttpPut]
        public IActionResult UpdateAcademicYear(int id, AcademicYearRequestModel reqModel)
        {
            var respModel = _blAcademicYear.UpdateAcademicYear(id, reqModel);
            return Ok(respModel);
        }

        [HttpDelete]
        public IActionResult DeleteAcademicYear(int id)
        {
            _blAcademicYear.DeleteAcademicYear(id);
            return Ok();
        }
    }
}
