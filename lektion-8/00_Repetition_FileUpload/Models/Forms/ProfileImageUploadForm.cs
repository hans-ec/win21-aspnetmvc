using System.ComponentModel.DataAnnotations;

namespace _00_Repetition_FileUpload.Models.Forms
{
    public class ProfileImageUploadForm
    {        
        [Required]
        [Display(Name = "Upload File")]
        public IFormFile File { get; set; }
    }
}
