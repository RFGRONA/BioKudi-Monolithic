using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto.ViewModel
{
    public class ReportAuditViewModel
    {
        [Key]
        public int AuditId { get; set; }

        public DateTime? Date { get; set; }

        public string? ViewAction { get; set; }

        public string? Action { get; set; }

        public string? UserName { get; set; }

        public DateTime? TimePrint { get; set; }
    }
}
