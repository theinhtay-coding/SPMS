using Microsoft.AspNetCore.Mvc;
using SPMS.Models.Promotion;

namespace SPMS.BackendApi.Features.Promotion
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly BL_Promotion _blPromotoin;

        public PromotionController(BL_Promotion blPromotoin)
        {
            _blPromotoin = blPromotoin;
        }

        [HttpGet]
        public IActionResult GetPromotions(int id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPromotionById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatePromotion(PromotionRequestModel reqModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePromotion(int id, PromotionRequestModel reqModel)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult actionResult(int id)
        {
            return Ok();
        }
    }
}
