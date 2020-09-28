using AutumnStore.Business.Interfaces;
using AutumnStore.Entity;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using VisioForge.Shared.MediaFoundation.OPM;

namespace AutumnStore.Controller
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManagement _paymentManagement;
        private readonly ILogger<PaymentController> _logger;
        private readonly IEmailSender _emailSender;

        public PaymentController(IPaymentManagement paymentManagement, ILogger<PaymentController> logger, IEmailSender emailSender)
        {
            _paymentManagement = paymentManagement;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpGet("billingUser/{userId}")]
        public async Task<IActionResult> GetBillingUser(int userId)
        {
            var currentUser = await _paymentManagement.GetBillingUser(userId);
            _logger.LogInformation("Get existing user details completed");

            return Ok(currentUser);
        }

        [HttpPost("completePayment")]
        public async Task<IActionResult> CompletePayment(OrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                var orderHistory = await _paymentManagement.CompletePayment(orderDto);

                if (orderHistory != null)
                    return Ok(orderHistory);

                else
                    return BadRequest("Internal server error");
            }
            else
                return BadRequest("Internal server error");

        }

    }
}
