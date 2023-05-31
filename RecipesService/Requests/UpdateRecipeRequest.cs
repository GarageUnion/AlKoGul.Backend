namespace PiesService
{
    public class UpdateRecipeRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string NecessaryProducts { get; set; }
        public string Description { get; set; }
    }
}
