using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using BioKudi.Services;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Login()
        {
			UserDto user = new UserDto();
			return View(user);
        }

        [HttpPost]
        public IActionResult Login(UserDto user)
        {
            if (!ModelState.IsValid)
            {
				var result = userService.LoginUser(user, ModelState);
				if (result != null)
                {
					return RedirectToAction("IndexUser", "User", user);
				}
			}
			return View(user);
		}

        public IActionResult Register()
        {
            UserDto user = new UserDto();
            return View(user);
        }

		[HttpPost]
		public IActionResult Register(UserDto user)
		{
			if (!ModelState.IsValid)
			{
                var result = userService.RegisterUser(user, ModelState);
                if (result != null)
				{
					return RedirectToAction("IndexUser", "User", user);
				}
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
