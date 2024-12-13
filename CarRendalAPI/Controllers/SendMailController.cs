using CarRendalAPI.Models;
using CarRendalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController(SendmailService _sendmailService) : ControllerBase
    {
        [HttpPost("Send-Mail")]
        public async Task<IActionResult> Sendmail(SendMailRequest sendMailRequest)
        {
            var res = await _sendmailService.Sendmail(sendMailRequest).ConfigureAwait(false);
            return Ok(res);
        }


    }

}
