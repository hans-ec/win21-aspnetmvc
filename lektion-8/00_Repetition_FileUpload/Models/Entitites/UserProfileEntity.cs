using System.ComponentModel.DataAnnotations;

namespace _00_Repetition_FileUpload.Models.Entitites
{
    public class UserProfileEntity
    {
        [Key]
        public string UserId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
