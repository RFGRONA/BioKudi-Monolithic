using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class ReviewDto
    {
        [Key]
        public int IdReview { get; set; }
        public float Rate { get; set; }
        public string? Comment { get; set; }
        public int UserId { get; set; }
        public int? PlaceId { get; set; }
    }
}
