using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMS.Models.Grade;
using SPMS.Modules.Features.Grade;

namespace SPMS.BackendApi.Features.Grade;

[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly BL_Grade _blGrade;

    public GradeController(BL_Grade blGrade)
    {
        _blGrade = blGrade;
    }

    [HttpGet]
    public async Task<IActionResult> GetGrades()
    {
        try
        {
            var lstGrade = await _blGrade.GetGrades();
            return Ok(lstGrade);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGradeById(int id)
    {
        try
        {
            var respModel = await _blGrade.GetGradeById(id);
            return Ok(respModel);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateGrade(GradeRequestModel reqModel)
    {
        try
        {
            var respModel = await _blGrade.CreateGrade(reqModel);
            return Ok(respModel);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGrade(int id, GradeRequestModel reqModel)
    {
        var respModel = _blGrade.UpdateGrade(id, reqModel);
        return Ok(respModel);
    }

    [HttpDelete]
    public IActionResult DeleteGrade(int id)
    {
        _blGrade.DeleteGrade(id);
        return Ok();
    }
}