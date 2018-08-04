using System.Threading.Tasks;
using Cookery.API.Models;

namespace Cookery.API.Database {
    public interface IAuthRepository {
        Task<User> Register (User user, string password);
        Task<User> Login (string username, string password);
        Task<bool> UserExist (string username);

    }
}