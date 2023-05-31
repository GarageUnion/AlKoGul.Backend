using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserProfileService
{
    [Table("tblUsers")]
    public class User
    {
        // Свойства класса будут трасформированы в столбцы в таблице

        // Атрибут указывающий что данное свойство является первичным ключом в таблице
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

    }
}
