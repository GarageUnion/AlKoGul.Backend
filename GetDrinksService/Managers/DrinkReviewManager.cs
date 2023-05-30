using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DrinksService
{
    public class DrinkReviewManager : IDrinkReviewsManager
    {
        private readonly DataContext _dbContext;
        private void CalculateDrinkRate(Drink reviewedDrink)
        {
            var allReviews = _dbContext.Reviews.ToList();
            var reviews = allReviews.Where(x => x.Drink == reviewedDrink).ToList();
            if (reviews.Count == 0)
            {
                reviewedDrink.Rate = 0;
            }
            else
            {
                reviewedDrink.Rate = (double)(reviews.Sum(x => x.Rate) / (double)reviews.Count);
            }  
        }
        public DrinkReviewManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DrinkReview> CreateReview(DrinkReviewRequest createRequest)
        {
            var reviewedDrink = _dbContext.Drinks.FirstOrDefault((x => x.Id == createRequest.DrinkId));
            if (reviewedDrink != null)
            {

                DrinkReview drinkReview = new DrinkReview()
                {
                    Drink = reviewedDrink,
                    Rate = createRequest.Rate,
                    Review = createRequest.Review,
                    UserId = createRequest.UserId
                };
                _dbContext.Reviews.Add(drinkReview);
                await _dbContext.SaveChangesAsync();
                CalculateDrinkRate(reviewedDrink);
                await _dbContext.SaveChangesAsync();
                return drinkReview;
            }
            else return null;
        }

        public async Task<DrinkReview> DeleteReview(int id)
        {
            var review = _dbContext.Reviews.FirstOrDefault((x => x.Id == id));
            if (review != null)
            {
                var reviewedDrink = review.Drink;
                _dbContext.Reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
                CalculateDrinkRate(reviewedDrink);
                await _dbContext.SaveChangesAsync();
                return review;
            }
            else return null;
        }

        public async Task<List<DrinkReview>> GetGyDrink(int drinkId)
        {
            var allReviews = await _dbContext.Reviews.ToListAsync();
            var reviews = allReviews.Where(x => x.Drink.Id == drinkId).ToList();
            if (reviews.Any())
            {
                return reviews;
            }
            else return null;
        }
    }
}
