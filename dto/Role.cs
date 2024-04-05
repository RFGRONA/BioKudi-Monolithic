using System;
using System.Collections.Generic;

namespace BioKudi.dto;

public partial class Role
{
    public int RoleId { get; set; }

    public string NameRole { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
