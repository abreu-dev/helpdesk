namespace HelpDesk.Ticket.Contracts
{
    public class CategoryForCreationDto
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
