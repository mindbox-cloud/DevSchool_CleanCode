namespace CleanCodeLesson.Homework.Shop.ValueTypes;

public record Wood
{
    public static Wood Yew => new(new Price(Constants.WoodPrice.Yew));
    public static Wood Holly => new(new Price(Constants.WoodPrice.Holly));
    public static Wood Cedar => new(new Price(Constants.WoodPrice.Cedar));
    public static Wood Oak => new(new Price(Constants.WoodPrice.Oak));
    
    public Price Price { get; init; }

    private Wood(Price price)
    {
        Price = price;
    }
}
