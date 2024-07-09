namespace CleanCodeLesson.Homework;

public record Core
{
    public static Core DragonHeartstring => new(new Price(2m));
    public static Core UnicornHorn => new(new Price(1.6m));
    public static Core PhoenixFeather => new(new Price(4m));
    
    public Price Price { get; init; }

    private Core(Price price)
    {
        Price = price;
    }
}