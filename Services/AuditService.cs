using BioKudi.dto;
using BioKudi.dto.ViewModel;
using BioKudi.Repository;

namespace BioKudi.Services
{
    public class AuditService
    {
        private readonly AuditRepository auditRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuditService(AuditRepository auditRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.auditRepo = auditRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<AuditDto> GetAllAudits()
        {
            return auditRepo.GetListAudit();
        }

        public IEnumerable<ReportAuditViewModel> GetAuditReport(HttpContext httpContext)
        {
            var report = auditRepo.GetAuditReport();
            var userName = httpContext.User.Identity.Name;
            TimeZoneInfo timeZoneColombia = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTimeOffset dateTimeColombia = DateTimeOffset.Now.ToOffset(timeZoneColombia.GetUtcOffset(DateTime.Now));
            if (report.Any())
            {
                var firstReport = report.First();
                firstReport.TimePrint = dateTimeColombia.DateTime;
                firstReport.UserName = userName;
            }
            return report;
        }
    }
}
