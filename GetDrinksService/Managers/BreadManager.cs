using BreadProjectLibrary;
using Microsoft.EntityFrameworkCore;
namespace BreadService
{

    //ВНИМАНИЕ
    //ВОЗМОЖЕН БАГ ИЗ-ЗА ПЕРЕДАЧИ ССЫЛКИ НА БД НАПРЯМУЮ

    public class BreadManager : IBreadManager
    {
        private readonly DataContext _dbContext;
        public BreadManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Bread> CreateBread(CreateBreadRequest createUserRequest)
        {
            Bread newBread = new Bread {
                Name = createUserRequest.Name,
                Description = createUserRequest.Description,
                Price = createUserRequest.Price,
                Category = createUserRequest.Category,
                Rate = 0
            };
            _dbContext.Bread.Add(newBread);
            await _dbContext.SaveChangesAsync();
            return newBread;

        }

        public async Task<Bread> DeleteBread(int id)
        {
            var bread = _dbContext.Bread.FirstOrDefault((x => x.Id == id));
            if (bread != null)
            {
                if (File.Exists("Images/"+bread.Id))
                {
                    File.Delete("Images/" + bread.Id);
                }
                _dbContext.Bread.Remove(bread);
                await _dbContext.SaveChangesAsync();
                return bread;
            }
            else return null;
        }

        public async Task<List<Bread>> Get()
        {
            var bread = await _dbContext.Bread.ToListAsync();
            return bread;
        }

        public async Task<List<Bread>> GetByCategory(ProjectEnums.BreadCategory category)
        {
            var allBread = await _dbContext.Bread.ToListAsync();
            var bread = allBread.Where(x => x.Category == category).ToList();
            if (bread.Any())
            {
                return bread;
            }
            else return null;
        }

        public async Task<Bread> GetById(int id)
        {
            var bread = await _dbContext.Bread.FirstOrDefaultAsync(x => x.Id == id);
            return bread;
        }

        public async Task<Bread> UpdateBread(UpdateBreadRequest updateBreadRequest)
        {
            var bread = await _dbContext.Bread.FirstOrDefaultAsync(x => x.Id == updateBreadRequest.Id);
            if (bread != null)
            {
                bread.Price = updateBreadRequest.Price;
                bread.Name = updateBreadRequest.Name;
                bread.Description = updateBreadRequest.Description;
                bread.Category = updateBreadRequest.Category;
                _dbContext.Update(bread);
                await _dbContext.SaveChangesAsync();
                return bread;
            }
            else return null;
        }
    }
}
