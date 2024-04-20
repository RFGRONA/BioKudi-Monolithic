using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using BioKudi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

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
                if (result.RoleId == (int)UserRole.User) // User
                    return RedirectToAction("IndexUser", "User", new { userId = user.UserId });
                if (result.RoleId == (int)UserRole.Admin) // Admin
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
                    return RedirectToAction("IndexUser", "User", new { userId = user.UserId });
            }
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ViewResult)
            {
                context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.HttpContext.Response.Headers["Pragma"] = "no-cache";
                context.HttpContext.Response.Headers["Expires"] = "-1";
            }

            base.OnActionExecuted(context);
        }
    }
}