using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserService userService;
        private readonly StateService stateService;
        private readonly RoleService roleService;

        public AccountController(UserService userService, StateService stateService, RoleService roleService)
        {
            this.userService = userService;
            this.stateService = stateService;
            this.roleService = roleService;
        }

        // GET: AccountController
        public ActionResult Index()
        {
            var users = userService.GetAllUsers() ?? new List<UserDto>();
            return View(users);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            var user = userService.GetUser(id);
            if (user == null)
                return RedirectToAction("Error", "Admin");
            return View(user);
        } 

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userService.GetUser(id);
            if (user == null)
                return RedirectToAction("Error", "Admin");
            var states = stateService.GetUserStates();
            var roles = roleService.GetRoles();
            ViewBag.BagStates = states;
            ViewBag.BagRoles = roles;
            return View(user);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDto user)
        {
            var result = userService.UpdateUser(user);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
            
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userService.GetUser(id);
            if (user == null)
                return RedirectToAction("Error", "Admin");
            return View(user);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var result = userService.DeleteUser(id);
            if (!result)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }
    }
}
