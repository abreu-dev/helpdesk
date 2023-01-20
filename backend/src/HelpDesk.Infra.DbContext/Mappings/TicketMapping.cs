using HelpDesk.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infra.DbContext.Mappings
{
    public class TicketMapping : IEntityTypeConfiguration<TicketData>
    {
        public void Configure(EntityTypeBuilder<TicketData> builder)
        {
            builder.ToTable("Ticket");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.TicketsAsCustomer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(x => x.Attendant)
                .WithMany(x => x.TicketsAsAttendant)
                .HasForeignKey(x => x.AttendantId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
