namespace Cookery.API.Dtos
{
    public class RecipesForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public int DaysAgo { get; set; }
    }
}