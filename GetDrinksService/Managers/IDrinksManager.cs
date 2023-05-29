
using AlcoProjectLibrary;

namespace DrinksService
{
    public interface IDrinksManager
    {
        Task<List<Drink>> Get();
        Task<Drink> GetById(int id);
        Task<List<Drink>> GetByCategory(ProjectEnums.DrinkCategory category);
        Task<Drink> CreateDrink(CreateDrinkRequest createUserRequest);
        Task<Drink> DeleteDrink(int id);
        Task<Drink> UpdateDrink(UpdateDrinkRequest updateDrinkRequest);
    }
}
