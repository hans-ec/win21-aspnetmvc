using Microsoft.EntityFrameworkCore;
using WebApp_Identity_Roles_Policies_Claims.Data;

namespace WebApp_Identity_Roles_Policies_Claims.Helpers
{
    public interface IAddressManager
    {
        Task<IEnumerable<ApplicationAddress>> GetAddressesAsync();
        Task<ApplicationAddress> GetUserAddressAsync(ApplicationUser user);
        Task CreateUserAddressAsync(ApplicationUser user, ApplicationAddress address);
    }

    public class AddressManager : IAddressManager
    {
        private readonly ApplicationDbContext _context;

        public AddressManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAddressAsync(ApplicationUser user, ApplicationAddress address)
        {
            var userAddress = new ApplicationUserAddress();

            var _address = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressLine == address.AddressLine && x.PostalCode == address.PostalCode); 
            if(_address == null)
            {
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                userAddress = new ApplicationUserAddress { UserId = user.Id, AddressId = address.Id };
            }
            else
            {
                userAddress = new ApplicationUserAddress { UserId = user.Id, AddressId = _address.Id };
            }

            _context.UserAddresses.Add(userAddress);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationAddress>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<ApplicationAddress> GetUserAddressAsync(ApplicationUser user)
        {
            var result = await _context.UserAddresses.Include(t => t.Address).FirstOrDefaultAsync(x => x.UserId == user.Id);
            return result.Address;
        }
    }
}
