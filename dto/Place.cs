using System;
using System.Collections.Generic;

namespace BioKudi.dto;

public partial class Place
{
    public int PlaceId { get; set; }

    public string NamePlace { get; set; } = null!;

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public string Address { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Link { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
