using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Picture
{
    /// <summary>
    /// Unique identifier of the picture (integer).
    /// </summary>
    public int IdPicture { get; set; }

    /// <summary>
    /// Name of the picture (character string, maximum 128).
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Link of the picture (character string, maximum 255).
    /// </summary>
    public string Link { get; set; } = null!;

    /// <summary>
    /// Identifier of the place to which the picture belongs (integer).
    /// </summary>
    public int? PlaceId { get; set; }

    public virtual Place? Place { get; set; }
}
