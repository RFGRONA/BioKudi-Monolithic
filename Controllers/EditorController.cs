using BioKudi.dto.ViewModel;
using BioKudi.dto;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Editor")]
    public class EditorController : Controller
    {
        private readonly ILogger<EditorController> _logger;
        private readonly UserService userService;
        public EditorController(ILogger<EditorController> logger, UserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public IActionResult IndexEditor(UserDto user)
        {
            user = userService.GetUser(user.UserId);
            if (user == null)
                return RedirectToAction("Error", "Editor");
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
