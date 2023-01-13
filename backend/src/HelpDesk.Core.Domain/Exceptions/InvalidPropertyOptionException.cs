using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Infra.Globalization.Resources;

namespace HelpDesk.Core.Domain.Exceptions
{
    public class InvalidPropertyOptionException : DetailedException
    {
        public InvalidPropertyOptionException(string propertyName, string propertyValue)
            : base("InvalidPropertyOption",
                   HelpDeskResource.InvalidPropertyOption,
                   HelpDeskResource.InvalidPropertyOptionTemplate.Format(new { PropertyName = propertyName, PropertyValue = propertyValue }))
        {
        }
    }
}
