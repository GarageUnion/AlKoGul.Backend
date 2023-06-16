using BreadProjectLibrary;
using Microsoft.EntityFrameworkCore;

namespace PiesService
{
    public class RecipesManager : IRecipesManager
    {
        private readonly DataContext _dbContext;
        public RecipesManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Recipe> CreateRecipe(CreateRecipeRequest createUserRequest)
        {
            Recipe newRecipe = new Recipe
            {
                Name = createUserRequest.Name,
                Description = createUserRequest.Description,
                NecessaryProducts = createUserRequest.NecessaryProducts,
                Rate = 0
            };
            _dbContext.Recipes.Add(newRecipe);
            await _dbContext.SaveChangesAsync();
            return newRecipe;

        }

        public async Task<Recipe> DeleteRecipe(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault((x => x.Id == id));
            if (recipe != null)
            {
                if (File.Exists("Images/" + recipe.Id))
                {
                    File.Delete("Images/" + recipe.Id);
                }
                _dbContext.Recipes.Remove(recipe);
                await _dbContext.SaveChangesAsync();
                return recipe;
            }
            else return null;
        }

        public async Task<List<Recipe>> Get()
        {
            var recipe = await _dbContext.Recipes.ToListAsync();
            return recipe;
        }

        public async Task<Recipe> GetById(int id)
        {
            var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            return recipe;
        }

        public async Task<Recipe> UpdateRecipe(UpdateRecipeRequest updateRecipeRequest)
        {
            var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == updateRecipeRequest.Id);
            if (recipe != null)
            {
                recipe.NecessaryProducts = updateRecipeRequest.NecessaryProducts;
                recipe.Name = updateRecipeRequest.Name;
                recipe.Description = updateRecipeRequest.Description;
                _dbContext.Update(recipe);
                await _dbContext.SaveChangesAsync();
                return recipe;
            }
            else return null;
        }
    }
}
