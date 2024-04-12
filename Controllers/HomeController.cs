using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using Microsoft.AspNetCore.Mvc;
namespace BioKudi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            if (ModelState.IsValid)
            {
				var userRepo = new UserRepository(new BiokudiDbContext());
				var result = userRepo.login(user, ModelState);
				if (result != null)
                {
					return RedirectToAction("IndexUser", "User");
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
			if (ModelState.IsValid)
			{
				var userRepo = new UserRepository(new BiokudiDbContext());
				var result = userRepo.Create(user, ModelState);
				if (result != null)
				{
					return RedirectToAction("IndexUser", "User");
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
