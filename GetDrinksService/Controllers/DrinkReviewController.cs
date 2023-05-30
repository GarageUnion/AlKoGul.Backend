using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinksService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrinkReviewController : ControllerBase
    {
        private readonly IDrinkReviewsManager _reviewsManager;
        public DrinkReviewController(IDrinkReviewsManager reviewsManager)
        {
            _reviewsManager = reviewsManager;
        }
        [HttpGet("{drinkId:int}")]
        public async Task<List<DrinkReview>> GetDrinkReviews(int drinkId)
        {
            return await _reviewsManager.GetGyDrink(drinkId);
        }
        [HttpPost]
        public async Task<DrinkReview> CreateReview([FromBody] DrinkReviewRequest createRequest)
        {
            return await _reviewsManager.CreateReview(createRequest);
        }
        [HttpDelete("{id:int}")]
        public async Task<DrinkReview> DeleteReview(int id)
        {
            return await _reviewsManager.DeleteReview(id);
        }
    }
}
