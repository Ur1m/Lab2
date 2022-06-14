﻿using IdentityAuthenticationService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;

namespace IdentityAuthenticationService.Controllers
{
    [RequireHttps]
    public class OperationsController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public OperationsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public ViewResult Create() => View();


        [HttpPost("Account/CreateUser")]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

                //Adding User to Admin Role
                await userManager.AddToRoleAsync(appUser, "Admin");

                if (result.Succeeded)
                    return Ok(appUser);
                else
                {
                    foreach (IdentityError error in result.Errors)
                        return Ok(new ErrorViewModel { RequestId = error.Code });
                }
            }
            return null;
        }

        [HttpPost("Account/CreateRole")]
        public async Task<IActionResult> CreateRole([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new ApplicationRole() { Name = name });
                if (result.Succeeded)
                    return Ok(name);
                else
                {
                    foreach (IdentityError error in result.Errors)
                        return Ok(new ErrorViewModel { RequestId  = error.Code});
                }
            }
            return null;
        }
    }
}