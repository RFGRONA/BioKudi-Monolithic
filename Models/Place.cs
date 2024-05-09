using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Place
{
    /// <summary>
    /// Unique identifier of the place (integer).
    /// </summary>
    public int IdPlace { get; set; }

    /// <summary>
    /// Name of the place (character string, maximum 80).
    /// </summary>
    public string NamePlace { get; set; } = null!;

    /// <summary>
    /// Latitude of the place (character string, maximum 20 digits).
    /// </summary>
    public string? Latitude { get; set; }

    /// <summary>
    /// Longitude of the place (character string, maximum 20 digits).
    /// </summary>
    public string? Longitude { get; set; }

    /// <summary>
    /// Address of the place (character string, maximum 128).
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Description of the place (character string, maximum 560).
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Link related to the place (character string, maximum 255).
    /// </summary>
    public string Link { get; set; } = null!;

    /// <summary>
    /// ID of the state to which the place belongs (integer).
    /// </summary>
    public int? StateId { get; set; }

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual State? State { get; set; }

    public virtual ICollection<Activity> IdActivities { get; set; } = new List<Activity>();
}
