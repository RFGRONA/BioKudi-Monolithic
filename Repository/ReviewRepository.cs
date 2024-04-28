using BioKudi.dto;
using BioKudi.Models;

namespace BioKudi.Repository
{
    public class ReviewRepository
    {
        private readonly BiokudiDbContext _context;
        public ReviewRepository(BiokudiDbContext context)
        {
            _context = context;
        }

        public ReviewDto Create(ReviewDto review)
        {
            var reviewEntity = new Review
            {
                Rate = review.Rate,
                Comment = review.Comment,
                UserId = review.UserId
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
                UserId = reviewEntity.UserId
            };
            return review;
        }

        public List<ReviewDto> GetListReview()
        {
            var reviewEntities = _context.Reviews;
            var reviews = new List<ReviewDto>();
            foreach (var reviewEntity in reviewEntities)
            {
                var review = new ReviewDto
                {
                    IdReview = reviewEntity.IdReview,
                    Rate = reviewEntity.Rate,
                    Comment = reviewEntity.Comment,
                    UserId = reviewEntity.UserId
                };
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
            reviewEntity.UserId = review.UserId;
            _context.SaveChanges();
            return review;
        }

        public void Delete(int id)
        {
            var reviewEntity = _context.Reviews.Find(id);
            if (reviewEntity == null)
                return;
            _context.Reviews.Remove(reviewEntity);
            _context.SaveChanges();
        }

    }
}
