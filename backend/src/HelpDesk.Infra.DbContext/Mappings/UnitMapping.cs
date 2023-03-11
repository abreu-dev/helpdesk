using HelpDesk.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infra.DbContext.Mappings
{
    public class UnitMapping : IEntityTypeConfiguration<UnitData>
    {
        public void Configure(EntityTypeBuilder<UnitData> builder)
        {
            builder.ToTable(UnitData.TABLE_NAME, UnitData.TABLE_SCHEMA);

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Code)
                .IsRequired();
        }
    }
}
