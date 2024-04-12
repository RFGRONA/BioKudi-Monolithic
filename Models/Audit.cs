using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Audit
{
    /// <summary>
    /// Unique identifier of the audit (integer).
    /// </summary>
    public int IdAudit { get; set; }

    /// <summary>
    /// Date of the audit (date).
    /// </summary>
    public DateOnly? Date { get; set; }

    /// <summary>
    /// Action of viewing performed (character string, maximum 50).
    /// </summary>
    public string ViewAction { get; set; } = null!;

    /// <summary>
    /// Action performed (integer).
    /// </summary>
    public int Action { get; set; }
}
