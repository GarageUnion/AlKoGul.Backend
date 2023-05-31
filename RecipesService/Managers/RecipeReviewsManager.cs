using Microsoft.EntityFrameworkCore;

namespace PiesService
{
    public class RecipeReviewsManager : IRecipeReviewsManager
    {
        private readonly DataContext _dbContext;
        private void CalculateRecipeRate(Recipe reviewedRecipe)
        {
            var allReviews = _dbContext.Reviews.ToList();
            var reviews = allReviews.Where(x => x.Recipe == reviewedRecipe).ToList();
            if (reviews.Count == 0)
            {
                reviewedRecipe.Rate = 0;
            }
            else
            {
                reviewedRecipe.Rate = (double)(reviews.Sum(x => x.Rate) / (double)reviews.Count);
            }
        }
        public RecipeReviewsManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<RecipeReview> CreateReview(RecipeReviewRequest createRequest)
        {
            var reviewedRecipe = _dbContext.Recipes.FirstOrDefault((x => x.Id == createRequest.RecipeId));
            if (reviewedRecipe != null)
            {

                RecipeReview recipeReview = new RecipeReview()
                {
                    Recipe = reviewedRecipe,
                    Rate = createRequest.Rate,
                    Review = createRequest.Review,
                    UserId = createRequest.UserId
                };
                _dbContext.Reviews.Add(recipeReview);
                await _dbContext.SaveChangesAsync();
                CalculateRecipeRate(reviewedRecipe);
                await _dbContext.SaveChangesAsync();
                return recipeReview;
            }
            else return null;
        }

        public async Task<RecipeReview> DeleteReview(int id)
        {
            var review = _dbContext.Reviews.FirstOrDefault((x => x.Id == id));
            if (review != null)
            {
                var reviewedRecipe = review.Recipe;
                _dbContext.Reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
                CalculateRecipeRate(reviewedRecipe);
                await _dbContext.SaveChangesAsync();
                return review;
            }
            else return null;
        }

        public async Task<List<RecipeReview>> GetGyBread(int recipeId)
        {
            var allReviews = await _dbContext.Reviews.ToListAsync();
            var reviews = allReviews.Where(x => x.Recipe.Id == recipeId).ToList();
            if (reviews.Any())
            {
                return reviews;
            }
            else return null;
        }
    }
}
