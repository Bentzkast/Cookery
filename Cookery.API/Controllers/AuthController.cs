using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Cookery.API.Database;
using Cookery.API.Dtos;
using Cookery.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cookery.API.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController (IAuthRepository repo, IConfiguration config)
        {
            this._repo = repo;
            this._config = config;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register (UserForRegisterDto userForRegisterDto)
        {
            // validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower ();
            if (await _repo.UserExist (userForRegisterDto.Username))
                return BadRequest ("Username already exist");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register (userToCreate, userForRegisterDto.Password);

            // TODO update to route
            return StatusCode (201);
        }

        [HttpPost ("login")]
        public async Task<IActionResult> Login (UserForLoginDto UserForLoginDto)
        {
            // search from repo if user exist
            var userFromRepo = await _repo.Login (UserForLoginDto.Username.ToLower (), UserForLoginDto.Password);
            if (userFromRepo == null) return Unauthorized ();

            // create a claims with id & username
            var claims = new []
            {
                new Claim (ClaimTypes.NameIdentifier, userFromRepo.Id.ToString ()),
                new Claim (ClaimTypes.Name, userFromRepo.Username)
            };

            // need to "sign" create a security key

            var key = new SymmetricSecurityKey (System.Text.Encoding.UTF8
                .GetBytes (_config.GetSection ("AppSettings:Token").Value));

            var credentials = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

            // create the token with expiry data
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity (claims),
                Expires = System.DateTime.Now.AddDays (1),
                SigningCredentials = credentials
            };

            // create JWT handler based on the token Desc
            var tokenHandler = new JwtSecurityTokenHandler ();

            var token = tokenHandler.CreateToken (tokenDescriptor);

            // pass back token to client
            return Ok (new { token = tokenHandler.WriteToken (token) });

        }
    }
}