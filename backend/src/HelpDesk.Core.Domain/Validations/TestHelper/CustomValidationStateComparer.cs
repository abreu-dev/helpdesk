using System.Collections;

namespace HelpDesk.Core.Domain.Validations.TestHelper
{
    public class CustomValidationStateComparer : IEqualityComparer
    {
        public new bool Equals(object? x, object? y)
        {
            var xAsState = x as CustomValidationState;
            var yAsState = y as CustomValidationState;

            return xAsState != null
                && yAsState != null
                && xAsState.Type == yAsState.Type
                && xAsState.Error == yAsState.Error
                && xAsState.Detail == yAsState.Detail;
        }

        public int GetHashCode(object obj)
        {
            var objAsState = obj as CustomValidationState;

            if (objAsState != null)
                return HashCode.Combine(objAsState.Type, objAsState.Error, objAsState.Detail);

            return obj.GetHashCode();

        }
    }
}
