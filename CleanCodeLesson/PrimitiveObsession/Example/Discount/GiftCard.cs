namespace CleanCodeLesson.PrimitiveObsession.Example.Discount;

public class GiftCard
{
    public decimal Discount { get; set; }
}

public record Discount
{
    public Discount(decimal amount)
    {
        if (amount < 0m || amount > 1m) throw new ArgumentOutOfRangeException(nameof(amount));

        Amount = amount;
    }

    public decimal Amount { get; init; }
}