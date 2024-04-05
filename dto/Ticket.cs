using System;
using System.Collections.Generic;

namespace BioKudi.dto;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Type { get; set; } = null!;

    public string Affair { get; set; } = null!;

    public byte[] State { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
