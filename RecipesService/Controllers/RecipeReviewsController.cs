using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BreadProjectLibrary;
namespace PiesService
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeReviewsController : ControllerBase
    {
        private readonly IRecipeReviewsManager _reviewsManager;
        public RecipeReviewsController(IRecipeReviewsManager reviewsManager)
        {
            _reviewsManager = reviewsManager;
        }
        [HttpGet("{breadId:int}")]
        public async Task<List<RecipeReview>> GetBreadReviews(int breadId)
        {
            return await _reviewsManager.GetGyBread(breadId);
        }
        [HttpPost]
        public async Task<RecipeReview> CreateReview([FromBody] RecipeReviewRequest createRequest)
        {
            return await _reviewsManager.CreateReview(createRequest);
        }
        [HttpDelete("{id:int}")]
        public async Task<RecipeReview> DeleteReview(int id)
        {
            return await _reviewsManager.DeleteReview(id);
        }
    }
}
