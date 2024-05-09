using BioKudi.dto;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

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
            try
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
                foreach (var activityId in place.ActivityId)
                {
                    var activityEntity = _context.Activities.Find(activityId);
                    if (activityEntity != null)
                    {
                        _context.Entry(placeEntity).Collection(p => p.IdActivities).Load();
                        placeEntity.IdActivities.Add(activityEntity);
                    }
                }
                _context.SaveChanges();
                return place;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public PlaceDto GetPlace(int id)
        {
            try
            {
                var placeEntity = _context.Places
                .Include(p => p.IdActivities)
                .Include(p => p.Pictures)
                .Include(p => p.Reviews)
                .SingleOrDefault(p => p.IdPlace == id);
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
                    StateId = placeEntity.StateId,
                    StateName = _context.States.Find(placeEntity.StateId).NameState,
                    Pictures = placeEntity.Pictures.Count(),
                    Reviews = placeEntity.Reviews.Count()
                };
                var activities = placeEntity.IdActivities;
                foreach (var activity in activities)
                {
                    place.ActivityData.Add(new ActivityDto
                    {
                        IdActivity = activity.IdActivity,
                        Type = activity.Type
                    });
                }
                return place;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<PlaceDto> GetListPlace()
        {
			try
            {
                var states = _context.States.ToDictionary(s => s.IdState, s => s.NameState);
                var placeEntities = _context.Places.Include(p => p.IdActivities).OrderBy(p => p.NamePlace);
                var places = new List<PlaceDto>();
                foreach (var place in placeEntities)
                {
                    var placeDto = new PlaceDto
                    {
                        IdPlace = place.IdPlace,
                        NamePlace = place.NamePlace,
                        Latitude = place.Latitude,
                        Longitude = place.Longitude,
                        Address = place.Address,
                        Description = place.Description,
                        Link = place.Link,
                        StateName = states.ContainsKey((int)place.StateId) ? states[(int)place.StateId] : null
                    };
                    foreach (var activity in place.IdActivities)
                    {
                        placeDto.ActivityData.Add(new ActivityDto
                        {
                            IdActivity = activity.IdActivity,
                            Type = activity.Type
                        });
                    }
                    places.Add(placeDto);
                }
                return places;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<PlaceDto> GetMarkers()
        {
            try
            {
                var placeEntities = _context.Places;
                var places = new List<PlaceDto>();
                foreach (var place in placeEntities)
                {
                    var placeDto = new PlaceDto
                    {
                        IdPlace = place.IdPlace,
                        NamePlace = place.NamePlace,
                        Latitude = place.Latitude,
                        Longitude = place.Longitude
                    };
                    places.Add(placeDto);
                }
                return places;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<PlaceDto> GetNameId()
        {
            try
            {
                var placeEntities = _context.Places;
                var places = new List<PlaceDto>();
                foreach (var place in placeEntities)
                {
                    var placeDto = new PlaceDto
                    {
                        IdPlace = place.IdPlace,
                        NamePlace = place.NamePlace,
                    };
                    places.Add(placeDto);
                }
                return places;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public PlaceDto Update(PlaceDto place)
        {
            try
            {
                var placeEntity = _context.Places
                    .Include(p => p.IdActivities)
                    .SingleOrDefault(p => p.IdPlace == place.IdPlace);
                if (placeEntity == null)
                    return null;
                placeEntity.NamePlace = place.NamePlace;
                placeEntity.Latitude = place.Latitude;
                placeEntity.Longitude = place.Longitude;
                placeEntity.Address = place.Address;
                placeEntity.Description = place.Description;
                placeEntity.Link = place.Link;
                placeEntity.StateId = place.StateId;
                placeEntity.IdActivities.Clear();
                foreach (var activityId in place.ActivityId)
                {
                    var activityEntity = _context.Activities.Find(activityId);
                    if (activityEntity != null)
                    {
                        placeEntity.IdActivities.Add(activityEntity);
                    }
                }
                _context.SaveChanges();
                return place;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var placeEntity = _context.Places
                    .Include(p => p.IdActivities)
                    .Include(p => p.Reviews)
                    .SingleOrDefault(p => p.IdPlace == id);
                if (placeEntity == null)
                    return false;
                foreach (var activity in placeEntity.IdActivities)
                {
                    activity.IdPlaces.Remove(placeEntity);
                }
                foreach (var review in placeEntity.Reviews)
                {
                    review.PlaceId = null;
                }
                _context.Places.Remove(placeEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
