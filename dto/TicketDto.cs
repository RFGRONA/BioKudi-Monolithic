using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class TicketDto
    {
        [Key]
        public int IdTicket { get; set; }
        public string Type { get; set; } = null!;
        public string Affair { get; set; } = null!;
        public int UserId { get; set; }
        public int State { get; set; }
		public string StateName { get; set; } = null!;
	}
}
