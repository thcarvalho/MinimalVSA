using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalVSA.Domain.Entities;

namespace MinimalVSA.Infrastructure.Database.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
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
        builder.Property(x => x.Price).IsRequired();
        builder.HasOne(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryId);
    }
}