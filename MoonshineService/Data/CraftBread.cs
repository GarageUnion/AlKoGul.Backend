using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CraftBreadService
{
    [Table("tblCraftBread")]
    public class CraftBread
    {
        // Свойства класса будут трасформированы в столбцы в таблице

        // Атрибут указывающий что данное свойство является первичным ключом в таблице
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string NecessaryProducts { get; set; }

        [Required]
        public bool IsMachineRequired { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Rate { get; set; }

        public virtual List<CraftBreadReview> breadReviews { get; set; }
    }
}
