using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Picture
{
    public int IdPicture { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
