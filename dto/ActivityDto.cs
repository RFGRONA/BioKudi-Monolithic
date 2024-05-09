using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class ActivityDto
    {
        [Key]
        public int IdActivity { get; set; }
        public string Type { get; set; } = null!;
        public List<int> Places { get; set; } = new List<int>();
        public List<PlaceDto> PlacesData { get; set; } = new List<PlaceDto>();
    }
}