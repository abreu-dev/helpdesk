using HelpDesk.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infra.DbContext.Mappings
{
    public class TicketMessageMapping : IEntityTypeConfiguration<TicketMessageData>
    {
        public void Configure(EntityTypeBuilder<TicketMessageData> builder)
        {
            builder.ToTable("TicketMessage");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Ticket)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Property(x => x.Message)
                .IsRequired();
        }
    }
}
