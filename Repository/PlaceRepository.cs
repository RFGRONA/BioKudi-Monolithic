using BioKudi.dto;
using BioKudi.Models;

namespace BioKudi.Repository
{
    public class PlaceRepository
    {
        private readonly BiokudiDbContext _context;
        public PlaceRepository(BiokudiDbContext context)
        {
            _context = context;
        }

        public PlaceDto Create(PlaceDto place)
        {
            var placeEntity = new Place
            {
                NamePlace = place.NamePlace,
                Latitude = place.Latitude,
                Longitude = place.Longitude,
                Address = place.Address,
                Description = place.Description,
                Link = place.Link,
                StateId = place.StateId
            };
            _context.Places.Add(placeEntity);
            _context.SaveChanges();
            place.IdPlace = placeEntity.IdPlace;
            return place;
        }

        public PlaceDto GetPlace(int id)
        {
            var placeEntity = _context.Places.Find(id);
            if (placeEntity == null)
                return null;
            var place = new PlaceDto
            {
                IdPlace = placeEntity.IdPlace,
                NamePlace = placeEntity.NamePlace,
                Latitude = placeEntity.Latitude,
                Longitude = placeEntity.Longitude,
                Address = placeEntity.Address,
                Description = placeEntity.Description,
                Link = placeEntity.Link,
                StateId = placeEntity.StateId
            };
            return place;
        }

        public List<PlaceDto> GetListPlace()
        {
            var placeEntities = _context.Places;
            var places = new List<PlaceDto>();
            foreach (var placeEntity in placeEntities)
            {
                var place = new PlaceDto
                {
                    IdPlace = placeEntity.IdPlace,
                    NamePlace = placeEntity.NamePlace,
                    Latitude = placeEntity.Latitude,
                    Longitude = placeEntity.Longitude,
                    Address = placeEntity.Address,
                    Description = placeEntity.Description,
                    Link = placeEntity.Link,
                    StateId = placeEntity.StateId
                };
                places.Add(place);
            }
            return places;
        }

        public PlaceDto Update(PlaceDto place)
        {
            var placeEntity = _context.Places.Find(place.IdPlace);
            if (placeEntity == null)
                return null;
            placeEntity.NamePlace = place.NamePlace;
            placeEntity.Latitude = place.Latitude;
            placeEntity.Longitude = place.Longitude;
            placeEntity.Address = place.Address;
            placeEntity.Description = place.Description;
            placeEntity.Link = place.Link;
            placeEntity.StateId = place.StateId;
            _context.SaveChanges();
            return place;
        }
    }
}
