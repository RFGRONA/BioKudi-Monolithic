using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Role
{
    /// <summary>
    /// Unique identifier of the role (integer).
    /// </summary>
    public int IdRole { get; set; }

    /// <summary>
    /// Name of the role (character string, maximum 50).
    /// </summary>
    public string NameRole { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
