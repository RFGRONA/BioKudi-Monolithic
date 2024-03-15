using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Repository
{
    public class dbRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
