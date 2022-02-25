using System.ComponentModel.DataAnnotations;

namespace _02_Modified_AspNetMvc.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string LongDescription { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
