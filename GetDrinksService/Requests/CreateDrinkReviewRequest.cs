using System.ComponentModel.DataAnnotations;


namespace DrinksService 
{
    public class CreateDrinkReviewRequest
    {
        public string Review { get; set; }
        public int Rate { get; set; }
        public Drink Drink { get; set; }
        public int UserId { get; set; }
    }
}
