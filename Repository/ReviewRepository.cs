using BioKudi.dto;
using BioKudi.Models;

namespace BioKudi.Repository
{
    public class ReviewRepository
    {
        private readonly BiokudiDbContext _context;
        private readonly PlaceRepository _placeRepository;
        public ReviewRepository(BiokudiDbContext context, PlaceRepository placeRepository)
        {
            _context = context;
            _placeRepository = placeRepository;
        }

        public ReviewDto Create(ReviewDto review)
        {
            var reviewEntity = new Review
            {
                Rate = review.Rate,
                Comment = review.Comment,
                UserId = review.UserId,
                PlaceId = review.PlaceId
            };
            _context.Reviews.Add(reviewEntity);
            _context.SaveChanges();
            review.IdReview = reviewEntity.IdReview;
            return review;
        }

        public ReviewDto GetReview(int id)
        {
            var reviewEntity = _context.Reviews.Find(id);
            if (reviewEntity == null)
                return null;
            var review = new ReviewDto
            {
                IdReview = reviewEntity.IdReview,
                Rate = reviewEntity.Rate,
                Comment = reviewEntity.Comment,
                UserId = reviewEntity.UserId,
                PlaceId = reviewEntity.PlaceId
            };
            if (review.PlaceId != null)
            {
                var place = _placeRepository.GetPlace((int)review.PlaceId);
                review.PlaceName = place != null ? place.NamePlace : null;
            }
            return review;
        }

        public List<ReviewDto> GetReviewUser(int idPlace, int idUser)
        {
            var reviewsForPlace = _context.Reviews.Where(r => r.PlaceId == idPlace).ToList();
            var sortedReviews = reviewsForPlace.OrderByDescending(r => r.UserId == idUser);
            var reviewDtos = sortedReviews.Select(reviewEntity => new ReviewDto
            {
                IdReview = reviewEntity.IdReview,
                Rate = reviewEntity.Rate,
                Comment = reviewEntity.Comment,
                UserId = reviewEntity.UserId,
                UserName = _context.Users.Find(reviewEntity.UserId).NameUser
            }).ToList();
            return reviewDtos;
        }


        public List<ReviewDto> GetReviewPlace(int idPlace)
        {
            var users = _context.Users.ToDictionary(u => u.IdUser, u => u.NameUser);
            var reviewEntities = _context.Reviews.Where(r => r.PlaceId == idPlace);
            var reviews = new List<ReviewDto>();
            if (reviewEntities == null)
                return null;
            foreach (var reviewEntity in reviewEntities)
            {
                var review = new ReviewDto
                {
                    IdReview = reviewEntity.IdReview,
                    Rate = reviewEntity.Rate,
                    Comment = reviewEntity.Comment,
                    UserName = users.ContainsKey(reviewEntity.UserId) ? users[reviewEntity.UserId] : null
                };
                if (review.PlaceId != null)
                {
                    var place = _placeRepository.GetPlace((int)review.PlaceId);
                    review.PlaceName = place != null ? place.NamePlace : null;
                }
                reviews.Add(review);
            }
            return reviews;
        }

        public List<ReviewDto> GetListReview()
        {
            var reviewEntities = _context.Reviews;
            var places = _context.Places.ToDictionary(p => p.IdPlace, p => p.NamePlace);
            var reviews = new List<ReviewDto>();
            foreach (var reviewEntity in reviewEntities)
            {
                var review = new ReviewDto
                {
                    IdReview = reviewEntity.IdReview,
                    Rate = reviewEntity.Rate,
                    Comment = reviewEntity.Comment,
                    UserId = reviewEntity.UserId,
                    PlaceId = reviewEntity.PlaceId
                };
                if (review.PlaceId != null && places.ContainsKey((int)review.PlaceId))
                    review.PlaceName = places[(int)review.PlaceId];
                reviews.Add(review);
            }
            return reviews;
        }

        public ReviewDto Update(ReviewDto review)
        {
            var reviewEntity = _context.Reviews.Find(review.IdReview);
            if (reviewEntity == null)
                return null;
            reviewEntity.Rate = review.Rate;
            reviewEntity.Comment = review.Comment;
            _context.SaveChanges();
            return review;
        }

        public bool Delete(int id)
        {
            var reviewEntity = _context.Reviews.Find(id);
            if (reviewEntity == null)
                return false;
            _context.Reviews.Remove(reviewEntity);
            _context.SaveChanges();
            return true;
        }

    }
}
