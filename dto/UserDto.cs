using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BioKudi.dto;

public partial class UserDto
{
    [Key]
    public int UserId { get; set; }

    public string NameUser { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public int RoleId { get; set; } = 0;

    public string RoleName { get; set; } = null!;

    public int StateId { get; set; } = 0;

    public string StateName { get; set; } = null!;

    public string? message { get; set; }

    public bool StayLogged { get; set; } = false;

}
