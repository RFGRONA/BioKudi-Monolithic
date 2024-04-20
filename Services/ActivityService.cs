using BioKudi.dto;
using BioKudi.Repository;

namespace BioKudi.Services
{
    public class ActivityService
	{
		private readonly ActivityRepository activityRepo;
		private readonly IHttpContextAccessor httpContextAccessor;

		public ActivityService(ActivityRepository activityRepo, IHttpContextAccessor httpContextAccessor)
		{
			this.activityRepo = activityRepo;
			this.httpContextAccessor = httpContextAccessor;
		}

		public ActivityDto CreateActivity(ActivityDto activity)
		{
			var result = activityRepo.Create(activity);
			if (result == null)
			{
				return null;
			}
			return activity;
		}

		public IEnumerable<ActivityDto> GetAllActivities()
		{
			return activityRepo.GetListActivity();
		}

		public ActivityDto GetActivity(int activityId)
		{
			return activityRepo.GetActivity(activityId);
		}

		//public ActivityDto UpdateActivity(ActivityDto activity)
		//{
		//	var result = activityRepo.Update(activity);
		//	if (result == null)
		//	{
		//		return null;
		//	}
		//	return activity;
		//}
	}
}
