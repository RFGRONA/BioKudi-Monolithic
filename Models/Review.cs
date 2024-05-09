using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Review
{
    /// <summary>
    /// Unique identifier of the review (integer).
    /// </summary>
    public int IdReview { get; set; }

    /// <summary>
    /// Rating of the review (float, precision of 2 digits).
    /// </summary>
    public float Rate { get; set; }

    /// <summary>
    /// Comment of the review (character string, maximum 255).
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// ID of the user who made the review (integer).
    /// </summary>
    public int UserId { get; set; }

    public int? PlaceId { get; set; }

    public virtual Place? Place { get; set; }

    public virtual User User { get; set; } = null!;
}
