using System;
using System.Collections.Generic;
using BioKudi.dto;

namespace BioKudi.Models;

public partial class Place
{
    public int IdPlace { get; set; }

    public string NamePlace { get; set; } = null!;

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public string Address { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Link { get; set; } = null!;

    public int? StateId { get; set; }

    public virtual State? State { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
