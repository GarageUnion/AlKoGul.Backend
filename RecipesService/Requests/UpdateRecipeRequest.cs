namespace PiesService
{
    public class UpdateRecipeRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NecessaryProducts { get; set; }
        public string Description { get; set; }
    }
}
