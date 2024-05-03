using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class RoleDto
    {
        [Key] 
        public int RoleId { get; set; }
        public string? NameRole { get; set; }
    }
}
