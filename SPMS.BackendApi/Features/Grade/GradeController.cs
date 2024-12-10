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
    public IActionResult GetGrades()
    {
        var lstGrade = _blGrade.GetGrades();
        return Ok(lstGrade);
    }

    [HttpGet("{id}")]
    public IActionResult GetGradeById(int id)
    {
        var respModel = _blGrade.GetGradeById(id);
        return Ok(respModel);
    }

    [HttpPost]
    public IActionResult CreateGrade(GradeRequestModel reqModel)
    {
        var respModel = _blGrade.CreateGrade(reqModel);
        return Ok(respModel);
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