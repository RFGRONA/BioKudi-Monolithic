using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class Audit
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? ViewAction { get; set; }

    public string? Action { get; set; }
}
