using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Core.Domain.Exceptions
{
    public class InvalidPropertyFormatException : DetailedException
    {
        public InvalidPropertyFormatException(string propertyName, string propertyValue)
            : base("InvalidPropertyFormat",
                   HelpDeskResource.InvalidPropertyFormat,
                   HelpDeskResource.InvalidPropertyFormatTemplate.Format(new { PropertyName = propertyName, PropertyValue = propertyValue }))
        {
        }
    }
}
