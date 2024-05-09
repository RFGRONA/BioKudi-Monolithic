using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BioKudi.Services;
using Rotativa.AspNetCore;

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
            var audits = auditService.GetAllAudits() ?? new List<AuditDto>();
            return View(audits);
        }
        public ActionResult Report()
        {
            var report = auditService.GetAuditReport(HttpContext);
            if (report == null)
                return RedirectToAction("Error", "Admin");
            return View(report);
        }

        public IActionResult PrintReport()
        {
            var reports = auditService.GetAuditReport(HttpContext);
            if (reports.Any())
            {
                var firstReport = reports.First();
                DateTime? timePrint = firstReport.TimePrint;
                string fileName = "ReporteAuditoria_" + timePrint?.ToString("yyyyMMdd_HHmmss") + ".pdf";
                return new ViewAsPdf("Report", reports) { FileName = fileName };
            }
            else
            {
                return Content("No hay informes disponibles.");
            }
        }
    }
}
