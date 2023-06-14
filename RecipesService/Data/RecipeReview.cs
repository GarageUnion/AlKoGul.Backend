using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiesService
{
    [Table("tblRecipeReviews")]
    public class RecipeReview
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }

        public virtual Recipe Recipe { get; set; }

    }
}
