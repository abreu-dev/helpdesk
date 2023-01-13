using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Domain.ProtectSkills;
using HelpDesk.Core.Domain.ProtectSkills.Skills;

namespace HelpDesk.Security.Domain.Entities
{
    public class UserDomain : DomainEntity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set
            {
                _id = value;
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                _name = Protect<string>
                    .Property(nameof(Name), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            private set
            {
                _email = Protect<string>
                    .Property(nameof(Email), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            private set
            {
                _username = Protect<string>
                    .Property(nameof(Username), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            private set
            {
                _password = Protect<string>
                    .Property(nameof(Password), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        private string _language;
        public string Language
        {
            get => _language;
            private set
            {
                _language = Protect<string>
                    .Property(nameof(Language), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        public UserDomain(string name,
                          string email,
                          string username,
                          string password,
                          string language)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            Language = language;
        }

        public UserDomain(Guid id,
                          string name,
                          string email,
                          string username,
                          string password,
                          string language)
            : this(name, email, username, password, language)
        {
            Id = id;
        }
    }
}
