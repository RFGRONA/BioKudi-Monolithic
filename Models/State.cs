using System;
using System.Collections.Generic;

namespace BioKudi.Models;

public partial class State
{
    public int IdState { get; set; }

    public string? NameState { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
