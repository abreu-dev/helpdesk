using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Core.Domain.Exceptions
{
    public class NotAuthenticatedException : OperationFailedException
    {
        public NotAuthenticatedException()
            : base(HelpDeskResource.NotAuthenticated)
        {
        }
    }
}
