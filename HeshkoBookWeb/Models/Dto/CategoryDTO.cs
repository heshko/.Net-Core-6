using System.ComponentModel.DataAnnotations;

namespace HeshkoBookWeb.Models.Dto
{
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="The Name field is required")]
        public string Name { get; set; }
       
        [Display(Name ="Display Order"),Range(1,100)] // DisplayName
        public int DisplayOrder { get; set; }

      
    }
}
