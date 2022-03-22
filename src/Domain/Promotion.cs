using Common.Enums;

namespace Domain;

public class Promotion
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public string Description { get; set; }

    public PromotionType PromotionType { get; set; }

    public int? BuyingXQuantity { get; set; }
    public int? PayingYQuantity { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public PromotionProgram PromotionProgram { get; set; }
}
