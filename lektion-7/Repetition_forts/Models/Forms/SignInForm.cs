using System.ComponentModel.DataAnnotations;

namespace Repetition_forts.Models.Forms
{
    public class SignInForm
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Must contain a valid email address")]
        public string Email { get; set; } = "";

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must meet the minimum requirements")]
        public string Password { get; set; } = "";


        public string ErrorMessage { get; set; } = "";
        public string ReturnUrl { get; set; } = "/";
    }
}
