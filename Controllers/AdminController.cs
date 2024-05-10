using BioKudi.dto;
using BioKudi.dto.ViewModel;
using BioKudi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BioKudi.Utilities;

namespace BioKudi.Controllers
{
	[ValidateAuthentication]
	[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
		private readonly UserService userService;
        private readonly MapService mapService;
        private readonly PlacesService placeService;
        public AdminController(ILogger<AdminController> logger, UserService userService, MapService mapService, PlacesService placeService)
        {
            _logger = logger;
            this.userService = userService;
            this.mapService = mapService;
            this.placeService = placeService;
        }

        public IActionResult IndexAdmin(UserDto user)
        {
			user = userService.GetUser(user.UserId);
            if (user == null)
                return RedirectToAction("Error", "Admin");
            return View(user);
        }

        public IActionResult Map()
        {
            var markers = mapService.GetMarkers();
            if (markers == null)
                return RedirectToAction("Error", "Admin");
            return View(markers);
        }

        public IActionResult Activities()
        {
            var places = placeService.GetAllPlaces();
            if (places == null)
                return RedirectToAction("Error", "Admin");
            return View(places);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
