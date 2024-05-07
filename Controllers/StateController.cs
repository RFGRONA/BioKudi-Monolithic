using BioKudi.dto;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class StateController : Controller
    {
        private readonly StateService stateService;

        public StateController(StateService stateService)
        {
            this.stateService = stateService;
        }
        // GET: StateController
        public ActionResult Index()
        {
            var states = stateService.GetAllStates();
            return View(states);
        }

        // GET: StateController/Details/5
        public ActionResult Details(int id)
        {
            var state = stateService.GetState(id);
            return View(state);
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateDto state)
        {
            var result = stateService.Create(state);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: StateController/Edit/5
        public ActionResult Edit(int id)
        {
            var state = stateService.GetState(id);
            return View(state);
        }

        // POST: StateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StateDto state)
        {
            var result = stateService.Update(state);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: StateController/Delete/5
        public ActionResult Delete(int id)
        {
            var state = stateService.GetState(id);
            return View(state);
        }

        // POST: StateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var result = stateService.Delete(id);
            if (!result)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }
    }
}
