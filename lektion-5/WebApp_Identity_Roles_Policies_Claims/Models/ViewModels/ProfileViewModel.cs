using WebApp_Identity_Roles_Policies_Claims.Data;

namespace WebApp_Identity_Roles_Policies_Claims.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUserAddress Address { get; set; }
        public ApplicationUser User { get; set; }
    }
}
