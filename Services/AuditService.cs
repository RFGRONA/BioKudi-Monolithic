using BioKudi.dto;
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
    }
}
