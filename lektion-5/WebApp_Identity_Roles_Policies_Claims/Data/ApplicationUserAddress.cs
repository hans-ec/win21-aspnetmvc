namespace WebApp_Identity_Roles_Policies_Claims.Data
{
    public class ApplicationUserAddress
    {
        public string UserId { get; set; }
        public int AddressId { get; set; }


        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationAddress Address { get; set; }
    }
}
