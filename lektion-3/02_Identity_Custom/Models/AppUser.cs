using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_Identity_Custom.Models
{
    public class AppUser : IdentityUser
    {
        [Required, PersonalData, Column(TypeName = "nvarchar(256)")]
        public string FirstName { get; set; }

        [Required, PersonalData, Column(TypeName = "nvarchar(256)")]
        public string LastName { get; set; }

        [Required, PersonalData, Column(TypeName = "nvarchar(256)")]
        public string AddressLine { get; set; }

        [Required, PersonalData, Column(TypeName = "char(5)")]
        public string PostalCode { get; set; }

        [Required, PersonalData, Column(TypeName = "nvarchar(256)")]
        public string City { get; set; }
    }
}
