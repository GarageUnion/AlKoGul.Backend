using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreadService
{
    [Table("tblBreadReviews")]
    public class BreadReview
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
        public virtual Bread Bread { get; set; }

    }
}
