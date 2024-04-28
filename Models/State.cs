using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class State
{
    /// <summary>
    /// Unique identifier of the state (integer).
    /// </summary>
    public int IdState { get; set; }

    /// <summary>
    /// Name of the state (character string, maximum 30).
    /// </summary>
    public string? NameState { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
