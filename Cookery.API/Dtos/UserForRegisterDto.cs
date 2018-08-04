using System.ComponentModel.DataAnnotations;

namespace Cookery.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength (8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 & 8 character")]
        public string Password { get; set; }
    }
}