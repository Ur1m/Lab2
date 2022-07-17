using crypto;
using Google.Apis.Auth;
using IdentityAuthenticationService.Models;
using IdentityAuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
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


        [AllowAnonymous]
        [HttpPost("google")]
        public async Task<IActionResult> Google([FromBody] UserViewModel userView)
        {
            try
            {
                //SimpleLogger.Log("userView = " + userView.tokenId);
                var payload = GoogleJsonWebSignature.ValidateAsync(userView.TokenString, new GoogleJsonWebSignature.ValidationSettings()).Result;
                var user = await accountService.Authenticate(payload);
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
         .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/appsettings.json").Build();

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(String.Empty,
                  String.Empty,
                  expires: DateTime.Now.AddSeconds(55 * 60),
                  signingCredentials: creds);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest();
        }
    }
}
