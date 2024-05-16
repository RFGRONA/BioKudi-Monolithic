using BioKudi.dto;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Controllers
{
    public class MapController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService userService;
        private readonly MapService mapService;
        private readonly PlacesService placeService;
        private readonly TicketService ticketService;
        public MapController(ILogger<HomeController> logger, UserService userService, MapService mapService, PlacesService placesService, TicketService ticketService)
        {
            _logger = logger;
            this.userService = userService;
            this.mapService = mapService;
            this.placeService = placesService;
            this.ticketService = ticketService;
        }

        public IActionResult Activities()
        {
            var places = placeService.GetAllPlaces();
            if (places == null)
                return RedirectToAction("Error", "Home");
            return View(places);
        }

        public IActionResult PublicMap()
        {
            var markers = mapService.GetMarkers();
            if (markers == null)
                return RedirectToAction("Error", "Home");
            return View(markers);
        }

        [ValidateAuthentication]
        public IActionResult UserMap()
        {
            var markers = mapService.GetMarkers();
            if (markers == null)
                return RedirectToAction("Error", "Home");
            return View(markers);
        }
        public ContentResult InfoMap(int idPlace)
        {
            return mapService.GetInfoPlace(idPlace);
        }
        public ContentResult ReviewsPlace(int idPlace)
        {
            return mapService.GetReviews(idPlace);
        }

        [ValidateAuthentication]
        public ContentResult InfoMapUser(int idPlace)
        {
            return mapService.GetInfoPlace(idPlace, HttpContext);
        }

        [ValidateAuthentication]
        public ContentResult Reviews(int idPlace, int idUser)
        {
            return mapService.GetReviews(idPlace, idUser);
        }

        [ValidateAuthentication]
        public ContentResult CreateReview(int idPlace)
        {
            return mapService.CreateReviewForm(idPlace);
        }

        [HttpPost]
        [ValidateAuthentication]
        public void CreateReview(ReviewDto review)
        {
            mapService.CreateReview(review, HttpContext);
        }

        [ValidateAuthentication]
        public ContentResult UpdateReview(int idReview)
        {
            return mapService.UpdateReviewForm(idReview);
        }

        [HttpPost]
        [ValidateAuthentication]
        public void UpdateReview(ReviewDto review)
        {
            mapService.UpdateReview(review);
        }

        [HttpPost]
        [ValidateAuthentication]
        public void DeleteReview(int idReview)
        {
            mapService.DeleteReview(idReview);
        }
    }
}
