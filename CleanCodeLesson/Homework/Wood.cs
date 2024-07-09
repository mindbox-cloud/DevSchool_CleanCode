namespace CleanCodeLesson.Homework;

public record Wood
{
    public static Wood Yew => new(new Price(0.2));
    public static Wood Holly => new(new Price(0.2));
    public static Wood Cedar => new(new Price(0.3));
    public static Wood Oak => new(new Price(0.4));
    
    public Price Price { get; set; }

    private Wood(Price price)
    {
        Price = price;
    }
}
