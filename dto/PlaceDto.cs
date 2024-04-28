namespace BioKudi.dto
{
    public class PlaceDto
    {
        public int IdPlace { get; set; }
        public string NamePlace { get; set; } = null!;
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Address { get; set; }
        public string Description { get; set; } = null!;
        public string Link { get; set; } = null!;
        public int? StateId { get; set; }
        public List<int> ActivityId { get; set; } = new List<int>();
        public List<int> PictureId { get; set; } = new List<int>();
        public List<int> ReviewId { get; set; } = new List<int>();

    }
}
