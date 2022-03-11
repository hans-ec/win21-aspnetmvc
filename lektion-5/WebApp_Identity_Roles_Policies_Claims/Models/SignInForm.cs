using System.ComponentModel.DataAnnotations;

namespace WebApp_Identity_Roles_Policies_Claims.Models
{
    public class SignInForm
    {
        public SignInForm()
        {
            Email = "";
            Password = "";
            ReturnUrl = "/";
        }

        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Du måste ange en giltig e-postadress")]
        public string Email { get; set; }

        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        //[RegularExpression(@"^(?=.?[A-Ö])(?=.?[a-ö])(?=.?[0-9])(?=.?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
