using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Core.Domain.Exceptions
{
    public class PropertyAlreadyInUseException : DetailedException
    {
        public PropertyAlreadyInUseException(string propertyName, string propertyValue)
            : base("PropertyAlreadyInUse",
                   HelpDeskResource.PropertyAlreadyInUse,
                   HelpDeskResource.PropertyAlreadyInUseTemplate.Format(new { PropertyName = propertyName, PropertyValue = propertyValue }))
        {
        }
    }
}
