namespace CleanCodeLesson.Homework;

public record Wood
{
    public static Wood Yew => new(new Price(0.2m));
    public static Wood Holly => new(new Price(0.2m));
    public static Wood Cedar => new(new Price(0.3m));
    public static Wood Oak => new(new Price(0.4m));
    
    public Price Price { get; init; }

    private Wood(Price price)
    {
        Price = price;
    }
}
