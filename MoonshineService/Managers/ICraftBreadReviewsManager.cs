namespace CraftBreadService
{
    public interface ICraftBreadReviewsManager
    {
        Task<List<CraftBreadReview>> GetGyBread(int breadId);
        Task<CraftBreadReview> CreateReview(BreadReviewRequest createRequest);
        Task<CraftBreadReview> DeleteReview(int id);
    }
}
