using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public string Type { get; set; } = null!;

    public string Affair { get; set; } = null!;

    public byte[] State { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
