namespace PiesService
{
    public class RecipeReviewRequest
    {
        public string Review {get; set;}
        public int Rate { get; set;}
        public int UserId { get; set;}
        public int RecipeId { get; set;}
        public string UserName { get; set;}
    }
}
