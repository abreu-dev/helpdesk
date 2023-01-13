using HelpDesk.Security.Application.Services.Interfaces;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Entities;
using HelpDesk.Security.Domain.Exceptions;
using HelpDesk.Security.Domain.Repositories;

namespace HelpDesk.Security.Application.Services
{
    public class SignInService : ISignInService
    {
        private readonly IUserRepository _userRepository;

        public SignInService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDomain SignIn(SignInDto signInDto)
        {
            var user = _userRepository.Authenticate(signInDto.Username, signInDto.Password);

            if (user == null)
                throw new SignInFailedException();

            return user;
        }
    }
}
