using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Services
{
    public class service : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
