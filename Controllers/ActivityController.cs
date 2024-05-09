using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class ActivityController : Controller
    {
        private readonly ActivityService activityService;
        private readonly PlacesService placeService;

        public ActivityController(PlacesService placeService, ActivityService activityService)
        {
            this.activityService = activityService;
            this.placeService = placeService;
        }

        // GET: ActivityController
        public ActionResult Index()
        {
            var activities = activityService.GetAllActivities();
            if (activities == null)
                return RedirectToAction("Error", "Admin");
            return View(activities);
        }

        // GET: ActivityController/Details/5
        public ActionResult Details(int id)
        {
            var activity = activityService.GetActivity(id);
            if (activity == null)
                return RedirectToAction("Error", "Admin");
            return View(activity);
        }

        // GET: ActivityController/Create
        public ActionResult Create()
        {
            var places = placeService.GetNameId();
            ViewBag.BagPlaces = places;
            if (places == null)
                return RedirectToAction("Error", "Admin");
            return View();
        }

        // POST: ActivityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivityDto activity)
        {
            var result = activityService.CreateActivity(activity);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: ActivityController/Edit/5
        public ActionResult Edit(int id)
        {
            var activity = activityService.GetActivity(id);
            var places = placeService.GetNameId();
            ViewBag.BagPlaces = places;
            if (activity == null)
                return RedirectToAction("Error", "Admin");
            return View(activity);
        }

        // POST: ActivityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActivityDto activity)
        {
            var result = activityService.UpdateActivity(activity);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: ActivityController/Delete/5
        public ActionResult Delete(int id)
        {
            var activity = activityService.GetActivity(id);
            if (activity == null)
                return RedirectToAction("Error", "Admin");
            return View(activity);
        }

        // POST: ActivityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var result = activityService.DeleteActivity(id);
            if (!result)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }
    }
}
