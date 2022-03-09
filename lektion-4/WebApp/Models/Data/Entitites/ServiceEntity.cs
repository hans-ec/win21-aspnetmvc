using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Data.Entitites
{
    public class ServiceEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}
