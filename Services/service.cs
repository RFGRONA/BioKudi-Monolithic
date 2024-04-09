using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Services
{
    public class Service : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
