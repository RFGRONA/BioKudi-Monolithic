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
    public class RoleController : Controller
    {
        private readonly RoleService roleService;

        public RoleController(RoleService roleService)
        {
            this.roleService = roleService;
        }

        // GET: RoleController
        public ActionResult Index()
        {
            var roles = roleService.GetRoles();
            return View(roles);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            var role = roleService.GetRole(id);
            if (role == null)
                return RedirectToAction("Error", "Admin");
            return View(role);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleDto role)
        {
            var result = roleService.CreateRole(role);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            var role = roleService.GetRole(id);
            if (role == null)
                return RedirectToAction("Error", "Admin");
            return View(role);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleDto role)
        {
            var result = roleService.UpdateRole(role);
            if (result == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var role = roleService.DeleteRole(id);
            if (!role)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction(nameof(Index));
        }
    }
}
