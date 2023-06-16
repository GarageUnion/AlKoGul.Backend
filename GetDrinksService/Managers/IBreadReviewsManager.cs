using BreadProjectLibrary;
namespace BreadService
{
    public interface IBreadReviewsManager
    {
        Task<List<BreadReview>> GetGyBread(int breadId);
        Task<BreadReview> CreateReview(BreadReviewRequest createRequest);
        Task<BreadReview> DeleteReview(int id);
    }
}
