using System;
using System.Collections.Generic;
namespace BioKudi.dto;

public partial class UserDto
{
    public int UserId { get; set; }

    public string NameUser { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public int RoleId { get; set; } = 0;


    public int StateId { get; set; } = 0;

    public string? message { get; set; }

}
