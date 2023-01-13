namespace HelpDesk.Security.Contracts
{
    public class SignInResultDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
