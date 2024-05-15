using System.ComponentModel.DataAnnotations;

namespace BioKudi.dto
{
    public class PlaceDto
    {
        [Key]
        public int IdPlace { get; set; }
        public string NamePlace { get; set; } = null!;
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Address { get; set; }
        public string Description { get; set; } = null!;
        public string Link { get; set; } = null!;
        public int? StateId { get; set; }
		public string? StateName { get; set; }
		public List<int> ActivityId { get; set; } = new List<int>();
        public List<ActivityDto> ActivityData { get; set; } = new List<ActivityDto>();
        public int Pictures { get; set; }
        public List<PictureDto> PictureData { get; set; } = new List<PictureDto>();
        public int Reviews { get; set; } 
    }
}
