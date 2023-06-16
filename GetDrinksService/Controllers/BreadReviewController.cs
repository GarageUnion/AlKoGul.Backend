using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BreadProjectLibrary;
namespace BreadService
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
        [HttpGet("{breadId:int}")]
        public async Task<List<BreadReview>> GetBreadReviews(int breadId)
        {
            return await _reviewsManager.GetGyBread(breadId);
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
