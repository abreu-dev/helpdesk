using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Core.Domain.Exceptions
{
    public abstract class OperationFailedException : DetailedException
    {
        public OperationFailedException(string detail)
            : base("OperationFailed", HelpDeskResource.OperationFailed, detail)
        {
        }
    }
}
