using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BioKudi.dto;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class PlaceController : Controller
    {
        private readonly PlacesService placeService;
        private readonly StateService stateService;
        private readonly ActivityService activityService;

        public PlaceController(PlacesService placeService, StateService stateService, ActivityService activityService)
        {
            this.placeService = placeService;
            this.stateService = stateService;
            this.activityService = activityService;
        }

        // GET: PlaceController
        public ActionResult Index()
        {
            var places = placeService.GetAllPlaces() ?? new List<PlaceDto>();
            return View(places);
        }

        // GET: PlaceController/Details/5
        public ActionResult Details(int id)
        {
            var place = placeService.GetPlace(id);
            if(place == null)
                return RedirectToAction("Error", "Admin");
            return View(place);
        }

        // GET: PlaceController/Create
        public ActionResult Create()
        {
            var state = stateService.GetPlaceStates();
            var activity = activityService.GetAllActivities();
            ViewBag.States = state;
            ViewBag.Activities = activity;
            return View();
        }

        // POST: PlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaceDto place)
        {
            var result = placeService.CreatePlace(place);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: PlaceController/Edit/5
        public ActionResult Edit(int id)
        {
            var state = stateService.GetPlaceStates();
            var activity = activityService.GetAllActivities();
            var place = placeService.GetPlace(id);
            if (place == null)
                return RedirectToAction("Error", "Admin");
            ViewBag.States = state;
            ViewBag.Activities = activity;
            return View(place);
        }

        // POST: PlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlaceDto place)
        {
            var result = placeService.UpdatePlace(place);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: PlaceController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = placeService.DeletePlace(id);
            if (!result)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
            //return View();
        }

        // POST: PlaceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
