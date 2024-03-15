using Microsoft.AspNetCore.Mvc;

namespace BioKudi.dto
{
    public class dto : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
