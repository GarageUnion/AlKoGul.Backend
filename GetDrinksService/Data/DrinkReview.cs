using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinksService
{
    [Table("tblDrinkReviews")]
    public class DrinkReview
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public int UserId { get; set; }

        public virtual Drink Drink { get; set; }

    }
}
