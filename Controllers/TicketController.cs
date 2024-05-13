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
    public class TicketController : Controller
    {
        private readonly TicketService ticketService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly StateService stateService;
        public TicketController(TicketService ticketService, StateService stateService, IHttpContextAccessor httpContextAccessor)
        {
            this.ticketService = ticketService;
            this.httpContextAccessor = httpContextAccessor;
            this.stateService = stateService;
        }

        // GET: TicketController
        public ActionResult Index()
        {
            var tickets = ticketService.GetAllTickets();
            return View(tickets);
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            var ticket = ticketService.GetTicket(id);
            if (ticket == null)
                return RedirectToAction("Error", "Admin");
            return View();
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int id)
        {
            var ticket = ticketService.GetTicket(id);
            var states = stateService.GetTicketStates();
            ViewBag.States = states;
            if (ticket == null)
                return RedirectToAction("Error", "Admin");
            return View(ticket);
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketDto ticket)
        {
            var result = ticketService.UpdateTicket(ticket);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int id)
        {
            var ticket = ticketService.GetTicket(id);
            if (ticket == null)
                return RedirectToAction("Error", "Admin");
            return View(ticket);
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var result = ticketService.DeleteTicket(id);
            if (!result)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }
    }
}
