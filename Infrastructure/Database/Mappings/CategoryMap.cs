using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalVSA.Domain.Entities;

namespace MinimalVSA.Infrastructure.Database.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("getdate()");

        builder.Property(x => x.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("getdate()");

        builder.Property(x => x.Active)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(true);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);

    }
}