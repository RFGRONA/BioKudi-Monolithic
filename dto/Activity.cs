using System;
using System.Collections.Generic;
using BioKudi.Models;

namespace BioKudi.dto;

public partial class Activity
{
    public int IdActivity { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
