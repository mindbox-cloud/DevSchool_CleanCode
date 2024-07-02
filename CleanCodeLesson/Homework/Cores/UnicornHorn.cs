namespace CleanCodeLesson.Homework;

public record UnicornHorn(Age Age) : Core(new Price(1.6m))
{
    private readonly Price _basePrice = new Price(1.6m);

    public Price CalculatePrice()
    {
        if (Age.Value > 100)
        {
            return (Age.Value / 100m) * _basePrice;
        }

        return _basePrice;
    }
}