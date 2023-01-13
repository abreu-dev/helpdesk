namespace HelpDesk.Core.Domain.Data.Pagination
{
    public interface IPagedList<T>
    {
        IList<T> Data { get; set; }
        int CurrentPage { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }
    }
}
