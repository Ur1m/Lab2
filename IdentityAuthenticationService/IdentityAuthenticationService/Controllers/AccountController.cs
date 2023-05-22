using crypto;
using Google.Apis.Auth;
using IdentityAuthenticationService.Models;
using IdentityAuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
        #region Properties
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;
        #endregion 

        #region Constructor
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }
        #endregion

        #region Actions
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel user)
        {
            var appUser = await _userManager.FindByEmailAsync(user.Email);
          
            if (appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, user.Password, false, false);
             
                if (result.Succeeded)
                {
                    return Ok(appUser);
                }
            }

            return Unauthorized();
        }

        [HttpGet]
        public async Task<ActionResult<IdentityUser>> getCurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = HttpContext.User.Identity.Name;

                var returnuser = await _userManager.FindByNameAsync(user);
                
                if(returnuser != null)
                    return Ok(returnuser);
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = _signInManager.SignOutAsync();

            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var user = await _accountService.ForgotPassword(forgotPasswordViewModel);
           
            if (user != null)
            {
                var userVM = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                var tokenString = await _accountService.GenerateJWToken(user);
                
                if (!string.IsNullOrEmpty(tokenString))
                {
                    userVM.TokenString = tokenString;
                    return Ok(userVM);
                }
            }
            return Unauthorized();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel resetPasswordViewModel)
        {
            var user = await _accountService.ResetPassword(resetPasswordViewModel);
            
            if (user != null)
            {
                var userVM = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                var tokenString = await _accountService.GenerateJWToken(user);
               
                if (!string.IsNullOrEmpty(tokenString))
                {
                    userVM.TokenString = tokenString;
                    return Ok(userVM);
                }
            }

            return Unauthorized();
        }
        #endregion
    }
}
