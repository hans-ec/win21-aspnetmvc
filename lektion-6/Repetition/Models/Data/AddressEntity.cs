using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repetition.Models.Data
{
    public class AddressEntity
    {
        [Key]
        [Column(TypeName = "nvarchar(450)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = "";

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string PostalCode { get; set; } = "";

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = "";

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; } = "Sverige";
    }
}
