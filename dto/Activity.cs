using System;
using System.Collections.Generic;

namespace BioKudi.dto;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
