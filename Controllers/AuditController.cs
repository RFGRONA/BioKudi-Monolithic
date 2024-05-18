using BioKudi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BioKudi.Services;
using Wkhtmltopdf.NetCore;
using BioKudi.dto;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "Admin")]
    public class AuditController : Controller
    {
        private readonly AuditService auditService;
        private readonly IGeneratePdf _generatePdf;

        public AuditController(AuditService auditService, IGeneratePdf generatePdf)
        {
            this.auditService = auditService;
            _generatePdf = generatePdf;
        }   
        public ActionResult Index()
        {
            var audits = auditService.GetAllAudits();
            return View(audits);
        }
        public ActionResult Report()
        {
            var report = auditService.GetAuditReport(HttpContext);
            if (report == null)
                return RedirectToAction("Error", "Admin");
            return View(report);
        }

        public async Task<IActionResult> PrintReport()
        {
            var reports = auditService.GetAuditReport(HttpContext);
            if (reports.Any())
            {
                var firstReport = reports.First();
                DateTime? timePrint = firstReport.TimePrint;
                string fileName = "ReporteAuditoria_" + timePrint?.ToString("yyyyMMdd_HHmmss") + ".pdf";

                var pdfBytes = await _generatePdf.GetByteArray("Views/Audit/Report.cshtml", reports);
                var pdfStream = new MemoryStream(pdfBytes);

                return new FileStreamResult(pdfStream, "application/pdf")
                {
                    FileDownloadName = fileName
                };
            }
            else
            {
                return Content("No hay informes disponibles.");
            }
        }
    }
}
