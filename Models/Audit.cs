using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Audit
{
    /// <summary>
    /// Unique identifier of audit (integer).
    /// </summary>
    public int IdAudit { get; set; }

    /// <summary>
    /// Date the audit was done (date).
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Table in which some modification was made (character string, maximum 500).
    /// </summary>
    public string? ViewAction { get; set; }

    /// <summary>
    /// Type of action performed (character string, maximun 500).
    /// </summary>
    public string? Action { get; set; }
}
