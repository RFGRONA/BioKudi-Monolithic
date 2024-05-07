using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BioKudi.Services;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class AuditController : Controller
    {
        private readonly AuditService auditService;

        public AuditController(AuditService auditService)
        {
            this.auditService = auditService;
        }
        public ActionResult Index()
        {
            var audits = auditService.GetAllAudits();

            return View(audits);
        }
    }
}
