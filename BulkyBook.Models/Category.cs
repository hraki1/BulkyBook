using System.ComponentModel.DataAnnotations;

namespace BullyBook_ECS.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Display(Name = "Display Number")]
        [Range(1,100 ,ErrorMessage ="Display Number Shuld be Between 1 , 100 ! ") ]
        public int? DisplayNumber { get; set; }
    }
}
