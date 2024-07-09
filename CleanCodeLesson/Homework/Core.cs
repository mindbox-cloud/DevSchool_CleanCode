namespace CleanCodeLesson.Homework;

public record Core
{
    public static Core DragonHeartstring => new(new Price(2));
    public static Core UnicornHorn => new(new Price(1.6));
    public static Core PhoenixFeather => new(new Price(4));
    
    public Price Price { get; set; }

    private Core(Price price)
    {
        Price = price;
    }
}