using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SignUpModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [StringLength(256, ErrorMessage = "Förnamnet måste bestå av minst 2 tecken", MinimumLength = 2)]    
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [StringLength(256, ErrorMessage = "Efternamnet måste bestå av minst 2 tecken", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "E-Postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [EmailAddress(ErrorMessage = "E-postadressen måste vara giltig")]
        public string Email { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [StringLength(256, ErrorMessage = "Lösenordet måste bestå av minst 8 tecken", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Bekräfta Lösenord")]
        [Required(ErrorMessage = "Du måste ange bekräfta lösenordet")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
