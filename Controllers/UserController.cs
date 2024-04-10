using Microsoft.AspNetCore.Mvc;
using BioKudi.Models;
namespace BioKudi.Controllers
{
    public class UserController : Controller
	{
		private readonly ILogger<UserController> _logger;


		public UserController(ILogger<UserController> logger)
		{
			_logger = logger;
		}

		
		

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}