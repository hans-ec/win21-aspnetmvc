using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Repetition_forts.Models.Identity
{
    public class UserClaims : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        public UserClaims(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);
            claimsIdentity.AddClaim(new Claim("UserId", user.Id));

            return claimsIdentity;
        }
    }
}
