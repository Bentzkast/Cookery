using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cookery.API.Database;
using Cookery.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookery.API.Controllers
{
    [Authorize]
    [Route ("api/[controller]")]
    [ApiController]

    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _repo;
        private readonly IMapper _mapper;
        public RecipesController (IRecipeRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRecipes ()
        {
            var recipes = await _repo.GetRecipes ();
            var recipesToReturn = _mapper.Map<IEnumerable<RecipesForListDto>> (recipes);

            return Ok (recipesToReturn);
        }

        [AllowAnonymous]
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetRecipe (int id)
        {
            var recipe = await _repo.GetRecipe (id);
            var recipeToReturn = _mapper.Map<RecipesForDetailedDto> (recipe);
            return Ok (recipeToReturn);
        }
    }
}