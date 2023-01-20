using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Core.Infra.Data.Context;
using HelpDesk.Core.Infra.Data.Pagination;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Queries;
using HelpDesk.Ticket.Domain.Queries.Parameters;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Ticket.Infra.Repository.Queries
{
    public class TicketQuery : ITicketQuery
    {
        private readonly IDataContext _dataContext;

        public TicketQuery(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TicketDto GetById(Guid ticketId)
        {
            var ticket = _dataContext.Query<TicketData>()
                .Include(x => x.Customer)
                .Include(x => x.Attendant)
                .Include(x => x.Messages)
                .ThenInclude(x => x.Owner)
                .SingleOrDefault(x => x.Id == ticketId);

            if (ticket == null)
                throw new PropertyNotFoundException(nameof(ticketId), ticketId.ToString());

            return new TicketDto()
            {
                Id = ticket.Id,
                Customer = new TicketCustomerDto()
                {
                    Id = ticket.Customer.Id,
                    Name = ticket.Customer.Name,
                    Email = ticket.Customer.Email,
                    Username = ticket.Customer.Username
                },
                Attendant = new TicketAttendantDto()
                {
                    Id = ticket.Attendant.Id,
                    Name = ticket.Attendant.Name,
                    Email = ticket.Attendant.Email,
                    Username = ticket.Attendant.Username
                },
                Messages = ticket.Messages.Select(ticketMessage => 
                    new TicketMessageDto()
                    {
                        Message = ticketMessage.Message,
                        Owner = new TicketMessageOwnerDto()
                        {
                            Id = ticketMessage.Owner.Id,
                            Name = ticketMessage.Owner.Name,
                            Email = ticketMessage.Owner.Email,
                            Username = ticketMessage.Owner.Username
                        }
                    }).ToList(),
                Title = ticket.Title
            };
        }

        public IPagedList<TicketDto> Paginate(ITicketParameters parameters)
        {
            var source = _dataContext.Query<TicketData>()
                .Include(x => x.Customer)
                .Include(x => x.Attendant).AsQueryable();

            var totalItems = source.Count();

            source = source.OrderByDescending(p => p.CreatedOn);

            var dtos = (from ticket in source
                        select new TicketDto()
                        {
                            Id = ticket.Id,
                            Customer = new TicketCustomerDto()
                            {
                                Id = ticket.Customer.Id,
                                Name = ticket.Customer.Name,
                                Email = ticket.Customer.Email,
                                Username = ticket.Customer.Username
                            },
                            Attendant = new TicketAttendantDto()
                            {
                                Id = ticket.Attendant.Id,
                                Name = ticket.Attendant.Name,
                                Email = ticket.Attendant.Email,
                                Username = ticket.Attendant.Username
                            },
                            Title = ticket.Title
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<TicketDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
