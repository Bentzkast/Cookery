using System;
using System.Collections.Generic;
using Cookery.API.Models;

namespace Cookery.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Registered { get; set; }        
        public string About { get; set; }
        public string Picture { get; set; }
        public ICollection<RecipesForDetailedDto> Recipes { get; set; }

    }
}