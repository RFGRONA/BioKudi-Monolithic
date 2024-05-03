using BioKudi.dto;
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
                Date = a.Date
            }).ToList();
        }
    }
}
