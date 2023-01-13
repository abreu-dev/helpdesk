using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Security.Contracts
{
    public class SignUpDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Language { get; set; }
    }
}
