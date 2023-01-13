using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Core.Domain.Exceptions
{
    public class PropertyNullOrEmptyException : DetailedException
    {
        public PropertyNullOrEmptyException(string propertyName)
            : base("PropertyNullOrEmpty",
                   HelpDeskResource.PropertyNullOrEmpty,
                   HelpDeskResource.PropertyNullOrEmptyTemplate.Format(new { PropertyName = propertyName }))
        {
        }
    }
}
