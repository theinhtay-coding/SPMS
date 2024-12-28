using Microsoft.AspNetCore.Mvc;
using SPMS.Models.Payment;

namespace SPMS.BackendApi.Features.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly BL_Payment _blPayment;

        public PaymentController(BL_Payment blPayment)
        {
            _blPayment = blPayment;
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            var lstPayment = _blPayment.GetPayments();
            return Ok(lstPayment);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var respModel = _blPayment.GetPaymentById(id);
            return Ok(respModel);
        }

        [HttpPost]
        public IActionResult CreatePayment(PaymentRequestModel reqModel)
        {
            var respModel = _blPayment.CreatePayment(reqModel);
            return Ok(respModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, PaymentRequestModel reqModel)
        {
            var respModel = _blPayment.UpdatePayment(id, reqModel);
            return Ok(respModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            _blPayment.DeletePayment(id);
            return Ok();
        }
    }
}