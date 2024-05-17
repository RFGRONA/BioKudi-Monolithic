using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin,Editor")]
    public class ReviewController : Controller
    {
        private readonly ReviewService reviewService;
        private readonly PlacesService placeService;

        public ReviewController(PlacesService placeService, ReviewService reviewService)
        {
            this.placeService = placeService;
            this.reviewService = reviewService;
        }

        // GET: ReviewController
        public ActionResult Index()
        {
            var reviews = reviewService.GetAllReviews();
            if (reviews == null)
                return RedirectToAction("Error", "Admin");
            return View(reviews);
        }

        // POST: ReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
                var review = reviewService.DeleteReview(id);
                if (!review)
                    RedirectToAction("Error", "Admin");
                return RedirectToAction(nameof(Index));
        }
    }
}
