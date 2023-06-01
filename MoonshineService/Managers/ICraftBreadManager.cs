namespace CraftBreadService
{
    public interface ICraftBreadManager
    {
        Task<List<CraftBread>> Get();
        Task<CraftBread> GetById(int id);
        Task<CraftBread> CreateBread(CreateBreadRequest createUserRequest);
        Task<CraftBread> DeleteBread(int id);
        Task<CraftBread> UpdateBread(UpdateBreadRequest updateBreadRequest);
    }
}
