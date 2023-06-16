using Microsoft.EntityFrameworkCore;
using BreadProjectLibrary;
namespace CraftBreadService
{
    public class CraftBreadReviewManager:ICraftBreadReviewsManager
    {
        private readonly DataContext _dbContext;
        private void CalculateBreadRate(CraftBread reviewedBread)
        {
            var allReviews = _dbContext.Reviews.ToList();
            var reviews = allReviews.Where(x => x.Bread == reviewedBread).ToList();
            if (reviews.Count == 0)
            {
                reviewedBread.Rate = 0;
            }
            else
            {
                reviewedBread.Rate = Math.Round((double)(reviews.Sum(x => x.Rate) / (double)reviews.Count), 2);
            }
        }
        public CraftBreadReviewManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CraftBreadReview> CreateReview(BreadReviewRequest createRequest)
        {
            var reviewedBread = _dbContext.Bread.FirstOrDefault((x => x.Id == createRequest.BreadId));
            if (reviewedBread != null)
            {

                CraftBreadReview breadReview = new CraftBreadReview()
                {
                    Bread = reviewedBread,
                    Rate = createRequest.Rate,
                    Review = createRequest.Review,
                    UserId = createRequest.UserId,
                    UserName = createRequest.UserName
                };
                _dbContext.Reviews.Add(breadReview);
                await _dbContext.SaveChangesAsync();
                CalculateBreadRate(reviewedBread);
                await _dbContext.SaveChangesAsync();
                return breadReview;
            }
            else return null;
        }

        public async Task<CraftBreadReview> DeleteReview(int id)
        {
            var review = _dbContext.Reviews.FirstOrDefault((x => x.Id == id));
            if (review != null)
            {
                var reviewedBread = review.Bread;
                _dbContext.Reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
                CalculateBreadRate(reviewedBread);
                await _dbContext.SaveChangesAsync();
                return review;
            }
            else return null;
        }

        public async Task<List<CraftBreadReview>> GetGyBread(int breadId)
        {
            var allReviews = await _dbContext.Reviews.ToListAsync();
            var reviews = allReviews.Where(x => x.Bread.Id == breadId).ToList();
            if (reviews.Any())
            {
                return reviews;
            }
            else return null;
        }
    }
}
