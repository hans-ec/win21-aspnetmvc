using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace WebApp_Identity_Roles_Policies_Claims.Data
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserClaims(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);
            var address = await _context.UserAddresses.Include(x => x.Address).FirstOrDefaultAsync(x => x.UserId == user.Id);

            claimsIdentity.AddClaim(new Claim("UserId", user.Id ?? ""));
            claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}" ?? ""));
            claimsIdentity.AddClaim(new Claim("Address", $"{address?.Address.AddressLine}, {address?.Address.PostalCode} {address?.Address.City}" ?? ""));

            return claimsIdentity;
        }
    }
}
