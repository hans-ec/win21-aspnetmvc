using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repetition.Models.Data
{
    public class UserProfileEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; } = "";
        public IdentityUser User { get; set; } = new();

        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string ProfileId { get; set; } = "";
        public ProfileEntity Profile { get; set; } = new();
    }
}
