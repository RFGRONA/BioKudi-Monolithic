using BioKudi.dto;
using BioKudi.Repository;

namespace BioKudi.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository ReviewRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReviewService(ReviewRepository ReviewRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.ReviewRepo = ReviewRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<ReviewDto> GetAllReviews()
        {
            return ReviewRepo.GetListReview() ?? new List<ReviewDto>();
        }


        public bool DeleteReview(int ReviewId)
        {
            return ReviewRepo.Delete(ReviewId);
        }
    }
}
