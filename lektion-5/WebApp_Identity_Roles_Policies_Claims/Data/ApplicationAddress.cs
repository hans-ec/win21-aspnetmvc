using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Identity_Roles_Policies_Claims.Data
{
    public class ApplicationAddress
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [PersonalData]
        public string AddressLine { get; set; }

        [Required]
        [PersonalData]
        public string PostalCode { get; set; }

        [Required]
        [PersonalData]
        public string City { get; set; }
    }
}
