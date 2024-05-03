using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class PictureController : Controller
    {
        private readonly PictureService pictureService;
        private readonly PlacesService placeService;

        public PictureController(PlacesService placeService, PictureService pictureService)
        {
            this.placeService = placeService;
            this.pictureService = pictureService;
        }

        // GET: PictureController
        public ActionResult Index()
        {
            return View(pictureService.GetAllPictures());
        }

        // GET: PictureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PictureController/Create
        public ActionResult Create()
        {
            var places = placeService.GetNameId();
            ViewBag.BagPlaces = places;
            return View();
        }

        // POST: PictureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PictureDto picture)
        {
            try
            {
                pictureService.CreatePicture(picture);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PictureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PictureController/Edit/5
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

        // GET: PictureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PictureController/Delete/5
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
