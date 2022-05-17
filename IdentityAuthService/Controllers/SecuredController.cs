﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAuthService.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SecuredController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}