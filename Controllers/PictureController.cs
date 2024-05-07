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
            PictureDto picture = pictureService.GetPicture(id);
            return View(picture);
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
            var result = pictureService.CreatePicture(picture);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: PictureController/Edit/5
        public ActionResult Edit(int id)
        {
            PictureDto picture = pictureService.GetPicture(id);
            var places = placeService.GetNameId();
            ViewBag.BagPlaces = places;
            return View(picture);
        }

        // POST: PictureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PictureDto picture)
        {
            var result = pictureService.UpdatePicture(picture);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: PictureController/Delete/5
        public ActionResult Delete(int id)
        {
            PictureDto picture = pictureService.GetPicture(id);
            return View(picture);
        }

        // POST: PictureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
                var result = pictureService.DeletePicture(id);
                if (!result)
                    return RedirectToAction("Error", "Admin");
                return RedirectToAction(nameof(Index));
        }
    }
}
