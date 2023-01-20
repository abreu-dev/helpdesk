using HelpDesk.Core.Domain.Security.Interfaces;
using HelpDesk.Core.Infra.Data.Context;
using HelpDesk.Core.Infra.Data.Repositories;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Ticket.Domain.Entities;
using HelpDesk.Ticket.Domain.Repositories;

namespace HelpDesk.Ticket.Infra.Repository.Repositories
{
    public class TicketRepository : AuditableRepository<TicketDomain, TicketData>, ITicketRepository
    {
        public TicketRepository(IDataContext dataContext,
                                ISessionService sessionService)
            : base(dataContext, sessionService)
        {
        }

        protected override TicketDomain Convert(TicketData dataEntity)
        {
            var messages = dataEntity.Messages.Select(message => 
                new TicketMessageDomain(
                    message.Id,
                    message.TicketId,
                    message.OwnerId,
                    message.Message))
                .ToList();

            return new TicketDomain(
                dataEntity.Id,
                dataEntity.CustomerId,
                dataEntity.AttendantId,
                dataEntity.Title,
                messages);
        }

        protected override TicketData Convert(TicketDomain domainEntity)
        {
            var messages = domainEntity.Messages.Select(message => 
                new TicketMessageData
                {
                    Id = message.Id,
                    TicketId = message.TicketId,
                    OwnerId = message.OwnerId,
                    Message = message.Message,
                })
                .ToList();

            return new TicketData
            {
                Id = domainEntity.Id,
                CustomerId = domainEntity.CustomerId,
                AttendantId = domainEntity.AttendantId,
                Title = domainEntity.Title,
                Messages = messages
            };
        }
    }
}
