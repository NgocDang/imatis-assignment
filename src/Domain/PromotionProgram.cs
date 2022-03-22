namespace Domain;

public class PromotionProgram
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int PromotionId { get; set; }

    public Customer Customer { get; set; }

    public Promotion Promotion { get; set; }
}
