using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class PictureDto
    {
        [Key]
        public int IdPicture { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public int? PlaceId { get; set; }
        public string PlaceName { get; set; } = null!;
    }
}
