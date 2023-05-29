using AlcoProjectLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrinksService
{
    [Route("[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinksManager _drinksManager;
        public DrinksController(IDrinksManager drinksManager)
        {
            _drinksManager = drinksManager;
        }
        [HttpPost]
        public async Task<Drink> CreateDrink([FromBody] CreateDrinkRequest request)
        {
            return await _drinksManager.CreateDrink(request);
        }
        [HttpPut]
        public async Task<Drink> UpdateDrink([FromBody] UpdateDrinkRequest request)
        {
            return await _drinksManager.UpdateDrink(request);
        }
        [HttpDelete("{id:int}")]
        public async Task<Drink> DeleteDrink(int id)
        {
            return await _drinksManager.DeleteDrink(id);
        }
        [HttpGet("many")]
        public async Task<List<Drink>> GetDrinks()
        {
            return await _drinksManager.Get();
        }
        [HttpGet("many/{category:int}")]
        public async Task<List<Drink>> GetDrinksByCategory(ProjectEnums.DrinkCategory category)
        {
            return await _drinksManager.GetByCategory(category);
        }
        [HttpGet("one/{id:int}")]
        public async Task<Drink> GetDrinkById(int id)
        {
            return await _drinksManager.GetById(id);
        }
    }
}
