using System.Collections.Generic;
using System.Threading.Tasks;
using Cookery.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookery.API.Database
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _dataContext;
        public RecipeRepository (DataContext dataContext)
        {
            this._dataContext = dataContext;

        }

        public void Add<T> (T entity) where T : class
        {
            _dataContext.Add (entity);
        }

        public void Delete<T> (T entity) where T : class
        {
            _dataContext.Remove (entity);
        }

        public async Task<User> GetUser (int id)
        {
            var user = await _dataContext.Users.Include (p => p.Recipes)
                .FirstOrDefaultAsync (u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers ()
        {
            var users = await _dataContext.Users.Include (p => p.Recipes)
                .ToListAsync ();

            return users;
        }

        public async Task<bool> SaveAll ()
        {
            return await _dataContext.SaveChangesAsync () > 0;
        }
    }
}