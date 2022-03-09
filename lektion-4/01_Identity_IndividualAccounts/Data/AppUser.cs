using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _01_Identity_IndividualAccounts.Data
{
    public class AppUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        public string LastName { get; set; }
    }
}
