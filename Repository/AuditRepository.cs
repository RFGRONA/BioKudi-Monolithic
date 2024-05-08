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
            try
            {
                return _context.Audits.Select(a => new AuditDto
                {
                    AuditId = a.IdAudit,
                    Action = a.Action,
                    Date = a.Date,
                    ViewAction = a.ViewAction
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<ReportAuditViewModel> GetAuditReport()
        {
            try
            {
                return _context.Audits.Select(a => new ReportAuditViewModel
                {
                    AuditId = a.IdAudit,
                    Action = a.Action,
                    Date = a.Date,
                    ViewAction = a.ViewAction
                }).OrderByDescending(a => a.Date).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
