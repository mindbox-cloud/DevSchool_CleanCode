namespace CleanCodeLesson.Homework;

public record Wood
{
    public static Wood Taxus => new(new Price(0.2m)); // Тис
    public static Wood Holy => new(new Price(0.2m)); // Остролист
    public static Wood Cedrus => new(new Price(0.3m)); // Кедр
    public static Wood Oak => new(new Price(0.4m)); // Дуб

    private Wood(Price price)
    {
        Price = price;
    }

    public Price Price { get; }
}