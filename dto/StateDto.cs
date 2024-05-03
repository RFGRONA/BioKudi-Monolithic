using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class StateDto
    {
        [Key]
        public int StateId { get; set; }
        public string? NameState { get; set; }
    }
}
