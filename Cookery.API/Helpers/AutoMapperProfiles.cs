using AutoMapper;
using Cookery.API.Dtos;
using Cookery.API.Models;

namespace Cookery.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles ()
        {
            CreateMap<User, UserForListDto> ();
            CreateMap<User, UserForDetailedDto> ();
            CreateMap<Recipe, RecipesForDetailedDto> ()
                .ForMember (dest => dest.DaysAgo, opt =>
                {
                    opt.ResolveUsing (d => d.DateAdded.CalculateDaysAgo ());
                });
            CreateMap<Recipe, RecipesForListDto> ()
                .ForMember (dest => dest.DaysAgo, opt =>
                {
                    opt.ResolveUsing (d => d.DateAdded.CalculateDaysAgo ());
                });
        }
    }
}