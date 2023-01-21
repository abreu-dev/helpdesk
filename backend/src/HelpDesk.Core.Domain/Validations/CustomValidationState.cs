namespace HelpDesk.Core.Domain.Validations
{
    public class CustomValidationState
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        public CustomValidationState(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }
    }
}
