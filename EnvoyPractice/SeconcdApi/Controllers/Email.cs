using Microsoft.AspNetCore.Mvc;
using SeconcdApi.Dtos;
using SeconcdApi.Services.Interfaces;

namespace SeconcdApi.Controllers
{
    [Route("email")]
    [ApiController]
    public class Email : ControllerBase
    {
        private readonly IEmailService _emailService;

        public Email(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(RequestDto request)
        {
            var response = await _emailService.SendEmail(request);
            return Ok(response);
        }
    }
}
