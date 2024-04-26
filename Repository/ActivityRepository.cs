using BioKudi.dto;
using BioKudi.Models;

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
			var newActivity = new Activity
			{
				Type = activity.Type
			};
			_context.Activities.Add(newActivity);
			_context.SaveChanges();
			return activity;
		}

		public IEnumerable<ActivityDto> GetListActivity()
		{
			return _context.Activities.Select(a => new ActivityDto
			{
				IdActivity = a.IdActivity,
				Type = a.Type
			}).ToList();
		}

		public ActivityDto GetActivity(int activityId)
		{
			var activity = _context.Activities.FirstOrDefault(a => a.IdActivity == activityId);
			if (activity == null)
			{
				return null;
			}
			return new ActivityDto
			{
				IdActivity = activity.IdActivity,
				Type = activity.Type
			};
		}
	}
}
