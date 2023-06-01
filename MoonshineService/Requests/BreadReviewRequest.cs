namespace CraftBreadService
{
    public class BreadReviewRequest
    {
        public string Review { get; set; }
        public int Rate { get; set; }
        public int BreadId { get; set; }
        public int UserId { get; set; }
    }
}
