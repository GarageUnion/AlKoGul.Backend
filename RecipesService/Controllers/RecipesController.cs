using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BreadProjectLibrary;
namespace PiesService
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesManager _recipesManager;
        public RecipesController(IRecipesManager recipesManager)
        {
            _recipesManager = recipesManager;
        }
        [HttpGet("many")]
        public async Task<List<Recipe>> GetAll()
        {
            return await _recipesManager.Get();
        }
        [HttpGet("one/{id:int}")]
        public async Task<Recipe> GetById(int id)
        {
            return await _recipesManager.GetById(id);
        }
        [HttpDelete("{id:int}")]
        public async Task<Recipe> DeleteById(int id)
        {
            return await _recipesManager.DeleteRecipe(id);
        }
        [HttpPost]
        public async Task<Recipe> CreateRecipe(CreateRecipeRequest createRequest)
        {
            return await _recipesManager.CreateRecipe(createRequest);
        }
        [HttpPut]
        public async Task<Recipe> UpdateRecipe(UpdateRecipeRequest updateRequest)
        {
            return await _recipesManager.UpdateRecipe(updateRequest);
        }
    }
}
