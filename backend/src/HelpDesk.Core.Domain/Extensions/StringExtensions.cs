using System.ComponentModel;

namespace HelpDesk.Core.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Format(this string template, object parameters)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(parameters))
                template = template.Replace("{" + prop.Name + "}", (prop.GetValue(parameters) ?? "(null)").ToString());

            return template;
        }
    }
}
