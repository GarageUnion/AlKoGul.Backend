using System.ComponentModel.DataAnnotations;


namespace DrinksService 
{
    public class DrinkReviewRequest
    {
        public string Review { get; set; }
        public int Rate { get; set; }
        public int DrinkId { get; set; }
        public int UserId { get; set; }
    }
}
