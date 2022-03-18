using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_FileUploading.Models.Entitites
{
    public class ImageEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string? FileName { get; set; }
        
        [NotMapped]
        [Display(Name = "Upload File")]
        public IFormFile File { get; set; }
    }
}
