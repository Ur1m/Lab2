using IdentityAuthenticationService.Models;
using IdentityAuthenticationService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailController : ControllerBase
    {
        #region Properties
        private readonly IMailService _mailService;
        #endregion

        #region Constructor
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }
        #endregion

        #region Actions

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeMail([FromForm] WelcomeRequest request)
        {
            try
            {
                await _mailService.SendWelcomeEmailAsync(request);

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
