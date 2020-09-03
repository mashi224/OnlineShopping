using AutumnStore.Business.Interfaces;
using AutumnStore.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AutumnStore.Controller
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManagement _paymentManagement;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentManagement paymentManagement, ILogger<PaymentController> logger)
        {
            _paymentManagement = paymentManagement;
            _logger = logger;
        }

        [HttpGet("billingUser/{userId}")]
        public async Task<IActionResult> GetBillingUser(int userId)
        {
            var currentUser = await _paymentManagement.GetBillingUser(userId);
            _logger.LogInformation("Get existing user details completed");
            //_logger.LogInformation(currentUser.UserName);
            return Ok(currentUser);
        }
    }
}