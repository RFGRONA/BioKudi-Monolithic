using BioKudi.dto;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;

namespace BioKudi.Repository
{
    public class ActivityRepository
	{
		private readonly BiokudiDbContext _context;

		public ActivityRepository(BiokudiDbContext context)
		{
			_context = context;
		}

        public ActivityDto Create(ActivityDto activity)
        {
            try
            {
                var activityEntity = new Activity
                {
                    Type = activity.Type
                };

                _context.Activities.Add(activityEntity);
                _context.SaveChanges();
                activity.IdActivity = activityEntity.IdActivity;

                foreach (var placeId in activity.Places)
                {
                    var placeEntity = _context.Places.Find(placeId);
                    if (placeEntity != null)
                    {
                        _context.Entry(activityEntity).Collection(a => a.IdPlaces).Load();
                        activityEntity.IdPlaces.Add(placeEntity);
                    }
                }
                _context.SaveChanges();
                return activity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ActivityDto GetActivity(int id)
        {
            try
            {
                var activityEntity = _context.Activities.Include(a => a.IdPlaces).FirstOrDefault(a => a.IdActivity == id);
                if (activityEntity == null)
                    return null;
                var activity = new ActivityDto
                {
                    IdActivity = activityEntity.IdActivity,
                    Type = activityEntity.Type
                };
                var places = activityEntity.IdPlaces;
                foreach (var placeEntity in places)
                {
                    var placeDto = new PlaceDto
                    {
                        IdPlace = placeEntity.IdPlace,
                        NamePlace = placeEntity.NamePlace
                    };
                    activity.PlacesData.Add(placeDto);
                }
                return activity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<ActivityDto> GetListActivity()
        {
            try
            {
                var activityEntities = _context.Activities.Include(a => a.IdPlaces).OrderBy(a => a.Type);
                var activities = new List<ActivityDto>();
                foreach (var activityEntity in activityEntities)
                {
                    var activity = new ActivityDto
                    {
                        IdActivity = activityEntity.IdActivity,
                        Type = activityEntity.Type,
                        Places = activityEntity.IdPlaces.Select(p => p.IdPlace).ToList()
                    };
                    activities.Add(activity);
                }
                return activities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ActivityDto Update(ActivityDto activity)
        {
            try
            {
                var activityEntity = _context.Activities
                    .Include(a => a.IdPlaces)
                    .FirstOrDefault(a => a.IdActivity == activity.IdActivity);
                if (activityEntity == null)
                    return null;
                activityEntity.Type = activity.Type;
                activityEntity.IdPlaces.Clear();
                foreach (var placeId in activity.Places)
                {
                    var placeEntity = _context.Places.Find(placeId);
                    if (placeEntity != null)
                    {
                        activityEntity.IdPlaces.Add(placeEntity);
                    }
                }
                _context.SaveChanges();
                return activity;
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
                var activityEntity = _context.Activities
                .Include(p => p.IdPlaces)
                .ThenInclude(p => p.IdActivities)
                .SingleOrDefault(p => p.IdActivity == id);
                if (activityEntity == null)
                    return false;
                foreach (var place in activityEntity.IdPlaces)
                {
                    place.IdActivities.Remove(activityEntity);
                }
                _context.Activities.Remove(activityEntity);
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
