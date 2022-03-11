using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Identity_Roles_Policies_Claims.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        public string LastName { get; set; }
    }
}
