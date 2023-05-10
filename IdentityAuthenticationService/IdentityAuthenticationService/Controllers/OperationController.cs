using IdentityAuthenticationService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;
using IdentityAuthenticationService.Services.Interfaces;
using System.Linq;

namespace IdentityAuthenticationService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        #region Properties
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly IAccountService _accountService;
        #endregion

        #region Constructor
        public OperationsController(UserManager<ApplicationUser> userManager,
                                    RoleManager<ApplicationRole> roleManager, 
                                    IAccountService accountService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountService = accountService;
        }
        #endregion

        #region Actions

        [HttpPost("createUser")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            ApplicationUser appUser = new ApplicationUser
            {
                UserName = user.Name,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "User");
                return Ok(appUser);
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole([Required] string name)
        {
            var newRole = new ApplicationRole { Name = name };
            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            {
                return Ok(newRole.Name);
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }
        }

        #endregion
    }
}