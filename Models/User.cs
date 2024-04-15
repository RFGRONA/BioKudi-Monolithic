using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class User
{
    /// <summary>
    /// Unique identifier of the user (integer).
    /// </summary>
    public int IdUser { get; set; }

    /// <summary>
    /// Name of the user (character string, maximum 65).
    /// </summary>
    public string NameUser { get; set; } = null!;

    /// <summary>
    /// Email address of the user (character string, maximum 75).
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Password of the user (character string, maximum 128).
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// ID of the user&apos;s role (integer).
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// ID of the user&apos;s state (integer).
    /// </summary>
    public int StateId { get; set; }

    public string Key { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Role Role { get; set; } = null!;

    public virtual State State { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
