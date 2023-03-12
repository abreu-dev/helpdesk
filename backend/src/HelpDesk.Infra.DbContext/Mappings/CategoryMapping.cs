using HelpDesk.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infra.DbContext.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<CategoryData>
    {
        public void Configure(EntityTypeBuilder<CategoryData> builder)
        {
            builder.ToTable(CategoryData.TABLE_NAME, CategoryData.TABLE_SCHEMA);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasOne(x => x.ParentCategory)
                .WithMany()
                .HasForeignKey(x => x.ParentCategoryId);
        }
    }
}
