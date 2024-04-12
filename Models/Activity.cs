using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Activity
{
    /// <summary>
    /// Unique identifier of the activity (integer).
    /// </summary>
    public int IdActivity { get; set; }

    /// <summary>
    /// Type of activity (character string, maximum 128).
    /// </summary>
    public string Type { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
