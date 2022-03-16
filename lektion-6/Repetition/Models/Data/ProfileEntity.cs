using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repetition.Models.Data
{
    public class ProfileEntity
    {
        [Key]
        [Column(TypeName = "nvarchar(450)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } 

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } 

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(450)")]
        public string AddressId { get; set; }
        public AddressEntity Address { get; set; } 
    }
}
