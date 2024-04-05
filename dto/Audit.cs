using System;
using System.Collections.Generic;

namespace BioKudi.dto;

public partial class Audit
{
    public int AuditId { get; set; }

    public DateOnly? Date { get; set; }

    public string ViewAction { get; set; } = null!;

    public int Action { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
