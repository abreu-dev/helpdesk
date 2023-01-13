namespace HelpDesk.Security.Contracts
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Language { get; set; }
    }
}
