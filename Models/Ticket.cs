using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Ticket
{
    /// <summary>
    /// Unique identifier of the ticket (integer).
    /// </summary>
    public int IdTicket { get; set; }

    /// <summary>
    /// Type of ticket (character string, maximum 50).
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Subject of the ticket (character string, maximum 1024).
    /// </summary>
    public string Affair { get; set; } = null!;

    /// <summary>
    /// State of the ticket (binary, single character).
    /// </summary>
    public byte[] State { get; set; } = null!;

    /// <summary>
    /// ID of the user associated with the ticket (integer).
    /// </summary>
    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
