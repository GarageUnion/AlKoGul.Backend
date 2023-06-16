using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BreadProjectLibrary
{
    [Table("tblBread")]
    public class Bread
    {
        // Свойства класса будут трасформированы в столбцы в таблице

        // Атрибут указывающий что данное свойство является первичным ключом в таблице
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public ProjectEnums.BreadCategory Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Rate { get; set; }

        public virtual List<BreadReview> breadReviews { get; set; }
    }
}

