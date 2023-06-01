using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftBreadService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CraftBreadReviewController : ControllerBase
    {
        private readonly ICraftBreadReviewsManager _reviewsManager;
        public CraftBreadReviewController(ICraftBreadReviewsManager reviewsManager)
        {
            _reviewsManager = reviewsManager;
        }
        [HttpGet("{breadId:int}")]
        public async Task<List<CraftBreadReview>> GetBreadReviews(int breadId)
        {
            return await _reviewsManager.GetGyBread(breadId);
        }
        [HttpPost]
        public async Task<CraftBreadReview> CreateReview([FromBody] BreadReviewRequest createRequest)
        {
            return await _reviewsManager.CreateReview(createRequest);
        }
        [HttpDelete("{id:int}")]
        public async Task<CraftBreadReview> DeleteReview(int id)
        {
            return await _reviewsManager.DeleteReview(id);
        }
    }
}
