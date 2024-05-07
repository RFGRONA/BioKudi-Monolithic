using BioKudi.dto;
using BioKudi.dto.ViewModel;
using BioKudi.Models;

namespace BioKudi.Repository
{
    public class AuditRepository
    {
        private readonly BiokudiDbContext _context;
        public AuditRepository(BiokudiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AuditDto> GetListAudit()
        {
            return _context.Audits.Select(a => new AuditDto
            {
                AuditId = a.IdAudit,
                Action = a.Action,
                Date = a.Date,
                ViewAction = a.ViewAction
            }).ToList();
        }

        public IEnumerable<ReportAuditViewModel> GetAuditReport()
        {
            return _context.Audits.Select(a => new ReportAuditViewModel
            {
                AuditId = a.IdAudit,
                Action = a.Action,
                Date = a.Date,
                ViewAction = a.ViewAction
            }).ToList();
        }

    }
}
