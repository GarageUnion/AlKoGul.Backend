using Microsoft.EntityFrameworkCore;

namespace CraftBreadService
{
    public class CraftBreadManager:ICraftBreadManager
    {
        private readonly DataContext _dbContext;
        public CraftBreadManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CraftBread> CreateBread(CreateBreadRequest createBreadRequest)
        {
            CraftBread newBread = new CraftBread
            {
                Name = createBreadRequest.Name,
                Description = createBreadRequest.Description,
                NecessaryProducts = createBreadRequest.NecessaryProducts,
                IsMachineRequired = createBreadRequest.IsMachineRequired,
                Rate = 0
            };
            _dbContext.Bread.Add(newBread);
            await _dbContext.SaveChangesAsync();
            return newBread;

        }

        public async Task<CraftBread> DeleteBread(int id)
        {
            var bread = _dbContext.Bread.FirstOrDefault((x => x.Id == id));
            if (bread != null)
            {
                if (File.Exists("Images/" + bread.Id))
                {
                    File.Delete("Images/" + bread.Id);
                }
                _dbContext.Bread.Remove(bread);
                await _dbContext.SaveChangesAsync();
                return bread;
            }
            else return null;
        }

        public async Task<List<CraftBread>> Get()
        {
            var bread = await _dbContext.Bread.ToListAsync();
            return bread;
        }

        public async Task<CraftBread> GetById(int id)
        {
            var bread = await _dbContext.Bread.FirstOrDefaultAsync(x => x.Id == id);
            return bread;
        }

        public async Task<CraftBread> UpdateBread(UpdateBreadRequest updateBreadRequest)
        {
            var bread = await _dbContext.Bread.FirstOrDefaultAsync(x => x.Id == updateBreadRequest.Id);
            if (bread != null)
            {
                bread.Name = updateBreadRequest.Name;
                bread.Description = updateBreadRequest.Description;
                bread.IsMachineRequired = updateBreadRequest.IsMachineRequired;
                bread.NecessaryProducts = updateBreadRequest.NecessaryProducts;
                _dbContext.Update(bread);
                await _dbContext.SaveChangesAsync();
                return bread;
            }
            else return null;
        }
    }
}
