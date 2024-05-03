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
    /// ID of the user associated with the ticket (integer).
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// ID of the state in which the ticket is located (integer).
    /// </summary>
    public int State { get; set; }

    public virtual State StateNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
