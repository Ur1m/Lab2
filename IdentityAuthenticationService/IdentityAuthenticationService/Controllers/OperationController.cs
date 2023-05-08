using IdentityAuthenticationService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;
using IdentityAuthenticationService.Services.Interfaces;

namespace IdentityAuthenticationService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        private readonly IAccountService accountService;

        public OperationsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IAccountService accountService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.accountService = accountService;
        }


        [HttpPost("createUser")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            ApplicationUser appUser = new ApplicationUser
            {
                UserName = user.Name,
                Email = user.Email
            };

            IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

            //Adding User to User Role
            await userManager.AddToRoleAsync(appUser, "User");

            if (result.Succeeded)
                return Ok(appUser);
            else
                return BadRequest(result.Errors);
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole([Required] string name)
        {
            IdentityResult result = await roleManager.CreateAsync(new ApplicationRole() { Name = name });
            if (result.Succeeded)
               return Ok(name);
            else
               return BadRequest(result.Errors);
        }
    }
}