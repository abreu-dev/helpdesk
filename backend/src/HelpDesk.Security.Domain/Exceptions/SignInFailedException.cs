using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Security.Domain.Exceptions
{
    public class SignInFailedException : OperationFailedException
    {
        public SignInFailedException()
            : base(HelpDeskResource.SignInFailed)
        {
        }
    }
}
