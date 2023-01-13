namespace HelpDesk.Security.Application.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpiresInHours { get; set; }
    }
}
