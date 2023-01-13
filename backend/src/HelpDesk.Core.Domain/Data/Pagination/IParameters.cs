namespace HelpDesk.Core.Domain.Data.Pagination
{
    public interface IParameters
    {
        int Page { get; set; }
        int Size { get; set; }
    }
}
