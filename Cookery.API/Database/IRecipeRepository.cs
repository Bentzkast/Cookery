using System.Collections.Generic;
using System.Threading.Tasks;
using Cookery.API.Models;

namespace Cookery.API.Database
{
    public interface IRecipeRepository
    {
        // adding user / adding recipes
        void Add<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveAll ();
        Task<IEnumerable<User>> GetUsers ();
        Task<User> GetUser (int id);
    }
}