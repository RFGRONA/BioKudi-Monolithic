using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class PlaceController : Controller
    {
        private readonly PlacesService placeService;

        public PlaceController(PlacesService placeService)
        {
            this.placeService = placeService;
        }

        // GET: PlaceController
        public ActionResult Index()
        {
            var places = placeService.GetAllPlaces();
            return View(places);
        }

        // GET: PlaceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlaceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PlaceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PlaceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
