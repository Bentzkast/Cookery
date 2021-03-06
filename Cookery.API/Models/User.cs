using System;
using System.Collections.Generic;

namespace Cookery.API.Models {
    public class User {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Registered { get; set; }        
        public string About { get; set; }
        public string Picture { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}