using IdentityAuthenticationService.Models;
using IdentityAuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IAccountService accountService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccountService accountService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([Required][EmailAddress] string email, [Required] string password)
        {
            ApplicationUser appUser = await userManager.FindByEmailAsync(email);
            if (appUser != null)
            {
                var result = await signInManager.PasswordSignInAsync(appUser, password, false, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            } 
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = signInManager.SignOutAsync().IsCompleted.ToString();
            return Ok(result);
        }

        [HttpPost("socialLogin")]
        public async Task<IActionResult> SocialLogin(SocialUserViewModel socialUsersViewModel)
        {
            var user = await accountService.SocialLogin(socialUsersViewModel);

            if (user != null)
            {
                var tokenString = await accountService.GenerateJWToken(user);
                if (tokenString != "")
                {
                    user.TokenString = tokenString;
                    return Ok(user);
                }
            }

            return Unauthorized();
        }
    }
}