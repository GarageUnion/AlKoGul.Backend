namespace PiesService
{
    public interface IRecipesManager
    {
        Task<List<Recipe>> Get();
        Task<Recipe> GetById(int id);
        Task<Recipe> CreateRecipe(CreateRecipeRequest createUserRequest);
        Task<Recipe> DeleteRecipe(int id);
        Task<Recipe> UpdateRecipe(UpdateRecipeRequest updateBreadRequest);
    }
}
