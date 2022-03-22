using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class PromotionMap : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        // Primary Key
        builder.HasKey(t => t.Id);

        // Table & Column Mappings
        builder.ToTable("Promotion");
        builder.Property(t => t.Id).HasColumnName("Id");
        builder.Property(t => t.Description).HasColumnName("Description").IsRequired();
        builder.Property(t => t.PackageId).HasColumnName("PackageId").IsRequired();
        builder.Property(t => t.PromotionType).HasColumnName("PromotionType").IsRequired();
        builder.Property(t => t.DiscountedPrice).HasColumnName("DiscountedPrice");
        builder.Property(t => t.BuyingXQuantity).HasColumnName("BuyingXQuantity");
        builder.Property(t => t.PayingYQuantity).HasColumnName("PayingYQuantity");
    }
}
