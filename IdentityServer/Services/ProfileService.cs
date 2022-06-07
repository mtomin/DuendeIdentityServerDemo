using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityServer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserContext _context;

        public ProfileService(UserContext context)
        {
            _context = context;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userName = context.Subject.Identity.Name;

            // your implementation to retrieve the requested information
            var claims = await GetRoleClaims(userName);
            context.IssuedClaims.AddRange(claims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }

        private async Task<List<Claim>> GetRoleClaims(string userName)
        {
            var roles = await _context.Users
                            .Where(u => u.Username == userName)
                            .Select(u => u.Role.Name)
                            .ToListAsync();

            return roles.ConvertAll(r => new Claim(ClaimTypes.Role, r));
        }
    }
}
