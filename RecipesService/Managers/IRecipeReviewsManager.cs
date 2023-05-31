namespace PiesService
{
    public interface IRecipeReviewsManager
    {
        Task<List<RecipeReview>> GetGyBread(int recipeId);
        Task<RecipeReview> CreateReview(RecipeReviewRequest createRequest);
        Task<RecipeReview> DeleteReview(int id);
    }
}
