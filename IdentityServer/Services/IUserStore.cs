using IdentityServer.Data.Models;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IUserStore
    {
        Task<User> GetAuthenticatedUser(string username, string password);

        Task<User> FindByExternalProvider(string userId);
    }
}
