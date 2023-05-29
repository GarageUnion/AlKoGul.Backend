
namespace DrinksService
{
    public interface IDrinkReviewsManager
    {
        Task<List<DrinkReview>> GetGyDrink(int drinkId);
        Task<DrinkReview> CreateReview(CreateDrinkReviewRequest createRequest);
        Task<DrinkReview> DeleteReview(int id);
    }
}
