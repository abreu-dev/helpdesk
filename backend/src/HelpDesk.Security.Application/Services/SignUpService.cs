using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Security.Application.Services.Interfaces;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Entities;
using HelpDesk.Security.Domain.Repositories;

namespace HelpDesk.Security.Application.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly IUserRepository _userRepository;

        public SignUpService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDomain SignUp(SignUpDto signUpDto)
        {
            var user = new UserDomain(
                           signUpDto.Name,
                           signUpDto.Email,
                           signUpDto.Username,
                           signUpDto.Password,
                           signUpDto.Language);

            if (_userRepository.AnyWithEmail(user.Email))
                throw new PropertyAlreadyInUseException(nameof(user.Email), user.Email);

            if (_userRepository.AnyWithUsername(user.Username))
                throw new PropertyAlreadyInUseException(nameof(user.Username), user.Username);

            user = _userRepository.Add(user);
            _userRepository.CommitChanges();

            return user;
        }
    }
}
