using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Primary Key
        builder.HasKey(t => t.Id);

        // Table & Column Mappings
        builder.ToTable("Customer");
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(x => x.PromotionPrograms)
            .WithOne()
            .HasForeignKey(x => x.CustomerId);
    }
}
