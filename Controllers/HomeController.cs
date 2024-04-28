using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using BioKudi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BioKudi.Utilities;
using System.Security.Claims;

namespace BioKudi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService userService;

        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

		[ValidateLogin]
		public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

		[ValidateLogin]
		public IActionResult Login()
        {
			UserDto user = new UserDto();
			return View(user);
			
		}

		public IActionResult Register()
		{
			UserDto user = new UserDto();
			return View(user);
		}

		public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                var result = userService.LoginUser(user, ModelState);
                if (result == null)
                    return View(user);
                UserService.AuthUser(HttpContext, user);
                if (result.RoleName == "User") // User
                    return RedirectToAction("IndexUser", "User", new { userId = user.UserId });
                if (result.RoleName == "Admin") // Admin
                    return RedirectToAction("IndexAdmin", "Admin", new { userId = user.UserId });
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Register(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                var result = userService.RegisterUser(user, ModelState);
                if (result != null)
                    return RedirectToAction("Login", "Home");
            }
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}