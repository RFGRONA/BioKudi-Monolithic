using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class AuditDto
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string? ViewAction { get; set; }

        public string? Action { get; set; }
    }
}
