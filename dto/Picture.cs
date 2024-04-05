using System;
using System.Collections.Generic;

namespace BioKudi.dto;

public partial class Picture
{
    public int PictureId { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
