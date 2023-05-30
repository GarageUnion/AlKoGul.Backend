using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlcoProjectLibrary;
namespace DrinksService
{
    [Table("tblDrinks")]
    public class Drink
    {
        // Свойства класса будут трасформированы в столбцы в таблице

        // Атрибут указывающий что данное свойство является первичным ключом в таблице
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Strength { get; set; }

        [Required]
        public ProjectEnums.DrinkCategory Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Rate { get; set; }

        public virtual List<DrinkReview> drinkReviews { get; set; }
    }
}

