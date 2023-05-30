using AlcoProjectLibrary;
using Microsoft.EntityFrameworkCore;
namespace DrinksService
{

    //ВНИМАНИЕ
    //ВОЗМОЖЕН БАГ ИЗ-ЗА ПЕРЕДАЧИ ССЫЛКИ НА БД НАПРЯМУЮ

    public class DrinksManager : IDrinksManager
    {
        private readonly DataContext _dbContext;
        public DrinksManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Drink> CreateDrink(CreateDrinkRequest createUserRequest)
        {
            Drink newDrink = new Drink {
                Name = createUserRequest.Name,
                Description = createUserRequest.Description,
                Strength = createUserRequest.Strength,
                Category = createUserRequest.Category,
                Rate = 0
            };
            _dbContext.Drinks.Add(newDrink);
            await _dbContext.SaveChangesAsync();
            return newDrink;

        }

        public async Task<Drink> DeleteDrink(int id)
        {
            var drink = _dbContext.Drinks.FirstOrDefault((x => x.Id == id));
            if (drink != null)
            {
                if (File.Exists("Images/"+drink.Id))
                {
                    File.Delete("Images/" + drink.Id);
                }
                _dbContext.Drinks.Remove(drink);
                await _dbContext.SaveChangesAsync();
                return drink;
            }
            else return null;
        }

        public async Task<List<Drink>> Get()
        {
            var drinks = await _dbContext.Drinks.ToListAsync();
            return drinks;
        }

        public async Task<List<Drink>> GetByCategory(ProjectEnums.DrinkCategory category)
        {
            var allDrinks = await _dbContext.Drinks.ToListAsync();
            var drinks = allDrinks.Where(x => x.Category == category).ToList();
            if (drinks.Any())
            {
                return drinks;
            }
            else return null;
        }

        public async Task<Drink> GetById(int id)
        {
            var drink = await _dbContext.Drinks.FirstOrDefaultAsync(x => x.Id == id);
            return drink;
        }

        public async Task<Drink> UpdateDrink(UpdateDrinkRequest updateDrinkRequest)
        {
            var drink = await _dbContext.Drinks.FirstOrDefaultAsync(x => x.Id == updateDrinkRequest.Id);
            if (drink != null)
            {
                drink.Strength = updateDrinkRequest.Strength;
                drink.Name = updateDrinkRequest.Name;
                drink.Description = updateDrinkRequest.Description;
                drink.Category = updateDrinkRequest.Category;
                _dbContext.Update(drink);
                await _dbContext.SaveChangesAsync();
                return drink;
            }
            else return null;
        }
    }
}
