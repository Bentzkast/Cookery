using System;

namespace Cookery.API.Dtos
{
    public class RecipesForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instruction { get; set; }
        public string PictureUrl { get; set; }
        public int DaysAgo { get; set; }
        public int PriceLvl { get; set; }
        public int CookingTimeInMin { get; set; }
        public int UserId { get; set; }
    }
}