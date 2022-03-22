using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class PromotionProgramMap : IEntityTypeConfiguration<PromotionProgram>
{
    public void Configure(EntityTypeBuilder<PromotionProgram> builder)
    {
        // Primary Key
        builder.HasKey(t => t.Id);

        // Table & Column Mappings
        builder.ToTable("PromotionProgram");
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(t => t.PromotionId).HasColumnName("PromotionId").IsRequired();

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.PromotionPrograms)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.Promotion)
            .WithOne(x => x.PromotionProgram)
            .HasForeignKey<PromotionProgram>(x => x.PromotionId);
    }
}
