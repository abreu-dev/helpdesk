using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Core.Domain.Exceptions
{
    public class PropertyNotFoundException : DetailedException
    {
        public PropertyNotFoundException(string propertyName, string propertyValue)
            : base("PropertyNotFound",
                   HelpDeskResource.PropertyNotFound,
                   HelpDeskResource.PropertyNotFoundTemplate.Format(new { PropertyName = propertyName, PropertyValue = propertyValue }))
        {
        }
    }
}
