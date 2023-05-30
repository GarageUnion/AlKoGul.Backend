using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreadService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BreadReviewController : ControllerBase
    {
        private readonly IBreadReviewsManager _reviewsManager;
        public BreadReviewController(IBreadReviewsManager reviewsManager)
        {
            _reviewsManager = reviewsManager;
        }
        [HttpGet("{drinkId:int}")]
        public async Task<List<BreadReview>> GetBreadReviews(int drinkId)
        {
            return await _reviewsManager.GetGyBread(drinkId);
        }
        [HttpPost]
        public async Task<BreadReview> CreateReview([FromBody] BreadReviewRequest createRequest)
        {
            return await _reviewsManager.CreateReview(createRequest);
        }
        [HttpDelete("{id:int}")]
        public async Task<BreadReview> DeleteReview(int id)
        {
            return await _reviewsManager.DeleteReview(id);
        }
    }
}
