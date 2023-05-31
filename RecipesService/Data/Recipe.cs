using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiesService
{
    [Table("tblRecipes")]
    public class Recipe
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string NecessaryProducts { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Rate { get; set; }
        
        public virtual List<RecipeReview> recipeReviews { get; set; }
    }
}
