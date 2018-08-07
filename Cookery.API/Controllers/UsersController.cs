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

    public class UsersController : ControllerBase
    {
        private readonly IRecipeRepository _repo;
        private readonly IMapper _mapper;
        public UsersController (IRecipeRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers ()
        {
            var users = await _repo.GetUsers ();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>> (users);

            return Ok (usersToReturn);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetUser (int id)
        {
            var user = await _repo.GetUser (id);

            var userToReturn = _mapper.Map<UserForDetailedDto> (user);

            return Ok (userToReturn);
        }
    }
}