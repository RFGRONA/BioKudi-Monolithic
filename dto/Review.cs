using System;
using System.Collections.Generic;

namespace BioKudi.dto;

public partial class Review
{
    public int ReviewId { get; set; }

    public float Rate { get; set; }

    public string? Comment { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
