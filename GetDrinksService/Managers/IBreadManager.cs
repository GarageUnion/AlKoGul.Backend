
using BreadProjectLibrary;

namespace BreadService
{
    public interface IBreadManager
    {
        Task<List<Bread>> Get();
        Task<Bread> GetById(int id);
        Task<List<Bread>> GetByCategory(ProjectEnums.BreadCategory category);
        Task<Bread> CreateBread(CreateBreadRequest createUserRequest);
        Task<Bread> DeleteBread(int id);
        Task<Bread> UpdateBread(UpdateBreadRequest updateBreadRequest);
    }
}
