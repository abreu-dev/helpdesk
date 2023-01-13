using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Security.Contracts
{
    public class SignInDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
