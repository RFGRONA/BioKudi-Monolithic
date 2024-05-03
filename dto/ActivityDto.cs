using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class ActivityDto
    {
        [Key]
        public int IdActivity { get; set; }
        public string Type { get; set; } = null!;
        public List<int> PlaceId { get; set; } = new List<int>();
    }
}