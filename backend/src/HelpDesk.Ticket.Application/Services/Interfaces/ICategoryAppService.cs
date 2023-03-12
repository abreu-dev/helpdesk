using HelpDesk.Ticket.Contracts;

namespace HelpDesk.Ticket.Application.Services.Interfaces
{
    public interface ICategoryAppService
    {
        CategoryDto Create(CategoryForCreationDto categoryForCreationDto);
    }
}
