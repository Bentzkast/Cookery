using System.Collections.Generic;
using Cookery.API.Models;
using Newtonsoft.Json;

namespace Cookery.API.Database
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed (DataContext dataContext)
        {
            this._dataContext = dataContext;

        }

        public void SeedUsers ()
        {
            var userData = System.IO.File.ReadAllText ("Database/seeds.json");
            var users = JsonConvert.DeserializeObject<List<User>> (userData);
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash ("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower ();

                _dataContext.Add (user);
            }

            _dataContext.SaveChanges ();
        }

        private void CreatePasswordHash (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
            }
        }
    }
}