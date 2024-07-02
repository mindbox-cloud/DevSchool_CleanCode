namespace CleanCodeLesson.Homework;

public record UnicornHorn(UnicornAge UnicornAge) : Core(new Price(1.6m))
{
    private readonly Price _basePrice = new Price(1.6m);

    public Price CalculatePrice()
    {
        if (UnicornAge.Value > 100)
        {
            return (UnicornAge.Value / 100m) * _basePrice;
        }

        return _basePrice;
    }
}