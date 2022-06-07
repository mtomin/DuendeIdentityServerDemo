using IdentityServer.Data;
using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class UserStore : IUserStore
    {
        private readonly UserContext _context;

        public UserStore(UserContext context)
        {
            _context = context;
        }
        public async Task<User> GetAuthenticatedUser(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<User> FindByExternalProvider(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            }

            return null;
        }
    }
}
