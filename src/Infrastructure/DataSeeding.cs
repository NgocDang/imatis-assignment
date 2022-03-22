using Common.Enums;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DataSeeding
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
           new Customer { Id = 1, Name = string.Empty },
           new Customer { Id = 2, Name = "IMT" },
           new Customer { Id = 3, Name = "FWH" },
           new Customer { Id = 4, Name = "DNV" }
       );

        modelBuilder.Entity<Package>().HasData(
           new Package { Id = 1, Name = "Basic", Description = "10 health check-up items", Price = 99.99M },
           new Package { Id = 2, Name = "Standard", Description = "15 health check-up items", Price = 129.99M },
           new Package { Id = 3, Name = "Advanced", Description = "20 health check-up items", Price = 149.99M }
       );

        modelBuilder.Entity<Promotion>().HasData(
           new Promotion { Id = 1, PackageId = 1, Description = "Get a 6 of 4 for Basic Package", PromotionType = PromotionType.BuyXPayY, BuyingXQuantity = 6, PayingYQuantity = 4 },
           new Promotion { Id = 2, PackageId = 2, Description = "Get a 10 of 5 for Standard Package", PromotionType = PromotionType.BuyXPayY, BuyingXQuantity = 10, PayingYQuantity = 5 },
           new Promotion { Id = 3, PackageId = 3, Description = "On Advanced Package get the price drops to $139.99", PromotionType = PromotionType.PriceDiscount, DiscountedPrice = 139.99M }
       );

        modelBuilder.Entity<PromotionProgram>().HasData(
          new PromotionProgram { Id = 1, CustomerId = 2, PromotionId = 1 },
          new PromotionProgram { Id = 2, CustomerId = 3, PromotionId = 3 },
          new PromotionProgram { Id = 3, CustomerId = 4, PromotionId = 2 }
      );
    }
}
