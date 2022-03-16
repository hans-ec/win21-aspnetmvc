using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repetition.Models;
using Repetition.Models.Data;

namespace Repetition.Services
{
    public interface IProfileManager
    {
        Task<ProfileResult> CreateAsync(IdentityUser user, UserProfile profile);
    }


    public class ProfileManager : IProfileManager
    {
        private readonly AppDbContext _context;

        public ProfileManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProfileResult> CreateAsync(IdentityUser user, UserProfile profile)
        {
            try
            {
                var _profile = new ProfileEntity()
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    AddressId = await CreateAddressAsync(profile.StreetName, profile.PostalCode, profile.City, profile.Country)
                };

                _context.AspNetProfiles.Add(_profile);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return new ProfileResult { Succeeded = false, Message =  ex.Message };
            }

            return new ProfileResult { Succeeded = true };
        }


        private async Task<string> CreateAddressAsync(string streetName, string postalCode, string city, string country)
        {
            var _address = await _context.AspNetAddresses.FirstOrDefaultAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (_address == null)
            {
                _address = new AddressEntity()
                {
                    StreetName = streetName,
                    PostalCode = postalCode,
                    City = city,
                    Country = country
                };
                _context.AspNetAddresses.Add(_address);
                await _context.SaveChangesAsync();
            }

            return _address.Id;
        }

    }






    public class ProfileResult
    {
        public bool Succeeded { get; set; } = false;
        public string Message { get; set; }
    }
}
