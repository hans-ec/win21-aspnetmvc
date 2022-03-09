using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SignInModel
    {
        [Display(Name = "E-Postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [EmailAddress(ErrorMessage = "E-postadressen måste vara giltig")]
        public string Email { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [StringLength(256, ErrorMessage = "Lösenordet måste bestå av minst 8 tecken", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
