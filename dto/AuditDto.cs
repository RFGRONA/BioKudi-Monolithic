namespace BioKudi.dto
{
    public class AuditDto
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string? ViewAction { get; set; }

        public string? Action { get; set; }
    }
}
