using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;

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
            if (state == null)
                return RedirectToAction("Error", "Admin");
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
            if (state == null)
                return RedirectToAction("Error", "Admin");
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

        // POST: StateController/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var state = stateService.Delete(id);
            if (!state)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }
    }
}
