using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class PictureDto
    {
        [Key]
        public int IdPicture { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public List<int> PlaceId { get; set; } = new List<int>();
    }
}
